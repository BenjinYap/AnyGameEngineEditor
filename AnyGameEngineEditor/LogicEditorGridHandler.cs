using AnyGameEngine;
namespace AnyGameEngineEditor {
	public abstract class LogicEditorGridHandler {
		protected PropertyGrid Grid;
		protected LogicBase Logic;

		public LogicEditorGridHandler SetGrid (PropertyGrid grid) {
			Grid = grid;
			return this;
		}

		public virtual void PopulateGrid (LogicBase logic) {
			Logic = logic;
		}
	}
}
