using Jalium.UI;
using Jalium.UI.Controls;
using Jalium.UI.Media;
using LanStartBar;

var app = new Application();

var window = new Window
{
    Title = "LanStartBar",
    Width = 480,
    Height = 720,
    SystemBackdrop = WindowBackdropType.None,
    Background = new SolidColorBrush(Color.FromArgb(242, 32, 32, 32)),
};

var statusText = new TextBlock
{
    Text = "当前样式: 正常",
    FontSize = 14,
    Margin = new Thickness(0, 16, 0, 0),
    Foreground = new SolidColorBrush(Color.FromRgb(180, 180, 190)),
};

var glassBorder = new GlassBorder
{
    CornerRadius = new CornerRadius(16),
    Padding = new Thickness(24),
    BackdropStyle = BackdropStyle.Normal,
};

var contentPanel = new StackPanel
{
    Children =
    {
        new TextBlock
        {
            Text = "LanStartBar",
            FontSize = 28,
            Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255)),
        },
        new TextBlock
        {
            Text = "Jalium UI sidebar and assistant toolbar shell",
            Margin = new Thickness(0, 8, 0, 24),
            Foreground = new SolidColorBrush(Color.FromRgb(180, 180, 190)),
        },
        new TextBlock
        {
            Text = "窗口样式",
            FontSize = 18,
            Margin = new Thickness(0, 0, 0, 12),
            Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255)),
        },
    }
};

contentPanel.Children.Add(CreateStyleButton("毛玻璃", BackdropStyle.FrostedGlass));
contentPanel.Children.Add(CreateStyleButton("云母", BackdropStyle.Mica));
contentPanel.Children.Add(CreateStyleButton("亚克力", BackdropStyle.Acrylic));
contentPanel.Children.Add(CreateStyleButton("液态玻璃", BackdropStyle.LiquidGlass));
contentPanel.Children.Add(CreateStyleButton("正常", BackdropStyle.Normal));
contentPanel.Children.Add(statusText);

glassBorder.Child = contentPanel;
window.Content = glassBorder;
app.Run(window);

Button CreateStyleButton(string text, BackdropStyle style)
{
    var btn = new Button
    {
        Content = text,
        Margin = new Thickness(0, 4, 0, 4),
        HorizontalAlignment = HorizontalAlignment.Stretch,
    };
    btn.Click += (_, _) => ApplyStyle(style);
    return btn;
}

void ApplyStyle(BackdropStyle style)
{
    glassBorder.BackdropStyle = style;

    switch (style)
    {
        case BackdropStyle.Normal:
            window.SystemBackdrop = WindowBackdropType.None;
            window.Background = new SolidColorBrush(Color.FromArgb(242, 32, 32, 32));
            statusText.Text = "当前样式: 正常";
            break;

        case BackdropStyle.FrostedGlass:
            window.SystemBackdrop = WindowBackdropType.Acrylic;
            window.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            statusText.Text = "当前样式: 毛玻璃";
            break;

        case BackdropStyle.Mica:
            window.SystemBackdrop = WindowBackdropType.Mica;
            window.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            statusText.Text = "当前样式: 云母";
            break;

        case BackdropStyle.Acrylic:
            window.SystemBackdrop = WindowBackdropType.Acrylic;
            window.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            statusText.Text = "当前样式: 亚克力";
            break;

        case BackdropStyle.LiquidGlass:
            window.SystemBackdrop = WindowBackdropType.Acrylic;
            window.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            statusText.Text = "当前样式: 液态玻璃";
            break;
    }
}
