using System.Windows;
using System.Windows.Controls;

namespace _13_assigment.UserControls
{
    public partial class PlaceholderTextBox
    {
        public static readonly DependencyProperty PlaceholderProperty = DependencyProperty.Register(nameof(Placeholder), typeof(string), typeof(PlaceholderTextBox), new PropertyMetadata(""));
        public string Placeholder
        { 
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof(Text), typeof(string), typeof(PlaceholderTextBox), new PropertyMetadata(""));
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(PlaceholderTextBox), new PropertyMetadata(new CornerRadius(0)));
        public string CornerRadius
        {
            get => (string)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }
        public PlaceholderTextBox()
        {
            InitializeComponent();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textbox = (TextBox)sender;
            PLaceholderElement.Visibility = !string.IsNullOrEmpty(textbox.Text) ? Visibility.Collapsed : Visibility.Visible;
        }
    }
}