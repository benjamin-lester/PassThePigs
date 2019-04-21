using System;

namespace PassThePigs
{
    internal class Display
    {
        const string preRollDisplay = "Rolling the pigs...";
        const string KeepRollingQuestion = "Do you want to keep rolling?";
        const string EndTournamentQuestion = "Would you like to play again?";

        public Display()
        {
            
        }
        public string PreRoll() 
        {
            return preRollDisplay;
        }

        public string QuestionKeepRolling()
        {
            return KeepRollingQuestion;
        }
        public string QuestionEndTournament()
        {
            return EndTournamentQuestion;
        }
    }
}