using System.Resources;
namespace AnyGameEngineEditor {
	static class Constants {
		public static string ID {get {return res.GetString ("id");}}
		public static string IDLogicDescription {get {return res.GetString ("idLogicDescription");}}
		public static string IDZoneDescription {get {return res.GetString ("idZoneDescription");}}
		public static string Text {get {return res.GetString ("text");}}
		public static string TextLogicTextDescription {get {return res.GetString ("textLogicTextDescription");}}

		private static ResourceManager res = new ResourceManager ("AnyGameEngineEditor.Resources.Strings", typeof (MainWindow).Assembly);
	}
}
