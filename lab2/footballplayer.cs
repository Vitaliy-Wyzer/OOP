using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HP;
using P2;

namespace FP
{
    class FootballPlayer : Player {
        public FootballPlayer(string firstName, string lastName, DateTime dateOfbirth, string position, string club, int scoredGoals)
            : base(firstName, lastName, dateOfbirth, position, club, scoredGoals)  { }

        public override void ScoreGoal() {
            Console.WriteLine($"Football player {_firstName} {_lastName} scored goal!");
            base.ScoreGoal();
        }
    }
}
