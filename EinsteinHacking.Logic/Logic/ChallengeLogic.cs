using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EinsteinHacking.Data;
using EinsteinHacking.Models;
using Microsoft.EntityFrameworkCore;

namespace EinsteinHacking.Logic
{
    public class ChallengeLogic
    {
        private readonly ApplicationDbContext _context;
        public ChallengeLogic(ApplicationDbContext context)
        {
            this._context = context;
        }
        /// <summary>
        /// Returns all Challenges but in a lighter format, only including name and description.
        /// </summary>
        /// <returns>Challenges with name and description</returns>
        public IEnumerable<Challenge> GetChallengesLight()
        {
            var ret = new List<Challenge>();
            foreach(var challenge in _context.Challenges)
            {
                ret.Add(new Challenge()
                {
                    Name = challenge.Name,
                    Description = challenge.Description,
                });
            }
            return ret;
        }
        /// <summary>
        /// Returns the Challenge with the matching id, only including the name and the description
        /// </summary>
        /// p<param name="id">ID of the challenge</param>
        /// <returns>Challenge with name and description</returns>
        public Challenge GetChallengeLight(int id)
        {
            var challenge = _context.Challenges.FirstOrDefault(n => n.ChallengeID == id);
            if (challenge == null)
                return null;
            else
            {
                return new Challenge()
                {
                    Name = challenge.Name,
                    Description = challenge.Description,
                };
            }
        }
        /// <summary>
        /// Retuns all challenges without the Hints but all the other attributes
        /// </summary>
        /// <returns>Challenges with all attributes except the hints</returns>
        public IEnumerable<Challenge> GetChallenges()
        {
            return _context.Challenges.ToList();
        }
        /// <summary>
        /// Returns the challenge without the Hints but all other attributes
        /// </summary>
        /// <param name="id">ID of the challenge</param>
        /// <returns>Challenge with all attributes except the hints</returns>
        public Challenge GetChallenge(int id)
        {
            return _context.Challenges.FirstOrDefault(c => c.ChallengeID == id);
        }
        /// <summary>
        /// Returns the challenge with attributes and hints
        /// </summary>
        /// <returns>challenge with attributes and hints</returns>
        public IEnumerable<Challenge> GetChallengesFull()
        {
            return _context.Challenges.Include("Hints").ToList();
        }
        /// <summary>
        /// Returns the challenge with the matching id with attributes and hints
        /// </summary>
        /// <param name="id">ID of the challenge</param>
        /// <returns>challenge with the matching id with attributes and hints</returns>
        public Challenge GetChallengeFull(int id)
        {
            return _context.Challenges.Include("Hints").FirstOrDefault(c => c.ChallengeID == id);
        }

    }
}
