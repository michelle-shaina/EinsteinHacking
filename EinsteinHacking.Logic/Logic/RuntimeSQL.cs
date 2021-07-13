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
            if (!ValidateSQLSelect(query)) { return null; }

            //split values into different parts
            var sub = SplitQueryIntoFunction(query);

            //Validate that the query targets the right table
            if (!sub[Cases.FROM].ToLower().Equals(TABLE_NAME)) { return null; }

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
            return retList;
        }
        private bool ValidateSQL(string select, string from, string where)
        {
            //if select, from, and where are good, we return true
            return ValidateSQLSelect(select) && ValidateSQLFrom(from) && ValidateSQLWhere(where);
        }
        private bool ValidateSQLSelect(string query)
        {
            var statements = SplitQueryIntoFunction(query);

            //return false if select or from is null
            if (String.IsNullOrEmpty(statements[Cases.SELECT]) || string.IsNullOrEmpty(statements[Cases.FROM])) { return false; }

            //Validate SELECT
            //if empty then something is wrong
            if (statements[Cases.SELECT].Replace(" ", "").Length == 0) { return false; }
            //if we end on ',' or ', ' then something is wrong
            if (statements[Cases.SELECT].Replace(" ", "")[statements[Cases.SELECT].Replace(" ", "").Length - 1].Equals(',')) { return false; }
            ///Expected syntax is column, column, column
            char expectedChar = NULLCHAR;
            //Checking if the sql fits the syntax
            foreach (char c in statements[Cases.SELECT])
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
            var filteredString = statements[Cases.SELECT].Replace(",", "");
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
            //TODO ValidateSQLWhere
            return true;
        }
        private Dictionary<Cases, String> SplitQueryIntoFunction(string query)
        {
            var ret = new Dictionary<Cases, String>();
            ret.Add(Cases.SELECT, "");
            ret.Add(Cases.FROM, "");
            ret.Add(Cases.WHERE, "");
            ret.Add(Cases.NULL, "");

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
    }
    public enum Cases
    {
        NULL,
        SELECT,
        FROM,
        WHERE,
    }
}
