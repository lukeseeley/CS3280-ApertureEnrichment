using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApertureEnrichmentKids
{
    /// <summary>
    /// The class for storing the leader boards
    /// </summary>
    class ScoreScreen
    {
        #region Attributes
        /// <summary>
        /// The addition leader board list
        /// </summary>
        private List<ScoreField> additionBoard;

        /// <summary>
        /// The subtraction leader board list
        /// </summary>
        private List<ScoreField> subtractionBoard;

        /// <summary>
        /// The multiplication leader board
        /// </summary>
        private List<ScoreField> multiplicationBoard;

        /// <summary>
        /// The division leader board
        /// </summary>
        private List<ScoreField> divisionBoard;

        #endregion

        #region Methods

        /// <summary>
        /// Constructor for initializing the ScoreScreen leader boards
        /// </summary>
        public ScoreScreen()
        {
            //Initialize the addition board
            additionBoard = new List<ScoreField>();
            additionBoard.Add(new ScoreField("Chell", 7, 10, "0:21"));
            additionBoard.Add(new ScoreField("GLaDOS", 8, 10, "0:32"));
            additionBoard.Add(new ScoreField("Virgil", 5, 9, "0:39"));
            additionBoard.Add(new ScoreField("Mell", 6, 9, "0:41"));
            additionBoard.Add(new ScoreField("Doug Rattmann", 7, 8, "0:45"));
            additionBoard.Add(new ScoreField("P-Body", 4, 7, "0:53"));
            additionBoard.Add(new ScoreField("ATLAS", 3, 6, "1:03"));
            additionBoard.Add(new ScoreField("AEGIS", 4, 5, "1:08"));
            additionBoard.Add(new ScoreField("Caroline", 10, 4, "1:18"));
            additionBoard.Add(new ScoreField("Wheatley", 4, 2, "1:30"));

            subtractionBoard = new List<ScoreField>();
            subtractionBoard.Add(new ScoreField("Chell", 7, 10, "0:21"));
            subtractionBoard.Add(new ScoreField("GLaDOS", 8, 10, "0:32"));
            subtractionBoard.Add(new ScoreField("Virgil", 5, 9, "0:39"));
            subtractionBoard.Add(new ScoreField("Mell", 6, 9, "0:41"));
            subtractionBoard.Add(new ScoreField("Doug Rattmann", 7, 8, "0:45"));
            subtractionBoard.Add(new ScoreField("P-Body", 4, 7, "0:53"));
            subtractionBoard.Add(new ScoreField("ATLAS", 3, 6, "1:03"));
            subtractionBoard.Add(new ScoreField("AEGIS", 4, 5, "1:08"));
            subtractionBoard.Add(new ScoreField("Caroline", 10, 4, "1:18"));
            subtractionBoard.Add(new ScoreField("Wheatley", 4, 2, "1:30"));

            multiplicationBoard = new List<ScoreField>();
            multiplicationBoard.Add(new ScoreField("Chell", 7, 10, "0:31"));
            multiplicationBoard.Add(new ScoreField("GLaDOS", 8, 10, "0:42"));
            multiplicationBoard.Add(new ScoreField("Virgil", 5, 9, "0:49"));
            multiplicationBoard.Add(new ScoreField("Mell", 6, 9, "0:51"));
            multiplicationBoard.Add(new ScoreField("Doug Rattmann", 7, 8, "0:55"));
            multiplicationBoard.Add(new ScoreField("P-Body", 4, 7, "1:03"));
            multiplicationBoard.Add(new ScoreField("ATLAS", 3, 6, "1:13"));
            multiplicationBoard.Add(new ScoreField("AEGIS", 4, 5, "1:18"));
            multiplicationBoard.Add(new ScoreField("Caroline", 10, 4, "1:28"));
            multiplicationBoard.Add(new ScoreField("Wheatley", 4, 2, "1:40"));

            divisionBoard = new List<ScoreField>();
            divisionBoard.Add(new ScoreField("Chell", 7, 10, "0:31"));
            divisionBoard.Add(new ScoreField("GLaDOS", 8, 10, "0:42"));
            divisionBoard.Add(new ScoreField("Virgil", 5, 9, "0:49"));
            divisionBoard.Add(new ScoreField("Mell", 6, 9, "0:51"));
            divisionBoard.Add(new ScoreField("Doug Rattmann", 7, 8, "0:55"));
            divisionBoard.Add(new ScoreField("P-Body", 4, 7, "1:03"));
            divisionBoard.Add(new ScoreField("ATLAS", 3, 6, "1:13"));
            divisionBoard.Add(new ScoreField("AEGIS", 4, 5, "1:18"));
            divisionBoard.Add(new ScoreField("Caroline", 10, 4, "1:28"));
            divisionBoard.Add(new ScoreField("Wheatley", 4, 2, "1:40"));
        }

        public void addResult(User user, int score, string time, char mode)
        {
            var scoreField = new ScoreField(user.Name, user.Age, score, time);
            int index = -1;
            switch (mode)
            {
                case 'A':
                    for (int i = 0; i < 10; i++)
                    {
                        int secs = Int32.Parse(time.Substring(time.Length - 2));
                        secs += 60 * Int32.Parse(time.Substring(0, time.Length - 3));

                        var fieldTime = additionBoard[i].Time;
                        int fieldSecs = Int32.Parse(fieldTime.Substring(fieldTime.Length - 2));
                        fieldSecs += 60 * Int32.Parse(fieldTime.Substring(0, fieldTime.Length - 3));

                        if (score > additionBoard[i].Score) //Then score is greater, and we found our index
                        {
                            index = i;
                            break;
                        }
                        else if (score == additionBoard[i].Score && secs <= fieldSecs) //Then the scores are equal, but time is better or equal
                        {
                            index = i;
                            break;
                        }
                    }

                    if(index >= 0)
                    {
                        additionBoard.Insert(index, scoreField);
                        additionBoard.RemoveAt(additionBoard.Count - 1);
                    }
                    break;
                case 'S':
                    for (int i = 0; i < 10; i++)
                    {
                        int secs = Int32.Parse(time.Substring(time.Length - 2));
                        secs += 60 * Int32.Parse(time.Substring(0, time.Length - 3));

                        var fieldTime = subtractionBoard[i].Time;
                        int fieldSecs = Int32.Parse(fieldTime.Substring(fieldTime.Length - 2));
                        fieldSecs += 60 * Int32.Parse(fieldTime.Substring(0, fieldTime.Length - 3));

                        if (score > subtractionBoard[i].Score) //Then score is greater, and we found our index
                        {
                            index = i;
                            break;
                        }
                        else if (score == subtractionBoard[i].Score && secs <= fieldSecs) //Then the scores are equal, but time is greater or equal
                        {
                            index = i;
                            break;
                        }
                    }

                    if (index >= 0)
                    {
                        subtractionBoard.Insert(index, scoreField);
                        subtractionBoard.RemoveAt(subtractionBoard.Count - 1);
                    }
                    break;
                case 'M':
                    for (int i = 0; i < 10; i++)
                    {
                        int secs = Int32.Parse(time.Substring(time.Length - 2));
                        secs += 60 * Int32.Parse(time.Substring(0, time.Length - 3));

                        var fieldTime = multiplicationBoard[i].Time;
                        int fieldSecs = Int32.Parse(fieldTime.Substring(fieldTime.Length - 2));
                        fieldSecs += 60 * Int32.Parse(fieldTime.Substring(0, fieldTime.Length - 3));

                        if (score > multiplicationBoard[i].Score) //Then score is greater, and we found our index
                        {
                            index = i;
                            break;
                        }
                        else if (score == multiplicationBoard[i].Score && secs <= fieldSecs) //Then the scores are equal, but time is greater or equal
                        {
                            index = i;
                            break;
                        }
                    }

                    if (index >= 0)
                    {
                        multiplicationBoard.Insert(index, scoreField);
                        multiplicationBoard.RemoveAt(multiplicationBoard.Count - 1);
                    }
                    break;
                case 'D':
                    for (int i = 0; i < 10; i++)
                    {
                        int secs = Int32.Parse(time.Substring(time.Length - 2));
                        secs += 60 * Int32.Parse(time.Substring(0, time.Length - 3));

                        var fieldTime = divisionBoard[i].Time;
                        int fieldSecs = Int32.Parse(fieldTime.Substring(fieldTime.Length - 2));
                        fieldSecs += 60 * Int32.Parse(fieldTime.Substring(0, fieldTime.Length - 3));

                        if (score > divisionBoard[i].Score) //Then score is greater, and we found our index
                        {
                            index = i;
                            break;
                        }
                        else if (score == divisionBoard[i].Score && secs <= fieldSecs) //Then the scores are equal, but time is greater or equal
                        {
                            index = i;
                            break;
                        }
                    }

                    if (index >= 0)
                    {
                        divisionBoard.Insert(index, scoreField);
                        divisionBoard.RemoveAt(divisionBoard.Count - 1);
                    }
                    break;
                default:
                    throw new Exception("Unexpected Mode case");
            }
        }

        /// <summary>
        /// This method is for retrieval of the score board depending on the mode
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        public List<ScoreField> getBoard(char mode)
        {
            switch (mode)
            {
                case 'A':
                    return additionBoard;
                case 'S':
                    return subtractionBoard;
                case 'M':
                    return multiplicationBoard;
                case 'D':
                    return divisionBoard;
                default:
                    throw new Exception("Unexpected Mode case");
            }
        }

        #endregion
    }

    /// <summary>
    /// A data object for storing the details of a games results
    /// </summary>
    class ScoreField
    {
        #region Attributes
        public string Name { get; set; }

        public int Age { get; set; }

        public int Score { get; set; }

        public string Time { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Score Field Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="score"></param>
        /// <param name="time"></param>
        public ScoreField(string name, int age, int score, string time)
        {
            Name = name;
            Age = age;
            Score = score;
            Time = time;
        }

        #endregion
    }
}
