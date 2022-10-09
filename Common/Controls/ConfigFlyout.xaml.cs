using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Farplane.Properties;
using MahApps.Metro;
using ControlzEx.Theming;
using MahApps.Metro.Controls;

namespace Farplane.Common.Controls
{
    /// <summary>
    /// Interaction logic for ConfigFlyout.xaml
    /// </summary>
    public partial class ConfigFlyout : Flyout
    {
        private bool canSetTheme = false;

        public ConfigFlyout()
        {
            InitializeComponent();

            ComboTheme.ItemsSource = new List<string> { "Light", "Dark" }; 
            ComboAccent.ItemsSource = new List<string> { "Red", "Green", "Blue", "Purple", "Orange", "Lime", "Emerald", "Teal", "Cyan", "Cobalt", "Indigo", "Violet", "Pink", "Magenta", "Crimson", "Amber", "Yellow", "Brown", "Olive", "Steel", "Mauve", "Taupe", "Sienna" };

			var currentTheme = ThemeManager.Current.ChangeTheme(Application.Current, Settings.Default.AppTheme);

            ComboTheme.SelectedIndex = currentTheme.Name.Split('.')[0] == "Light" ? 0 : 1;
            ComboAccent.SelectedIndex =
				new ThemeManager().Themes.Select(x => x.Name.Split('.')[1]).ToList().IndexOf(currentTheme.Name.Split('.')[1]);

			CheckNeverShowUnXWarning.IsChecked = Settings.Default.NeverShowUnXWarning;
            CheckCloseWithGame.IsChecked = Settings.Default.CloseWithGame;
            CheckShowAllProcesses.IsChecked = Settings.Default.ShowAllProcesses;
			

            canSetTheme = true;
        }

        private void ComboAccent_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!canSetTheme) return;
            ThemeManager.Current.ChangeTheme(Application.Current, $"{ComboTheme.SelectedItem}.{ComboAccent.SelectedItem}");
            SettingUpdated(sender, e);
        }

        private void SettingUpdated(object sender, RoutedEventArgs e)
        {
            if (!canSetTheme) return;
            Settings.Default.NeverShowUnXWarning = CheckNeverShowUnXWarning.IsChecked.Value;
            Settings.Default.CloseWithGame = CheckCloseWithGame.IsChecked.Value;
            Settings.Default.ShowAllProcesses = CheckShowAllProcesses.IsChecked.Value;
            Settings.Default.AppTheme = $"{ComboTheme.SelectedItem}.{ComboAccent.SelectedItem}";
			Settings.Default.Save();
        }
    }
}
