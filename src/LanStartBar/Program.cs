using Jalium.UI;
using Jalium.UI.Controls;

var app = new Application();

var window = new Window
{
    Title = "LanStartBar",
    Width = 480,
    Height = 720,
    Content = new StackPanel
    {
        Margin = new Thickness(24),
        Children =
        {
            new TextBlock
            {
                Text = "LanStartBar",
                FontSize = 28
            },
            new TextBlock
            {
                Text = "Jalium UI sidebar and assistant toolbar shell",
                Margin = new Thickness(0, 8, 0, 16)
            },
            new Button
            {
                Content = "Start Building"
            }
        }
    }
};

app.Run(window);
