using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace WorkoutAssistant
{
    public sealed partial class MainPage : Page


    {
        //Declare Variables
        public int Set = 0;
        public int Cycle = 0;

        //Variables for Timers
        private int RTime = 5, PTime = 50, WSTime = 55;
        private DispatcherTimer Timer;

        //String array containing Exercises
        public String[] ExerciseList = { "25 Pushups", "30 Crunches", "50 Second Wall Sit", "10 Tricep Dips", "45 Second Plank", "30 Lunges (Per Leg)", "15 Squats" };

        public MainPage()
        {
            //initialise
            this.InitializeComponent();
        }

        //Begin Workout Routine
        private void Begin_Click(object sender, RoutedEventArgs e)
        {
            Initial.Visibility = Visibility.Collapsed;
            IncrementExercises();
        }

        //Advance to Rest Period, then next exercise
        public void IncrementExercises()
        {
            ExerciseGrid.Visibility = Visibility.Visible;
            Exercise.Text = (ExerciseList[Set]);

            //If WallSit is up, provide timer
            if (Set == 2)
                WSBttn.Visibility = Visibility.Visible;
            else
                WSBttn.Visibility = Visibility.Collapsed;

            //if Plank is up, provide timer
            if (Set == 4)
                PBttn.Visibility = Visibility.Visible;
            else
                PBttn.Visibility = Visibility.Collapsed;
        }

        //Button to begin Wall Sit CountDown
        private void WSBttn_Click(object sender, RoutedEventArgs e)
        {
            WSBttn.Visibility = Visibility.Collapsed;
            WallSitCountdown.Text = ("Timer begins in 5");
            WSTime = 55;
            CountDown1();
        }

        //Button to begin Plank CountDown
        private void PBttn_Click(object sender, RoutedEventArgs e)
        {
            PBttn.Visibility = Visibility.Collapsed;
            PlankCountdown.Text = ("Timer begins in 5");
            PTime = 50;
            CountDown2();
        }

        //Move from Exercise to Rest Period
        private void Increment_Click(object sender, RoutedEventArgs e)
        {
            ExerciseGrid.Visibility = Visibility.Collapsed;
            RestTime.Visibility = Visibility.Visible;
            Rest();
        }

        //Create Rest Timer for 90 Seconds
        public void Rest()
        {
            RTime = 5;
            Set++;
            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Tick += Timer_Tick;
            Timer.Start();
        }

        //Create 50 second CountDown for Wall Sit 
        public void CountDown1()
        {

            WallSitCountdown.Visibility = Visibility.Visible;
            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Tick += WSTimer_Tick;
            Timer.Start();
        }

        //Create 45 Second CountDown for Plank
        public void CountDown2()
        {

            PlankCountdown.Visibility = Visibility.Visible;
            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Tick += PTimer_Tick;
            Timer.Start();
        }

        //Ticker for Rest CountDown
        void Timer_Tick(object sender, object e)
        {
            //remove unwanted CountDowns
            WallSitCountdown.Visibility = Visibility.Collapsed;
            PlankCountdown.Visibility = Visibility.Collapsed;

            if (RTime > 0)
            {
                RTime--;
                TBCountDown.Text = (RTime.ToString() + " Seconds Remaining");
            }
            else
            {
                Timer.Stop();
                RTime = 5;
                if (Set == 7)
                {
                    Set = 0;
                    Cycle++;
                }

                //Reset elements
                TBCountDown.Text = ("90 Seconds Remaining");
                RestTime.Visibility = Visibility.Collapsed;
                IncrementExercises();
            }
        }

        //Ticker for WallSit CountDown
        void WSTimer_Tick(object sender, object e)
        {

            if (WSTime > 0)
            {
                WSTime--;
                if(WSTime > 50)
                WallSitCountdown.Text = ("Timer begins in " + (WSTime-50).ToString());
                else
                WallSitCountdown.Text = (WSTime.ToString() + " Seconds Remaining");
            }
            else
            {
                Timer.Stop();
                WSTime = 5;
            }
        }

        //Ticker for Plank CountDown
        void PTimer_Tick(object sender, object e)
        {

            if (PTime > 0)
            {
                PTime--;
                if (PTime > 45)
                   PlankCountdown.Text = ("Timer begins in " + (PTime - 45).ToString());
                else
                   PlankCountdown.Text = (PTime.ToString() + " Seconds Remaining");
            }
            else
            {
                Timer.Stop();
                PTime = 5;
            }
        }


    }
}
