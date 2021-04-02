using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Threading;
using System.Media;

namespace ApertureEnrichmentKids
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        #region Attributes

        /// <summary>
        /// Game object for handling game logic
        /// </summary>
        private Game gameManager;

        /// <summary>
        /// A char representation of the current game mode
        /// </summary>
        public char Mode { get; set; }

        /// <summary>
        /// The user object
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// This boolean flag is used by the timer
        /// </summary>
        private bool gameRunning;

        /// <summary>
        /// This boolean flag is used by the main window to determine if the game was completed
        /// </summary>
        private bool gameComplete;

        /// <summary>
        /// The public accessor for grabbing if the game was completed
        /// </summary>
        public bool Complete { get { return gameComplete; } }

        /// <summary>
        /// This is the timer thread for updating the timer UI
        /// </summary>
        Thread timerThread;

        /// <summary>
        /// This is the class for the timer handler
        /// </summary>
        Timer timer;

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
        /// The image for a correct answer
        /// </summary>
        ImageBrush goodScreen = new ImageBrush(new BitmapImage(new Uri(@"Images/Aperture_Game_Good.png", UriKind.Relative)));

        /// <summary>
        /// The image for an incorrect answer
        /// </summary>
        ImageBrush badScreen = new ImageBrush(new BitmapImage(new Uri(@"Images/Aperture_Game_Bad.jpg", UriKind.Relative)));

        /// <summary>
        /// Used to display a green check mark
        /// </summary>
        BitmapImage checkGreen = new BitmapImage(new Uri(@"Images/check_box_green.jpg", UriKind.Relative));

        /// <summary>
        /// Used to display a Red X box
        /// </summary>
        BitmapImage checkX = new BitmapImage(new Uri(@"Images/X_box.jpg", UriKind.Relative));

        /// <summary>
        /// A buzzer sound effect
        /// </summary>
        SoundPlayer buzzer = new SoundPlayer("Audio/buzzer.wav");

        /// <summary>
        /// A button press sound effect
        /// </summary>
        SoundPlayer button = new SoundPlayer("Audio/button.wav");

        ///////////////////

        #endregion

        #region Methods

        public GameWindow()
        {
            InitializeComponent();
            txtAnswer.KeyDown += new KeyEventHandler(btnConfirm_KeyDown);
        }

        /// <summary>
        /// Method to handle window being closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        /// <summary>
        /// Method to handle game being canceled
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// Method for starting the window, handling initializing the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Activated(object sender, EventArgs e)
        {
            gameRunning = false;
            gameComplete = false;

            //Show start button
            btnStartGame.Visibility = Visibility.Visible;

            //Rest Game UI
            lblQuestion.Content = "";
            lblTimer.Content = "0:00";
            txtAnswer.Text = "";

            imgResult.Visibility = Visibility.Hidden;
            btnCancel.IsEnabled = false;
            btnConfirm.IsEnabled = false;
            txtAnswer.IsEnabled = false;
        }

        private void btnStartGame_Click(object sender, RoutedEventArgs e)
        {
            //Hide Start Button
            btnStartGame.Visibility = Visibility.Hidden;

            //Start UI
            btnCancel.IsEnabled = true;
            btnConfirm.IsEnabled = true;
            txtAnswer.IsEnabled = true;

            //Start game
            gameManager = new Game(Mode);
            gameRunning = true;
            gameComplete = false;

            timerThread = new Thread(new ThreadStart(timerTick));
            timerThread.Start();

            txtAnswer.Focus();
            nextQuestion();
        }

        /// <summary>
        /// Acquired the next question from the game object, and renders it
        /// </summary>
        private void nextQuestion()
        {
            string question = gameManager.getQuestion();
            lblQuestion.Content = question;
            barQuestionProgress.Value = gameManager.CurrentQustion;
            txtAnswer.Text = "";
        }

        /// <summary>
        /// Checks the user inputed answer
        /// </summary>
        private void checkAnswer()
        {
            int answer;

            if(Int32.TryParse(txtAnswer.Text, out answer) == false)
            {
                txtAnswer.Text = "";
                return;
            }

            txtAnswer.Text = "";
            

            if (gameManager.sendAnswer(answer) == true)
            {
                wndGameWindow.Background = goodScreen;
                lblQuestion.Foreground = AprBlue;
                barQuestionProgress.Foreground = AprBlue;
                button.Play();
                Thread animationThread = new Thread(new ThreadStart(animateResult_Success));
                animationThread.Start();
            }
            else
            {
                wndGameWindow.Background = badScreen;
                lblQuestion.Foreground = AprOrange;
                barQuestionProgress.Foreground = AprOrange;
                buzzer.Play();
                Thread animationThread = new Thread(new ThreadStart(animateResult_Fail));
                animationThread.Start();
            }

            //Handle end state
            if (gameManager.CurrentQustion < 10)
            {
                nextQuestion();
                txtAnswer.Focus();
            }
            else
            {
                gameRunning = false;
                txtAnswer.IsEnabled = false;
                btnConfirm.IsEnabled = false;
                gameComplete = true;
                this.Hide();
            }
        }

        /// <summary>
        /// Handles incrementing the timer
        /// </summary>
        private void timerTick()
        {
            timer = new Timer();
            Thread.Sleep(1000);

            while (gameRunning)
            {
                timer.timeIncrement();

                //lblTimer.Content = timer.Time;
                //lblTimer.Invoke(new DisplayTimer(displayTimer));

                this.Dispatcher.BeginInvoke(new DisplayTimer(displayTimer));
                
                
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Delegate to update timer UI element
        /// </summary>
        private delegate void DisplayTimer();

        /// <summary>
        /// Simply updates the timer UI element
        /// </summary>
        private void displayTimer()
        {
            lblTimer.Content = timer.Time;
        }

        private delegate void AnimateResult();

        private void displaySuccess()
        {
            imgResult.Source = checkGreen;
            imgResult.Visibility = Visibility.Visible;
        }

        private void displayFail()
        {
            imgResult.Source = checkX;
            imgResult.Visibility = Visibility.Visible;
        }

        private void displayHideResult()
        {
            imgResult.Visibility = Visibility.Hidden;
        }

        private void animateResult_Success()
        {
            this.Dispatcher.BeginInvoke(new AnimateResult(displaySuccess));
            Thread.Sleep(1000);
            this.Dispatcher.BeginInvoke(new AnimateResult(displayHideResult));
        }

        private void animateResult_Fail()
        {
            this.Dispatcher.BeginInvoke(new AnimateResult(displayFail));
            Thread.Sleep(1000);
            this.Dispatcher.BeginInvoke(new AnimateResult(displayHideResult));
        }

        /// <summary>
        /// Event for when the user clicks the confirm button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            checkAnswer();
        }

        /// <summary>
        /// Event for if the enter key is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                checkAnswer();
            }
        }

        /// <summary>
        /// Used to retrieve the date from the game, with score being the total correct answers
        /// </summary>
        /// <returns>String array containing {score, time}</returns>
        public string[] getResults()
        {
            var time = timer.Time;
            var score = gameManager.CorrectAnswers.ToString();
            
            return new string[] { score.ToString(), time };
        }

        #endregion
    }
}
