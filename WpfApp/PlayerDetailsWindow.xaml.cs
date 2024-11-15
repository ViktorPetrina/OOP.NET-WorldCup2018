using DataLayer.Model;
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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for PlayerDetailsWindow.xaml
    /// </summary>
    public partial class PlayerDetailsWindow : Window
    {
        private readonly string playerImagePath;
        private readonly string playerName;
        private readonly long playerShirtNumber;
        private readonly Position playerPosition;
        private readonly bool playerIsCaptain;
        private readonly int goals;
        private readonly int yellowCards;

        public PlayerDetailsWindow(Player player, int goals, int yellowCards)
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            InitializeComponent();
            this.playerImagePath = player.ImagePath;
            this.playerName = player.Name;
            this.playerShirtNumber = player.ShirtNumber;
            this.playerPosition = player.Position;
            this.playerIsCaptain = player.Captain;
            this.goals = goals;
            this.yellowCards = yellowCards;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblPlayerName.Content = playerName;
            lblCaptain.Content = playerIsCaptain ? "Yes" : "No";
            lblGoals.Content = goals;
            lblYellowCards.Content = yellowCards;
            lblPosition.Content = playerPosition;
            lblShirtNumber.Content = playerShirtNumber;

            if (playerImagePath is null) return;

            imgPlayerImage.Source = CreateImage(playerImagePath);
        }

        private ImageSource CreateImage(string playerImagePath)
        {
            BitmapImage image = new BitmapImage(new Uri(playerImagePath, UriKind.Absolute));
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.Freeze();
            return image;
        }
    }
}
