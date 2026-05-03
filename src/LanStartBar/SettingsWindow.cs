using Jalium.UI;
using Jalium.UI.Controls;
using Jalium.UI.Media;

namespace LanStartBar;

public class SettingsWindow : Window
{
    public SettingsWindow()
    {
        Title = "设置";
        Width = 700;
        Height = 520;
        SystemBackdrop = WindowBackdropType.Mica;

        var appearanceItem = new NavigationViewItem
        {
            Content = "外观",
            Icon = new SymbolIcon { Symbol = Symbol.Palette },
            Tag = typeof(AppearanceSettingsPage)
        };

        var generalItem = new NavigationViewItem
        {
            Content = "通用",
            Icon = new SymbolIcon { Symbol = Symbol.Setting },
            Tag = typeof(GeneralSettingsPage)
        };

        var navView = new NavigationView
        {
            PaneTitle = "设置",
            PaneDisplayMode = NavigationViewPaneDisplayMode.LeftCompact,
            IsPaneOpen = false,
            Content = new AppearanceSettingsPage()
        };

        navView.MenuItems.Add(appearanceItem);
        navView.MenuItems.Add(generalItem);

        navView.SelectionChanged += (_, e) =>
        {
            if (e.SelectedItem is NavigationViewItem item && item.Tag is Type pageType)
            {
                var page = (Page?)Activator.CreateInstance(pageType);
                if (page != null)
                {
                    navView.Content = page;
                }
            }
        };

        Content = navView;
    }
}
