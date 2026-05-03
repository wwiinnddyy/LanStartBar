using Jalium.UI;
using Jalium.UI.Controls;
using Jalium.UI.Media;

namespace LanStartBar;

public class GeneralSettingsPage : Page
{
    public GeneralSettingsPage()
    {
        Title = "通用";

        Content = new ScrollViewer
        {
            Content = new StackPanel
            {
                Margin = new Thickness(24),
                Children =
                {
                    new TextBlock
                    {
                        Text = "通用",
                        FontSize = 28,
                        FontWeight = FontWeight.FromOpenTypeWeight(600),
                        Margin = new Thickness(0, 0, 0, 4)
                    },
                    new TextBlock
                    {
                        Text = "管理 LanStartBar 的基本行为",
                        FontSize = 14,
                        Foreground = new SolidColorBrush(Colors.Gray),
                        Margin = new Thickness(0, 0, 0, 24)
                    },
                    new TextBlock
                    {
                        Text = "启动",
                        FontSize = 16,
                        FontWeight = FontWeight.FromOpenTypeWeight(600),
                        Margin = new Thickness(0, 0, 0, 12)
                    },
                    new Border
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
                                new SymbolIcon
                                {
                                    Symbol = Symbol.Switch,
                                    Margin = new Thickness(0, 0, 16, 0),
                                    VerticalAlignment = VerticalAlignment.Center
                                },
                                new StackPanel
                                {
                                    Children =
                                    {
                                        new TextBlock
                                        {
                                            Text = "开机启动",
                                            FontSize = 14,
                                            FontWeight = FontWeight.FromOpenTypeWeight(600)
                                        },
                                        new TextBlock
                                        {
                                            Text = "登录 Windows 时自动启动 LanStartBar",
                                            FontSize = 12,
                                            Foreground = new SolidColorBrush(Colors.Gray)
                                        }
                                    }
                                },
                                new ToggleSwitch()
                            }
                        }
                    }
                }
            }
        };
    }
}
