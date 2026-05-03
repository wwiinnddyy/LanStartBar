using Jalium.UI;
using Jalium.UI.Controls;
using Jalium.UI.Media;

namespace LanStartBar;

public class MainPage : Page
{
    public MainPage()
    {
        Title = "LanStartBar";

        var settingsButton = new Button
        {
            Content = "设置",
            Margin = new Thickness(0, 16, 0, 0)
        };
        settingsButton.Click += (_, _) =>
        {
            if (AppContext.SettingsWindow == null)
            {
                AppContext.SettingsWindow = new SettingsWindow();
                AppContext.SettingsWindow.Closed += (_, _) =>
                {
                    AppContext.SettingsWindow = null;
                };
                AppContext.SettingsWindow.Show();
            }
            else
            {
                AppContext.SettingsWindow.Activate();
            }
        };

        Content = new StackPanel
        {
            Margin = new Thickness(24),
            Children =
            {
                new TextBlock
                {
                    Text = "LanStartBar",
                    FontSize = 28,
                    FontWeight = FontWeight.FromOpenTypeWeight(600)
                },
                new TextBlock
                {
                    Text = "Jalium UI sidebar and assistant toolbar shell",
                    Margin = new Thickness(0, 8, 0, 16)
                },
                new Button
                {
                    Content = "Start Building"
                },
                settingsButton
            }
        };
    }
}
