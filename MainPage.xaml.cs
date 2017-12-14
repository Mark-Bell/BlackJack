using System;
using System.Collections.Generic;
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
using Windows.Media.Core;
using Windows.Media.Playback;

namespace MarkBell_Project
{
    public sealed partial class MainPage : Page
    {
        string[] deck = new String[52];


        public MainPage()
        {
            this.InitializeComponent();

            for (int i = 0; i < 13; i++)
            {
                deck[i] = ((i + 1) + "D");
                deck[i + 13] = ((i + 1) + "S");
                deck[i + 26] = ((i + 1) + "H");
                deck[i + 39] = ((i + 1) + "C");
            }
                shuffle();

            
        }

        public void shuffle()
        {
            for (int i = 51; i >= 0; i--)
            {

                Random j = new Random();
                string[] shuffledDeck = deck.OrderBy(x => j.Next()).ToArray();
            }
        }

        public void deal()
        {
 
        }
    }
}

