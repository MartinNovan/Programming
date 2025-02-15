using System.Windows;

namespace _10_assigment;

public partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void UnderlineOnChecked(object sender, RoutedEventArgs e)
    {
        SetTextDecoration(TextDecorations.Underline);
    }

    private void OverlineOnChecked(object sender, RoutedEventArgs e)
    {
        SetTextDecoration(TextDecorations.OverLine);
    }

    private void StrikethroughOnChecked(object sender, RoutedEventArgs e)
    {
        SetTextDecoration(TextDecorations.Strikethrough);
    }

    private void CheckBoxUnchecked(object sender, RoutedEventArgs e)
    {
        if (UnderlineCheckBox.IsChecked != null && !UnderlineCheckBox.IsChecked.Value 
            && OverlineCheckBox.IsChecked != null && !OverlineCheckBox.IsChecked.Value 
            && StrikethroughCheckBox.IsChecked != null && !StrikethroughCheckBox.IsChecked.Value)
        {
            TextBox.TextDecorations = null;
        }
    }

    private void SetTextDecoration(TextDecorationCollection decoration)
    {
        TextBox.TextDecorations = decoration;

        if (decoration == TextDecorations.Underline)
        {
            OverlineCheckBox.IsChecked = false;
            StrikethroughCheckBox.IsChecked = false;
        }
        else if (decoration == TextDecorations.OverLine)
        {
            UnderlineCheckBox.IsChecked = false;
            StrikethroughCheckBox.IsChecked = false;
        }
        else if (decoration == TextDecorations.Strikethrough)
        {
            UnderlineCheckBox.IsChecked = false;
            OverlineCheckBox.IsChecked = false;
        }
    }
}