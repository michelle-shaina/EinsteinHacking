using System;
using System.Linq;
using EinsteinHacking.Data;
using Microsoft.EntityFrameworkCore;

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

            int score = 0;
            try
            {
                if (String.IsNullOrEmpty(userID)) return 0;
                var userProgress = _context.UserInformation.Include("Progress")
                    .FirstOrDefault(n => n.User.NormalizedUserName == userID.ToUpper())?.Progress;
                foreach (var progress in userProgress)
                {
                    if (progress.Status == Models.Status.Ended)
                    {
                        var targetChallenge = _context.UserProgress.Include("Challenge")
                            .FirstOrDefault(n => n.UserProgressID == progress.UserProgressID)?.Challenge;
                        if (targetChallenge != null)
                        {
                            score += targetChallenge.PointsOnCompletion;
                            score -= (targetChallenge.PointsRemovedPerHintUsed * progress.HintsUsed);
                        }
                    }
                }
            }
            catch
            {

            }
            return score;
        }
    }
}
