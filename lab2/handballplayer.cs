using P2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HP
{
    class HandballPlayer : Player {
        public HandballPlayer(string firstName, string lastName, DateTime dateOfbirth, string position, string club, int scoredGoals)
            : base(firstName, lastName, dateOfbirth, position, club, scoredGoals) { }

        public override void ScoreGoal() {
            Console.WriteLine($"Handball player {_firstName} {_lastName} scored goal!");
            base.ScoreGoal();
        }
    }
}
