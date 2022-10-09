using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Farplane.Common;
using Farplane.Common.Dialogs;
using Farplane.FFX.Data;
using Farplane.FFX.Values;
using Farplane.Memory;
using MahApps.Metro.Controls;

namespace Farplane.FFX.EditorPanels.Debug
{
    /// <summary>
    ///     Interaction logic for DebugPanel.xaml
    /// </summary>
    public partial class DebugPanel : UserControl
    {

        private bool _refreshing = false;

        public DebugPanel()
		{
            InitializeComponent();
            _refreshing = true;
            _refreshing = false;
        }

        public void Refresh()
        {
            _refreshing = true;
            _refreshing = false;
        }

		private void UnknownFlags_Checked(object sender, RoutedEventArgs e)
		{
            var cb = (CheckBox)sender;
            SetUnknownVisibility(cb.IsChecked ?? false);
		}

        private void SetUnknownVisibility(bool visible)
		{
            UnknownWarning.Visibility = visible ? Visibility.Visible : Visibility.Hidden;
            Unknown01.Visibility = visible ? Visibility.Visible : Visibility.Hidden;
            Unknown02.Visibility = visible ? Visibility.Visible : Visibility.Hidden;
            Unknown03.Visibility = visible ? Visibility.Visible : Visibility.Hidden;
            Unknown04.Visibility = visible ? Visibility.Visible : Visibility.Hidden;
            Unknown05.Visibility = visible ? Visibility.Visible : Visibility.Hidden;
            Unknown06.Visibility = visible ? Visibility.Visible : Visibility.Hidden;
            Unknown07.Visibility = visible ? Visibility.Visible : Visibility.Hidden;
            Unknown08.Visibility = visible ? Visibility.Visible : Visibility.Hidden;
            Unknown09.Visibility = visible ? Visibility.Visible : Visibility.Hidden;
            Unknown10.Visibility = visible ? Visibility.Visible : Visibility.Hidden;
            Unknown11.Visibility = visible ? Visibility.Visible : Visibility.Hidden;
            Unknown12.Visibility = visible ? Visibility.Visible : Visibility.Hidden;
            Unknown13.Visibility = visible ? Visibility.Visible : Visibility.Hidden;
            Unknown14.Visibility = visible ? Visibility.Visible : Visibility.Hidden;
            Unknown15.Visibility = visible ? Visibility.Visible : Visibility.Hidden;
            Unknown16.Visibility = visible ? Visibility.Visible : Visibility.Hidden;
            Unknown17.Visibility = visible ? Visibility.Visible : Visibility.Hidden;
            Unknown18.Visibility = visible ? Visibility.Visible : Visibility.Hidden;
            Unknown19.Visibility = visible ? Visibility.Visible : Visibility.Hidden;
        }
    }
}