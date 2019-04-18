namespace SOW.Automation.Interface.DLx.Helpers
{
	public static class WindowHelper
	{
		public static bool WindowLocate(Interface.DLx.Windows.WindowBase window, string value)
		{
			try {
				bool response = true;
				LocateButtonClick(window);
				LocateFieldClick(window);
				LocateFieldFill(window, value);
				LocateButtonGoClick(window);
				LocateResultLabelClick(window);
				LocateButtonOkClick(window);
				return response;
			} catch (System.Exception e) {
				System.Console.WriteLine("Unexpected action: " + e.Message);
				return false;
			}
		}
		
		public static void ButtonCloseClick(Interface.DLx.Windows.WindowBase window)
		{
			try {
				window.WindowClick("Close");
			} catch (System.Exception e) {
				throw;
			}
		}
		
		public static void LocateButtonGoClick(Interface.DLx.Windows.WindowBase window)
		{
			try {
				window.WindowClick("LocateGo");
			} catch (System.Exception e) {
				throw;
			}
		}
		
		public static void LocateButtonOkClick(Interface.DLx.Windows.WindowBase window)
		{
			try {
				window.WindowClick("LocateOk");
			} catch (System.Exception e) {
				throw;
			}
		}
		
		public static void LocateButtonClick(Interface.DLx.Windows.WindowBase window)
		{
			try {
				window.WindowClick("Locate");
			} catch (System.Exception e) {
				throw;
			}
		}
		
		public static void ButtonYesClick(Interface.DLx.Windows.WindowBase window)
		{
			try {
				window.WindowClick("Yes");
			} catch (System.Exception e) {
				throw;
			}
		}
		
		public static void HeaderClick(Interface.DLx.Windows.WindowBase window)
		{
			try {
				window.WindowClick("WindowHeader");
			} catch (System.Exception e) {
				throw;
			}
		}
		
		public static void LocateFieldClick(Interface.DLx.Windows.WindowBase window)
		{
			try {
				window.WindowClick("LocateSearch");
			} catch (System.Exception e) {
				throw;
			}
		}
		
		public static void LocateResultLabelClick(Interface.DLx.Windows.WindowBase window, int option = 1)
		{
			try {
				int positionY = 120 + (20 * option);
				window.PointAndClick(240, positionY);
			} catch (System.Exception e) {
				throw;
			}
		}
		
		public static void LocateFieldFill(Interface.DLx.Windows.WindowBase window, string value = "")
		{
			try {
				window.InsertText(value);
			} catch (System.Exception e) {
				throw;
			}
		}
	}
}
