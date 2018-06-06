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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfGame
{
    /// <summary>
    /// Interaction logic for GameUC.xaml
    /// </summary>
    public partial class GameUC : UserControl
    {
        public double PixelsPerMove { get; private set; }
        public GameUC(double ppm)
        {
            InitializeComponent();
            PixelsPerMove = ppm;
        }

        /// <summary>
        /// načtení UC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.KeyUp += HandleKeyPress;
        }

        /// <summary>
        /// zachytí stisk klávesy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleKeyPress(object sender, KeyEventArgs e)
        {
            double width = LeftColumnGrid.ActualWidth;

            if (e.Key == Key.Left)
                width = LeftColumnGrid.ActualWidth - PixelsPerMove;
            else if (e.Key == Key.Right)
                width = LeftColumnGrid.ActualWidth + PixelsPerMove;

            if (width <= 0)
            {
                MessageBox.Show("Red");
                width = 0;
            }
            else if (width >= GameGrid.ActualWidth)
            {
                MessageBox.Show("Blue");
                width = GameGrid.ActualWidth;
            }

            LeftColumnGrid.Width = new GridLength(width);

        }
    }
}
