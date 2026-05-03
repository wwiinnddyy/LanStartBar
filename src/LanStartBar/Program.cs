using Jalium.UI;
using Jalium.UI.Controls;
using Jalium.UI.Media;

namespace LanStartBar;

class Program
{
    static void Main()
    {
        var app = new Application();

        var window = new Window
        {
            Title = "LanStartBar",
            Width = 480,
            Height = 720,
            SystemBackdrop = WindowBackdropType.Mica
        };

        AppContext.MainWindow = window;

        var mainPage = new MainPage();
        window.Content = mainPage;

        app.Run(window);
    }
}
