using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApertureEnrichmentKids
{
    class Game
    {
        #region Attributes
        /// <summary>
        /// This is a char representation of the game mode
        /// </summary>
        private char mode;

        /// <summary>
        /// This is the current question the user is on, ranging from 1 - 10
        /// </summary>
        private int currentQuestion;

        /// <summary>
        /// This is the current number of questions the user has gotten correct, ranging from 0-10
        /// </summary>
        private int correctAnswers;

        /// <summary>
        /// The first number in the question
        /// </summary>
        private int num1;

        /// <summary>
        /// The second number in the question
        /// </summary>
        private int num2;

        /// <summary>
        /// This is the int representation of the answer
        /// </summary>
        private int answer;

        /// <summary>
        /// The class for RNG generation
        /// </summary>
        private Random rng;

        /// <summary>
        /// This is the accessor for the current question number
        /// </summary>
        public int CurrentQustion { get { return currentQuestion; } }

        /// <summary>
        /// This is the accessor for the current number of correct questions
        /// </summary>
        public int CorrectAnswers { get { return correctAnswers; } }

        #endregion

        #region Methods
        public Game(char mode)
        {
            currentQuestion = 0;
            correctAnswers = 0;
            this.mode = mode;
            rng = new Random();
        }

        /// <summary>
        /// Generates the question based on the mode
        /// </summary>
        /// <returns>A string representation of the question</returns>
        public string getQuestion()
        {
            currentQuestion++;
            
            switch (mode)
            {
                case 'A':
                    num1 = rng.Next(1, 11);
                    num2 = rng.Next(1, 11);

                    answer = num1 + num2;
                    return num1 + " + " + num2;
                case 'S':
                    num1 = rng.Next(1, 11);
                    num2 = rng.Next(1, 11);

                    if(num1 < num2)
                    {
                        int temptnum = num1;
                        num1 = num2;
                        num2 = temptnum;
                    }

                    answer = num1 - num2;
                    return num1 + " - " + num2;
                case 'M':
                    num1 = rng.Next(1, 11);
                    num2 = rng.Next(1, 11);

                    answer = num1 * num2;
                    return num1 + " X " + num2;
                case 'D':
                    bool invalid = true;
                    
                    while(invalid)
                    {
                        num1 = rng.Next(1, 11);
                        num2 = rng.Next(1, 11);

                        if (num1 < num2)
                        {
                            int temptnum = num1;
                            num1 = num2;
                            num2 = temptnum;
                        }
                        if (num1 % num2 == 0)
                        {
                            invalid = false;
                        }
                    }

                    answer = num1 / num2;
                    return num1 + " / " + num2;
                default:
                    throw new Exception("Unexpected Mode case");
            }
        }

        /// <summary>
        /// Compares the answer given by the user to the internal question answer to determine if it was the right answer. 
        /// </summary>
        /// <param name="answer"></param>
        /// <returns>true if answer was correct, or false if incorrect</returns>
        public bool sendAnswer(int answer)
        {
            if (this.answer == answer)
            {
                correctAnswers++;
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
