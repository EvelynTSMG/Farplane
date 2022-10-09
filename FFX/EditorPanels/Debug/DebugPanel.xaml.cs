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
using Farplane.FFX2;
using Farplane.Memory;
using MahApps.Metro.Controls;

namespace Farplane.FFX.EditorPanels.Debug
{
    /// <summary>
    ///     Interaction logic for DebugPanel.xaml
    /// </summary>
    public partial class DebugPanel : UserControl
    {

        private bool refreshing = false;
		private Dictionary<CheckBox, DebugFlags> checkFlagDict = new Dictionary<CheckBox, DebugFlags>();

        public DebugPanel()
		{
            InitializeComponent();
			checkFlagDict = new Dictionary<CheckBox, DebugFlags>() {
				{ CheckPartyInvincible, DebugFlags.PartyInvincible },
				{ CheckEnemiesInvincible, DebugFlags.EnemyInvincible },
				{ CheckControlEnemies, DebugFlags.EnemyInput },
				{ CheckLockBattleCam, DebugFlags.LockBattleCamera },
				{ CheckAlwaysOverdrive, DebugFlags.AlwaysOverdrive },
				{ CheckCrits, DebugFlags.AlwaysCritical },
				{ CheckNoCrits, DebugFlags.DisableCriticalHit },
				{ CheckNoRandomDmg, DebugFlags.DisableRandomDamage },
				{ CheckDamage1, DebugFlags.AlwaysDeal1 },
				{ CheckDamage9999, DebugFlags.AlwaysDeal10000 },
				{ CheckDamage99999, DebugFlags.AlwaysDeal99999 },
				{ CheckDreamLuck, DebugFlags.AlwaysRareDrop },
				{ CheckAPx100, DebugFlags.Ap100X },
				{ CheckGilx100, DebugFlags.Gil100X },
				{ CheckAlwaysInfo, DebugFlags.PermanentSensor },
				{ Unknown01, DebugFlags.Unknown1 },
				{ Unknown02, DebugFlags.Unknown2 },
				{ Unknown03, DebugFlags.Unknown3 },
				{ Unknown04, DebugFlags.Unknown4 },
				{ Unknown05, DebugFlags.Unknown5 },
				{ Unknown06, DebugFlags.Unknown6 },
				{ Unknown07, DebugFlags.Unknown7 },
				{ Unknown08, DebugFlags.Unknown8 },
				{ Unknown09, DebugFlags.Unknown9 },
				{ Unknown11, DebugFlags.Unknown11 },
				{ Unknown12, DebugFlags.Unknown12 },
				{ Unknown13, DebugFlags.Unknown13 },
				{ Unknown14, DebugFlags.Unknown14 },
				{ Unknown15, DebugFlags.Unknown15 },
				{ Unknown16, DebugFlags.Unknown16 },
				{ Unknown17, DebugFlags.Unknown17 },
				{ Unknown18, DebugFlags.Unknown18 },
				{ Unknown19, DebugFlags.Unknown19 },
				{ Unknown20, DebugFlags.Unknown20 },
			};
        }

		public void Refresh()
		{
			refreshing = true;
			
			foreach(var pair in checkFlagDict) {
				pair.Key.IsChecked = LegacyMemoryReader.ReadByteFlag((int)pair.Value);
			}

			refreshing = false;
		}

		private void CheckBox_Changed(object sender, RoutedEventArgs e)
		{
			if (refreshing) return;

			var checkBox = (CheckBox)sender;
			byte[] checkedBytes = checkBox.IsChecked == true ? new byte[] { 1 } : new byte[] { 0 };

			try
			{
				LegacyMemoryReader.WriteBytes(Offsets.GetOffset(OffsetType.DebugFlags) + (int)checkFlagDict[checkBox], checkedBytes);
			}
			catch { }
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
			Unknown20.Visibility = visible ? Visibility.Visible : Visibility.Hidden;
		}
    }
}