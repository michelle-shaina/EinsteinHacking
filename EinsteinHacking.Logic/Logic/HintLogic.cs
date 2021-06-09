using System;
using System.Collections.Generic;
using System.Linq;
using EinsteinHacking.Data;
using EinsteinHacking.Models;

namespace EinsteinHacking.Logic
{
    public class HintLogic
    {
        private readonly ApplicationDbContext _context;
        public HintLogic(ApplicationDbContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Returns the Hint with the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Hint</returns>
        public Hint GetHint(int id)
        {
            return _context.Hints.FirstOrDefault(h => h.HintID == id);
        }

        /// <summary>
        /// Returns all Hints from challenge
        /// </summary>
        /// <param name="challengeID"></param>
        /// <returns></returns>
        public IEnumerable<Hint> GetHintsFromChallenge(int challengeID)
        {
            return _context.Challenges.FirstOrDefault(n => n.ChallengeID == challengeID)?.Hints;
        }
    }
}
