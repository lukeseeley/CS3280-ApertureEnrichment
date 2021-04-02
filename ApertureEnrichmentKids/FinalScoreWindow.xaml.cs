using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ApertureEnrichmentKids
{
    /// <summary>
    /// Interaction logic for FinalScoreWindow.xaml
    /// </summary>
    public partial class FinalScoreWindow : Window
    {
        #region Attributes
        /// <summary>
        /// This is the user's score
        /// </summary>
        public string Score { get; set; }

        /// <summary>
        /// Stores the last games time (in string format)
        /// </summary>
        public string Time { get; set; }

        /// <summary>
        /// Stores the user class
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Stores the char representation of the game mode
        /// </summary>
        public char Mode { get; set; }

        /// <summary>
        /// The class responsible for handling the score board
        /// </summary>
        private ScoreScreen scoreScreen;

        //////////////////// Assets

        /// <summary>
        /// Used for Aperture Orange color
        /// </summary>
        Brush AprOrange = new SolidColorBrush(Color.FromRgb(255, 154, 0));
        /// <summary>
        /// Used for Aperture Blue color
        /// </summary>
        Brush AprBlue = new SolidColorBrush(Color.FromRgb(39, 167, 216));

        /// <summary>
        /// Used to display the orange check mark
        /// </summary>
        BitmapImage checkOrange = new BitmapImage(new Uri(@"Images/check_box.jpg", UriKind.Relative));

        /// <summary>
        /// Used to display a green check mark
        /// </summary>
        BitmapImage checkGreen = new BitmapImage(new Uri(@"Images/check_box_green.jpg", UriKind.Relative));

        /// <summary>
        /// Used to display a blue check mark
        /// </summary>
        BitmapImage checkBlue = new BitmapImage(new Uri(@"Images/check_box_blue.jpg", UriKind.Relative));

        /// <summary>
        /// Used to display a Red X box
        /// </summary>
        BitmapImage checkX = new BitmapImage(new Uri(@"Images/X_box.jpg", UriKind.Relative));

        /// <summary>
        /// Sound effect for an average score
        /// </summary>
        SoundPlayer average = new SoundPlayer("Audio/average.wav");

        /// <summary>
        /// Sound effect for an high score
        /// </summary>
        SoundPlayer awesome = new SoundPlayer("Audio/awesome.wav");

        /// <summary>
        /// Sound effect for a low score
        /// </summary>
        SoundPlayer fail = new SoundPlayer("Audio/fail.wav");

        ///////////////////
        #endregion

        public FinalScoreWindow()
        {
            InitializeComponent();
            scoreScreen = new ScoreScreen();
        }

        /// <summary>
        /// Event for handling when the window is closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wndFinalScore_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        /// <summary>
        /// Event for handling when the window is opened. Data for final score must be loaded in by main window before the screen is opened.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wndFinalScore_Activated(object sender, EventArgs e)
        {
            //Handle error state in which the window was loaded prematurely (Data is loaded in before window is opened)
            if (User == null)
            {
                throw new Exception("Did not receive any user data");
            }

            if (Score.Length < 1)
            {
                throw new Exception("Did not receive any score data");
            }

            if (Time.Length < 1)
            {
                throw new Exception("Did not receive any timer data");
            }

            //Now display final results
            int score = Int32.Parse(Score);

            lblUserName.Content = "Name: " + User.Name;
            lblUserAge.Content = "Age: " + User.Age.ToString();
            lblScore.Content = Score + " / 10";
            lblTime.Content = Time;

            scoreScreen.addResult(User, score, Time, Mode);

            if(score <= 4) //Then it was a low score
            {
                lblResultMessage.Content = "Darn! Better luck next time!";
                imgResult.Source = checkX;
                lblScore.Foreground = Brushes.Red;
                rectScore.Stroke = Brushes.Red;
                lstLeaderBoard.Foreground = Brushes.Red;
                fail.Play();
            }
            else if (score <= 7) //Then it was an average score
            {
                lblResultMessage.Content = "Congrats! You did pretty good!";
                imgResult.Source = checkOrange;
                lblScore.Foreground = AprOrange;
                rectScore.Stroke = AprOrange;
                lstLeaderBoard.Foreground = AprOrange;
                average.Play();
            }
            else //Then it was a high score
            {
                lblResultMessage.Content = "Amazing Work! You did very well!";
                imgResult.Source = checkBlue;
                lblScore.Foreground = AprBlue;
                rectScore.Stroke = AprBlue;
                lstLeaderBoard.Foreground = AprBlue;
                awesome.Play();
            }

            //Now render the Score Board
            var gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Name",
                DisplayMemberBinding = new Binding("Name")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Age",
                DisplayMemberBinding = new Binding("Age")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Score",
                DisplayMemberBinding = new Binding("Score")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Time",
                DisplayMemberBinding = new Binding("Time")
            });

            lstLeaderBoard.View = gridView;
            lstLeaderBoard.Items.Clear();
            foreach (var row in scoreScreen.getBoard(Mode))
            {
                lstLeaderBoard.Items.Add(new { Name = row.Name, Age = row.Age, Score = row.Score.ToString() + " / 10", Time = row.Time });
            }

        }
    }
}
