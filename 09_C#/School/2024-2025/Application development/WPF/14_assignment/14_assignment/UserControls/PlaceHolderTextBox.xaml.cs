using System.Windows;
using System.Windows.Controls;

namespace _14_assignment.UserControls;

public partial class PlaceHolderTextBox
{
    public static readonly DependencyProperty PlaceholderProperty = DependencyProperty.Register(nameof(Placeholder), typeof(string), typeof(PlaceHolderTextBox), new PropertyMetadata(""));
    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }
    public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof(Text), typeof(string), typeof(PlaceHolderTextBox), new PropertyMetadata(""));
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
    public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(PlaceHolderTextBox), new PropertyMetadata(new CornerRadius(0)));
    public string CornerRadius
    {
        get => (string)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }
    public PlaceHolderTextBox()
    {
        InitializeComponent();
    }
    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        var textbox = (TextBox)sender;
        PlaceholderElement.Visibility = !string.IsNullOrEmpty(textbox.Text) ? Visibility.Collapsed : Visibility.Visible;
    }
}