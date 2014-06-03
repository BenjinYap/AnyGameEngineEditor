using AnyGameEngine;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AnyGameEngineEditor {
	internal static class Helper {
		public static string GetZoneText (Zone zone) {
			return zone.ID + " (" + zone.Name + ")";
		}
	}
}
