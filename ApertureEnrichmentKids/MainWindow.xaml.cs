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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ApertureEnrichmentKids
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Attributes
        /// <summary>
        /// Window where the game is played
        /// </summary>
        private GameWindow gameWindow;

        /// <summary>
        /// Window where the final score is displayed
        /// </summary>
        private FinalScoreWindow finalWindow;

        /// <summary>
        /// Used for Aperture Orange color
        /// </summary>
        Brush AprOrange = new SolidColorBrush(Color.FromRgb(255, 154, 0));
        /// <summary>
        /// Used for Aperture Blue color
        /// </summary>
        Brush AprBlue = new SolidColorBrush(Color.FromRgb(39, 167, 216));

        SoundPlayer intro = new SoundPlayer("Audio/intro.wav");

        /// <summary>
        /// Stores the mode last clicked on by the user
        /// </summary>
        char mode;

        /// <summary>
        /// Stores the name from the name text box
        /// </summary>
        string name;

        /// <summary>
        /// Stores the age from the age text box
        /// </summary>
        int age;

        /// <summary>
        /// Stores the user
        /// </summary>
        User user;
        #endregion

        #region Methods

        public MainWindow()
        {
            InitializeComponent();

            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;

            //Setup subwindows
            gameWindow = new GameWindow();
            finalWindow = new FinalScoreWindow();

            //Setup main menu
            init_window();
            render_mode();
        }

        /// <summary>
        /// Sets the window up for initial state
        /// </summary>
        private void init_window()
        {
            //Set attributes
            name = "";
            age = 0;
            mode = 'A';

            //Set UI up
            txtName.Text = name;
            txtAge.Text = age.ToString();

            //Hide error text
            lblNameError.Content = "";
            lblAgeError.Content = "";

            //Now play intro
            intro.Play();
        }

        /// <summary>
        /// Renders the color changes based on the mode selected
        /// </summary>
        private void render_mode()
        {
            //Render mode buttons to reflect choice
            switch (mode)
            {
                case 'A':
                    btnAdd.BorderBrush = AprBlue;
                    btnAdd.Foreground = AprBlue;
                    btnSub.BorderBrush = AprOrange;
                    btnSub.Foreground = AprOrange;
                    btnMul.BorderBrush = AprOrange;
                    btnMul.Foreground = AprOrange;
                    btnDiv.BorderBrush = AprOrange;
                    btnDiv.Foreground = AprOrange;
                    break;
                case 'S':
                    btnAdd.BorderBrush = AprOrange;
                    btnAdd.Foreground = AprOrange;
                    btnSub.BorderBrush = AprBlue;
                    btnSub.Foreground = AprBlue;
                    btnMul.BorderBrush = AprOrange;
                    btnMul.Foreground = AprOrange;
                    btnDiv.BorderBrush = AprOrange;
                    btnDiv.Foreground = AprOrange;
                    break;
                case 'M':
                    btnAdd.BorderBrush = AprOrange;
                    btnAdd.Foreground = AprOrange;
                    btnSub.BorderBrush = AprOrange;
                    btnSub.Foreground = AprOrange;
                    btnMul.BorderBrush = AprBlue;
                    btnMul.Foreground = AprBlue;
                    btnDiv.BorderBrush = AprOrange;
                    btnDiv.Foreground = AprOrange;
                    break;
                case 'D':
                    btnAdd.BorderBrush = AprOrange;
                    btnAdd.Foreground = AprOrange;
                    btnSub.BorderBrush = AprOrange;
                    btnSub.Foreground = AprOrange;
                    btnMul.BorderBrush = AprOrange;
                    btnMul.Foreground = AprOrange;
                    btnDiv.BorderBrush = AprBlue;
                    btnDiv.Foreground = AprBlue;
                    break;
                default:
                    throw new Exception("Unexpected Mode case");
            }
        }

        /// <summary>
        /// Used to start the game using the name, age, and the selected game mode from the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            bool error = false;
            
            //Acquire date from txt fields
            name = txtName.Text;

            //Validate age
            if (name.Length <= 0)
            {
                lblNameError.Content = "Enter a Valid Name";
                error = true;
            }
            else
            {
                lblNameError.Content = "";
            }

            //Get age
            if (Int32.TryParse(txtAge.Text, out age) == false)
            {
                lblAgeError.Content = "Enter age between 3 - 10";
                error = true;
            }
            //Validate age
            else if (age < 3 || age > 10)
            {
                lblAgeError.Content = "Enter age between 3 - 10";
                error = true;
            }
            else
            {
                lblAgeError.Content = "";
            }

            if (error == false) //Then we do not have any data errors
            {
                user = new User(name, age);
                gameWindow.User = user;
                gameWindow.Mode = mode;

                //Switch to the game window
                this.Hide();
                gameWindow.ShowDialog();

                //Switch to the final score screen if the game was completed
                if(gameWindow.Complete) //Then the game was completed
                {
                    //Load in the data from the game data
                    finalWindow.User = user;
                    var result = gameWindow.getResults();
                    finalWindow.Score = result[0];
                    finalWindow.Time = result[1];
                    finalWindow.Mode = mode;
                    finalWindow.ShowDialog();
                }

                //Return to this window after finishing the game
                this.Show();
            }
        }

        /// <summary>
        /// Switch the mode to Addition
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            mode = 'A';
            render_mode();
        }

        /// <summary>
        /// Switch the mode to Subtraction
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSub_Click(object sender, RoutedEventArgs e)
        {
            mode = 'S';
            render_mode();
        }

        /// <summary>
        /// Switch the mode to Multiplication
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMul_Click(object sender, RoutedEventArgs e)
        {
            mode = 'M';
            render_mode();
        }

        /// <summary>
        /// Switch the mode to Division
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDiv_Click(object sender, RoutedEventArgs e)
        {
            mode = 'D';
            render_mode();
        }

        #endregion
    }
}
