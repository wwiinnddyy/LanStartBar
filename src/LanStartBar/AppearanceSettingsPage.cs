using Jalium.UI;
using Jalium.UI.Controls;
using Jalium.UI.Controls.Themes;
using Jalium.UI.Media;

namespace LanStartBar;

public class AppearanceSettingsPage : Page
{
    public AppearanceSettingsPage()
    {
        Title = "外观";

        var lightButton = new Button
        {
            Content = "应用",
            VerticalAlignment = VerticalAlignment.Center
        };
        lightButton.Click += (_, _) => ThemeManager.ApplyTheme(ThemeVariant.Light);

        var darkButton = new Button
        {
            Content = "应用",
            VerticalAlignment = VerticalAlignment.Center
        };
        darkButton.Click += (_, _) => ThemeManager.ApplyTheme(ThemeVariant.Dark);

        var micaButton = new Button
        {
            Content = "应用",
            VerticalAlignment = VerticalAlignment.Center
        };
        micaButton.Click += (_, _) =>
        {
            if (AppContext.MainWindow != null)
                AppContext.MainWindow.SystemBackdrop = WindowBackdropType.Mica;
        };

        var acrylicButton = new Button
        {
            Content = "应用",
            VerticalAlignment = VerticalAlignment.Center
        };
        acrylicButton.Click += (_, _) =>
        {
            if (AppContext.MainWindow != null)
                AppContext.MainWindow.SystemBackdrop = WindowBackdropType.Acrylic;
        };

        var noneButton = new Button
        {
            Content = "应用",
            VerticalAlignment = VerticalAlignment.Center
        };
        noneButton.Click += (_, _) =>
        {
            if (AppContext.MainWindow != null)
                AppContext.MainWindow.SystemBackdrop = WindowBackdropType.None;
        };

        Content = new ScrollViewer
        {
            Content = new StackPanel
            {
                Margin = new Thickness(24),
                Children =
                {
                    new TextBlock
                    {
                        Text = "外观",
                        FontSize = 28,
                        FontWeight = FontWeight.FromOpenTypeWeight(600),
                        Margin = new Thickness(0, 0, 0, 4)
                    },
                    new TextBlock
                    {
                        Text = "个性化 LanStartBar 的视觉效果",
                        FontSize = 14,
                        Foreground = new SolidColorBrush(Colors.Gray),
                        Margin = new Thickness(0, 0, 0, 24)
                    },
                    new TextBlock
                    {
                        Text = "颜色模式",
                        FontSize = 16,
                        FontWeight = FontWeight.FromOpenTypeWeight(600),
                        Margin = new Thickness(0, 0, 0, 12)
                    },
                    CreateSettingsCard("浅色模式", "使用明亮的背景配色方案", Symbol.Light, lightButton),
                    CreateSettingsCard("深色模式", "使用暗色的背景配色方案", Symbol.Lightbulb, darkButton),
                    new TextBlock
                    {
                        Text = "窗口背景",
                        FontSize = 16,
                        FontWeight = FontWeight.FromOpenTypeWeight(600),
                        Margin = new Thickness(0, 24, 0, 12)
                    },
                    CreateSettingsCard("云母", "使用桌面壁纸着色窗口背景", Symbol.Palette, micaButton),
                    CreateSettingsCard("亚克力", "使用半透明模糊效果作为窗口背景", Symbol.Palette, acrylicButton),
                    CreateSettingsCard("无效果", "使用纯色背景，不使用任何材质效果", Symbol.Palette, noneButton)
                }
            }
        };
    }

    private static Border CreateSettingsCard(string header, string description, Symbol iconSymbol, UIElement action)
    {
        var icon = new SymbolIcon
        {
            Symbol = iconSymbol,
            Margin = new Thickness(0, 0, 16, 0),
            VerticalAlignment = VerticalAlignment.Center
        };

        var textStack = new StackPanel
        {
            Children =
            {
                new TextBlock
                {
                    Text = header,
                    FontSize = 14,
                    FontWeight = FontWeight.FromOpenTypeWeight(600)
                },
                new TextBlock
                {
                    Text = description,
                    FontSize = 12,
                    Foreground = new SolidColorBrush(Colors.Gray)
                }
            }
        };

        var card = new Border
        {
            Background = new SolidColorBrush(Colors.White),
            CornerRadius = new CornerRadius(8),
            BorderBrush = new SolidColorBrush(Color.FromRgb(230, 230, 230)),
            BorderThickness = new Thickness(1),
            Padding = new Thickness(16),
            Margin = new Thickness(0, 0, 0, 8),
            Child = new Grid
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) }
                },
                Children =
                {
                    icon,
                    textStack,
                    action
                }
            }
        };

        Grid.SetColumn(icon, 0);
        Grid.SetColumn(textStack, 1);
        Grid.SetColumn(action, 2);

        return card;
    }
}
