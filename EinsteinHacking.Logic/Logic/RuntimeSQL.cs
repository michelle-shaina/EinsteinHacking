using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EinsteinHacking.Logic
{
    public class RuntimeSQL
    {
        private EinsteinHacking.Data.ApplicationDbContext _context;
        private EinsteinHacking.Logic.ChallengeLogic _challengeLogic;

        private const string TABLE_NAME = "users";
        private String[,] _table;
        private const int TABLE_WIDTH = 2;
        private const int TABLE_HEIGHT = 3;

        private const int USERNAME = 0;
        private const string COLUMN_NAME_USERNAME = "username";
        private const int PASSWORD = 1;
        private const string COLUMN_NAME_PASSWORD = "password";

        private const string ALLOWED_IN_COLUMNNAME = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ*";
        private const char NULLCHAR = '$';

        private readonly string[] SQL_APPROVED_OPERATORS = new string[] { "=", ">", "<", ">=", "<=", "<>" };

        public RuntimeSQL(Data.ApplicationDbContext context)
        {
            this._context = context;
            this._challengeLogic = new ChallengeLogic(context);

            //get the solution
            var solution = _challengeLogic.GetChallenge(7).Solution;

            //create the table for accessing with the querry
            _table = new String[TABLE_HEIGHT, TABLE_WIDTH]
            {
                {"admin", solution},
                {"francessco", "das_glaubs_au_ned" },
                {"user", "nei_das_ned" },
            };
        }

        public List<String> ExecuteQuery(string query)
        {
            //validate the select and the where -> from is tested 6 lines below
            if (!ValidateSQL(query)) { return null; }

            //split values into different parts
            var sub = SplitQueryIntoFunction(query);

            //add the selected field to the return table
            var retList = new List<String>();
            for (int i = 0; i < _table.Length / TABLE_WIDTH; i++)
            {
                string temp = "";
                //cases that can be selected are * / username / password

                //if we habe a * we add both informations and continue to the next one
                if (sub[Cases.SELECT].ToLower().Contains("*"))
                {
                    temp += _table[i, USERNAME] + ' ' + _table[i, PASSWORD];
                    retList.Add(temp);
                    continue;
                }
                //if we have a usename, we add the usename
                if (sub[Cases.SELECT].ToLower().Contains(COLUMN_NAME_USERNAME)) { temp += _table[i, USERNAME] + ' '; }
                //If we select the password, we add it
                if (sub[Cases.SELECT].ToLower().Contains(COLUMN_NAME_PASSWORD)) { temp += _table[i, PASSWORD]; }

                retList.Add(temp);
            }

            if (!String.IsNullOrEmpty(sub[Cases.WHERE]))
            {
                List<string> toremove = new List<string>();
                //remove each row if they do not match our selection
                foreach (string row in retList)
                {
                    var username = row.Split(' ')[0];
                    var password = row.Split(' ')[1];

                    var conditions = sub[Cases.WHERE].Split(" and ");
                    foreach (var condition in conditions)
                    {
                        string con = RemapSQLWhere(condition);
                        string[] c = con.Split(' ');
                        var target = c[0].ToLower().Equals(COLUMN_NAME_USERNAME)
                            ? username : c[0].ToLower().Equals(COLUMN_NAME_PASSWORD) ? password : "";
                        switch (c[1])
                        {
                            case "=":
                                if (!(target.Equals(c[2]))) { toremove.Add(row); }
                                break;
                            case "<>":
                                if (target.Equals(c[2])) { toremove.Add(row); }
                                break;
                            default: throw new Exception("We should not be here");
                        }
                    }
                }

                //remove all not matching objects
                foreach(var n in toremove)
                    retList.Remove(n);
            }

            return retList;
        }
        private bool ValidateSQL(string query)
        {
            var statements = SplitQueryIntoFunction(query);
            //if select, from, and where are good, we return true
            return ValidateSQLSelect(statements[Cases.SELECT])
                && ValidateSQLFrom(statements[Cases.FROM])
                && ValidateSQLWhere(statements[Cases.WHERE]);
        }
        private bool ValidateSQLSelect(string select)
        {
            //Validate SELECT
            //if empty then something is wrong
            if (select.Replace(" ", "").Length == 0) { return false; }
            //if we end on ',' or ', ' then something is wrong
            if (select.Replace(" ", "")[^1].Equals(',')) { return false; }
            ///Expected syntax is column, column, column
            char expectedChar = NULLCHAR;
            //Checking if the sql fits the syntax
            foreach (char c in select)
            {
                //checking if the char is what we expect
                if (!expectedChar.Equals(NULLCHAR) && !c.Equals(expectedChar))
                    return false;
                //if the char is in the alphabet, we can assume we are still in the column name -> we don't expect any char
                if (ALLOWED_IN_COLUMNNAME.Contains(c) || c.Equals(' ')) { expectedChar = NULLCHAR; continue; }
                else if (c.Equals(',')) { expectedChar = ' '; continue; }
            }
            //if we expect something then false
            if (!expectedChar.Equals(NULLCHAR)) { return false; }
            //Validate that we only target the columns and password
            var filteredString = select.Replace(",", "");
            foreach (var word in filteredString.Split(' '))
                if (!(word.ToLower().Equals(COLUMN_NAME_USERNAME)
                    || word.ToLower().Equals(COLUMN_NAME_PASSWORD)
                    || word.ToLower().Equals("*")
                    || word.ToLower().Equals("")))
                    return false;

            return true;
        }
        private bool ValidateSQLFrom(string from)
        {
            return from.ToLower().Equals(TABLE_NAME);
        }
        private bool ValidateSQLWhere(string query)
        {
            if (String.IsNullOrEmpty(query)) { return true; }
            

            //remove the word from
            query = query.ToLower().Replace("from", "");
            query = RemapSQLWhere(query);

            //split into each selection (blablabla = shit)
            string[] selections = query.Split(" or ");
            //check each of them
            foreach (string selection in selections)
            {
                var words = selection.Split(" ");
                //if they do not follow the blablabla = shit format it not correct
                if (!(words.Length == 3)) { return false; }

                //test if the first of the three words is a column either username or password
                if (!(words[0].Equals(COLUMN_NAME_USERNAME) || words.Equals(COLUMN_NAME_PASSWORD))) { return false; }

                //check if the second word is a sql operation
                if (!SQL_APPROVED_OPERATORS.ToList().Any(n => n.ToLower().Equals(words[1].ToLower()))) { return false; }
            }
            return true;
        }

        private Dictionary<Cases, String> SplitQueryIntoFunction(string query)
        {
            var ret = new Dictionary<Cases, String>
            {
                { Cases.SELECT, "" },
                { Cases.FROM, "" },
                { Cases.WHERE, "" },
                { Cases.NULL, "" }
            };

            //adding the required parts of the Query (select / from / where)
            Cases current = Cases.NULL;
            foreach (var n in query.Split(' '))
            {
                if (n.ToLower().Equals("select")) { current = Cases.SELECT; continue; }
                else if (n.ToLower().Equals("from")) { current = Cases.FROM; continue; }
                else if (n.ToLower().Equals("where")) { current = Cases.WHERE; continue; }

                ret[current] += n;
            }

            ret.Remove(Cases.NULL);
            return ret;
        }
        private string RemapSQLWhere(string where)
        {
            return where.Replace("<>", " <> ")
                        .Replace("<=", " <= ")
                        .Replace(">=", " >= ")
                        .Replace("<", " < ")
                        .Replace(">", " > ")
                        .Replace("=", " = ");
        }
    }
    public enum Cases
    {
        NULL,
        SELECT,
        FROM,
        WHERE,
    }
}
