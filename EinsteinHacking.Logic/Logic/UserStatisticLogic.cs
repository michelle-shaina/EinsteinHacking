using System;
using EinsteinHacking.Data;

namespace EinsteinHacking.Logic
{
    public class UserStatisticLogic
    {
        private readonly ApplicationDbContext _context;
        public UserStatisticLogic(ApplicationDbContext context)
        {
            this._context = context;
        }


        /// <summary>
        /// Returns the current scrore of the user
        /// </summary>
        /// <returns></returns>
        public int GetUserScore(string userID)
        {
            throw new NotImplementedException();
        }
    }
}
