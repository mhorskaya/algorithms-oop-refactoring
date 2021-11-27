using System;

// Q: What were the smells you spotted and how you refactored the design? Why is it better? How would that help?
// A: Field names in the class were not named according to the conventions. WonPoint() method was comparing player
// name with hardcoded 'player1' string, it was changed to compare value with given player names in the constructor.
// And if unknown player name is given to the method, an exception is thrown. GetScore() method was changed to use
// early return statements, once the score is determined. And the code is more readable and maintainable now.
namespace Tennis
{
    internal class TennisGame : ITennisGame
    {
        private int _score1;
        private int _score2;
        private readonly string _player1Name;
        private readonly string _player2Name;

        public TennisGame(string player1Name, string player2Name)
        {
            _player1Name = player1Name;
            _player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == _player1Name) _score1++;
            else if (playerName == _player2Name) _score2++;
            else throw new Exception("Unknown player");
        }

        public string GetScore()
        {
            if (_score1 == _score2)
                return _score1 switch
                {
                    0 => "Love-All",
                    1 => "Fifteen-All",
                    2 => "Thirty-All",
                    _ => "Deuce"
                };

            if (_score1 >= 4 || _score2 >= 4)
                return (_score1 - _score2) switch
                {
                    1 => "Advantage player1",
                    -1 => "Advantage player2",
                    >= 2 => "Win for player1",
                    _ => "Win for player2"
                };

            var scoreNames = new[] { "Love", "Fifteen", "Thirty", "Forty" };

            return scoreNames[_score1] + "-" + scoreNames[_score2];
        }
    }
}