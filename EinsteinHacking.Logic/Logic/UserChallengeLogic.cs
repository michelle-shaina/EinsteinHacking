using System;
using System.Collections.Generic;
using System.Linq;
using EinsteinHacking.Data;
using EinsteinHacking.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EinsteinHacking.Logic
{
    public class UserChallengeLogic
    {
        private readonly ApplicationDbContext _context;
        public UserChallengeLogic(ApplicationDbContext context)
        {
            this._context = context;
        }


        /// <summary>
        /// Checks if the User has all challenges and if not, creates them 
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public bool CheckUserhasChallenges(string username)
        {
            if (String.IsNullOrEmpty(username)) return false;

            //IdentityUser user = _context.Users.FirstOrDefault(n => n.UserName == username);
            UserInformation userInformation = _context.UserInformation.Include("Progress").FirstOrDefault(n => n.User.NormalizedUserName == username.ToUpper());
            if (userInformation == null || userInformation.Progress == null || userInformation.Progress.Count == 0)
            {
                //_context.UserInformation.Remove(userInformation);
                StartUserChallenges(username);
                return true;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Starts the challenge for the user
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="challengeID"></param>
        public void UserStartChallenge(string username, int challengeID)
        {
            CheckUserhasChallenges(username.ToUpper());
            UserSetStatus(username.ToUpper(), challengeID, Status.InProgress);
        }

        /// <summary>
        /// Completes the challenge for the user
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="challengeID"></param>
        public void UserCompleteChallenge(string username, int challengeID)
        {
            CheckUserhasChallenges(username.ToUpper());
            UserSetStatus(username.ToUpper(), challengeID, Status.Ended);
        }


        /// <summary>
        /// Gets the status of the challenge by the user 
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="challengeID"></param>
        /// <returns></returns>
        public Status UserGetChallengeStatus(string username, int challengeID)
        {
            CheckUserhasChallenges(username.ToUpper());
            var progress = GetUserProgress(username.ToUpper(), challengeID);
            if (progress != null)
            {
                return progress.Status;
            }
            else
            {
                throw new Exception($"Status was not found for User: {username} and challenge: {challengeID}");
            }
        }


        /// <summary>
        /// Returns the next Hint the user can use,
        /// activates it and reduces points
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="challengeID"></param>
        /// <returns>Hint</returns>
        public Hint UserGetHint(string username, int challengeID)
        {
            CheckUserhasChallenges(username.ToUpper());
            List<Hint> hints = (List<Hint>)new HintLogic(_context).GetHintsFromChallenge(challengeID);
            var userProgress = GetUserProgress(username.ToUpper(), challengeID);

            if (hints != null && userProgress != null && UserCanUseHint(username.ToUpper(), challengeID))
            {
                int numberOfHintsAvailable = hints.Count();
                int numberOfHintsUsed = userProgress.HintsUsed;
                if (numberOfHintsAvailable > numberOfHintsUsed)
                {
                    userProgress.HintsUsed++;
                    _context.UserProgress.Update(userProgress);
                    _context.SaveChanges();
                    return hints[numberOfHintsUsed];
                }
            }
            return null;
        }

        /// <summary>
        /// True if there is another Hint that the user can use for this challenge
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="challengeID"></param>
        /// <returns></returns>
        public bool UserCanUseHint(string username, int challengeID)
        {
            CheckUserhasChallenges(username.ToUpper());
            int? usableHints = new HintLogic(_context).GetHintsFromChallenge(challengeID)?.Count();
            int? usedHints = GetUserProgress(username.ToUpper(), challengeID)?.HintsUsed;

            if (usableHints.HasValue && usedHints.HasValue)
                return usedHints < usableHints;
            return false;
        }


        //private methods
        private void StartUserChallenges(string username)
        {
            var user = _context.Users.FirstOrDefault(c => c.NormalizedUserName == username.ToUpper());
            if (user != null)
            {
                UserInformation userInformation = new UserInformation()
                {
                    User = user,
                    Progress = new List<UserProgress>(),
                };
                foreach (var challenge in _context.Challenges)
                {
                    userInformation.Progress.Add(new UserProgress()
                    {
                        Challenge = challenge,
                        Status = Status.UnTouched,
                        HintsUsed = 0,
                    });
                }

                _context.UserInformation.Add(userInformation);
                _context.SaveChanges();
            }
        }

        private void UserSetStatus(string username, int challengeID, Status status)
        {
            CheckUserhasChallenges(username.ToUpper());
            var userProgress = GetUserProgress(username.ToUpper(), challengeID);

            if (userProgress != null)
            {
                userProgress.Status = status;
                _context.UserProgress.Update(userProgress);
                _context.SaveChanges();
            }
        }
        private UserProgress GetUserProgress(string username, int challengeID)
        {
            CheckUserhasChallenges(username.ToUpper());
            var UserInformation = _context.UserInformation.FirstOrDefault(u => u.User.NormalizedUserName == username.ToUpper());
            var userProgress = _context.UserProgress.Include("Challenge").Where(n => n.Challenge.ChallengeID == challengeID);

            foreach (var progress in userProgress)
            {
                foreach (var pro in UserInformation.Progress)
                {
                    if (pro.UserProgressID == progress.UserProgressID)
                    {
                        return progress;
                    }
                }
            }
            return null;
        }

    }
}
