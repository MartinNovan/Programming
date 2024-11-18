using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _07_zadani
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var clickedButton = (Button)sender;
            string? clickedText = clickedButton.Content.ToString();

            Brush newBackground;
            Brush newForeground;

            switch (clickedText)
            {
                case "Černá":
                    newBackground = Brushes.Black;
                    newForeground = Brushes.White;
                    break;
                case "Modrá":
                    newBackground = Brushes.Blue;
                    newForeground = Brushes.White;
                    break;
                case "Červená":
                    newBackground = Brushes.Red;
                    newForeground = Brushes.Yellow;
                    break;
                case "Zelená":
                    newBackground = Brushes.Green;
                    newForeground = Brushes.Black;
                    break;
                default:
                    newBackground = Brushes.Gray;
                    newForeground = Brushes.Black;
                    break;
            }

            var buttons = DockPanel.Children.OfType<Grid>()
                .SelectMany(grid => grid.Children.OfType<Button>());

            foreach (var button in buttons)
            {
                button.Background = newBackground;
                button.Foreground = newForeground;
            }

            Text.Text = clickedText;
        }
    }
}