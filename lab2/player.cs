using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P;

namespace P2
{
    class Player : Person {
        private string _position;
        private string _club;
        private int _scoredGoals;
        public string Position { get { return _position; } set { _position = value; } }
        public string Club { get { return _club; } set { _club = value; } }
        public int ScoredGoals { get { return _scoredGoals; } set { _scoredGoals = value; } }
        public Player() : base() {
            _position = "";
            _club = "";
            _scoredGoals = 0;
        }
        public Player(string firstName, string lastName, DateTime dateOfBirth, string position, string club, int scoredGoals)
            : base(firstName, lastName, dateOfBirth) {
            _position = position;
            _club = club;
            _scoredGoals = scoredGoals;
        }
        public override string ToString() {
            return base.ToString() +
                $" Position: {_position}, Club: {_club}, Scored Goals: {_scoredGoals}";
        }

        public override void Details() {
            Console.WriteLine(this.ToString());

        }
        virtual public void ScoreGoal() {
            _scoredGoals++;
        }
    }
}
