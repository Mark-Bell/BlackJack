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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WorkoutAssistant
{
    public sealed partial class MainPage : Page


    {
        public int Set = 0;
        public int Cycle = 0;
        private int time = 5;
        private DispatcherTimer Timer;

        public String[] ExerciseList = { "25 Pushups", "30 Crunches", "50 Second Wall Sit", "!0 Tricep Dips", "45 Second Plank", "30 Lunges (Per Leg)", "15 Squats" };

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Begin_Click(object sender, RoutedEventArgs e)
        {
            Initial.Visibility = Visibility.Collapsed;
            IncrementExercises();
        }

        public void IncrementExercises()
        {
            ExerciseGrid.Visibility = Visibility.Visible;
            Exercise.Text = (ExerciseList[Set]);
            if(Set == 3)
            {
                CountDown1();
            }
        }

        private void Increment_Click(object sender, RoutedEventArgs e)
        {
            ExerciseGrid.Visibility = Visibility.Collapsed;
            RestTime.Visibility = Visibility.Visible;
            Rest();
        }

        public void Rest()
        {
            Set++;
            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 0);
            Timer.Tick += Timer_Tick;
            Timer.Start();
        }

        public void CountDown1()
        {
            WallSitCountdown.Visibility = Visibility.Visible;

        }

        void Timer_Tick(object sender, object e)
        {
            if (time > 0)
            {
                time--;
                TBCountDown.Text = (time.ToString() + " Seconds Remaining");
            }
            else
            {
                Timer.Stop();
                time = 5;
                if (Set == 7)
                {
                    Set = 0;
                    Cycle++;
                }
                IncrementExercises();
                RestTime.Visibility = Visibility.Collapsed;
            }
        }

    }

}
