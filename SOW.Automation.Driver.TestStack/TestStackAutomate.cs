using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Automation;
using SOW.Automation.Common;
using SOW.Automation.Common.Desktop;
using TestStack.White;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.Utility;
using TestStack.White.WindowsAPI;


namespace SOW.Automation.Driver.TestStack
{
	public class TestStackAutomate<T> :  IDesktopBaseElement<T> where T : IUIItem
	{
		private Application _application;
		public Application Application { get { return _application; } set { _application = value; } }

		private Window _window;
		public Window Window { get { return _window; } set { _window = value; } }

		private DesktopDriverContextInfo _driverContextInfo;
		public DesktopDriverContextInfo DriverContextInfo { get { return _driverContextInfo; } set { _driverContextInfo = value; } }

		public TestStackAutomate(DesktopDriverContextInfo config)
		{
			try {
				this.DriverContextInfo = config;
				if (!string.IsNullOrWhiteSpace(this.DriverContextInfo.Path))
					InitializeDriver(this.DriverContextInfo.Path, this.DriverContextInfo.Timeout);
				else
					InitializeDriver(this.DriverContextInfo.Timeout);
                	
			} catch (System.Exception) {
				throw;
			}
		}

		public void CloseProcess(int timeout)
		{
			try {
				this.Application.Close();
			} catch (System.Exception) {
				throw;
			}
		}

		public void CloseWindow(int timeout)
		{
			try {
				this.Window.Close();
			} catch (System.Exception) {
				throw;
			}
		}

		public void CloseWindow(string title, int timeout)
		{
			try {
				this.Application.GetWindow(title).Close();
			} catch (System.Exception) {
				throw;
			}
		}

		public void EnterKeys(string keys, int timeout)
		{
			if (this.Window != null)
				this.Window.Keyboard.Enter(keys);
			else
				Keyboard.Instance.Enter(keys);
		}

		public void FieldFocus(T element, int timeout)
		{
			try {
				element.Focus();
			} catch (Exception) {
				throw;
			}
		}
		
		public string GetClipboardText(int timeout)
		{
			try {
				string value = String.Empty;
				Thread staThread = new Thread(() => value = System.Windows.Forms.Clipboard.GetText());
				staThread.SetApartmentState(ApartmentState.STA);
				staThread.Start();
				staThread.Join();
				return value;
			} catch {
				return GetClipboardText(timeout);
			}
		}
        
		public double GetMousePositionX(int timeout)
		{
			try {
				return this.Window.Mouse.Location.X;
			} catch (Exception) {
				throw;
			}
		}
        
		public double GetMousePositionY(int timeout)
		{
			try {
				return this.Window.Mouse.Location.Y;
			} catch (Exception) {
				throw;
			}
		}

		public void HoldKey(KeyboardEnum key, int timeout)
		{
			try {
				if (this.Window != null)
					this.Window.Keyboard.HoldKey((global::TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys)key);
				else
					Keyboard.Instance.HoldKey((global::TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys)key);
			} catch (Exception) {
				throw;
			}
        		
		}

		public void InitializeDriver(int timeout)
		{ 
        	
		}

		public void InitializeDriver(string fullPath, int timeout)
		{
			try {
				this.Application = Application.AttachOrLaunch(new System.Diagnostics.ProcessStartInfo(fullPath));
			} catch (System.Exception) {
				throw;
			}
		}

		public void InsertTextByClassName(string fieldClassName, string insertText, int timeout)
		{
			try {
				Window.GetElement(SearchCriteria.ByClassName(fieldClassName));
				this.Window.Keyboard.Enter(insertText);
			} catch (System.Exception) {
				throw;
			}
		}

		public void InsertTextByID(string fieldID, string insertText, int timeout)
		{
			try {
				this.Window.GetElement(SearchCriteria.ByAutomationId(fieldID));
				this.Window.Keyboard.Enter(insertText);
			} catch (System.Exception) {
				throw;
			}
		}

		public void InsertTextByName(string fieldName, string insertText, int timeout)
		{
			throw new System.NotImplementedException();
			//
			//try
			//{
			//    this.Window.GetElement(SearchCriteria.(fieldName)).SetFocus();
			//    this.Window.Keyboard.Enter(inputText);
			//}
			//catch (System.Exception)
			//{
			//    throw;
			//}
		}

		public void InsertTextByText(string fieldText, string insertText, int timeout)
		{
			try {
				this.Window.GetElement(SearchCriteria.ByText(fieldText)).SetFocus();
				this.Window.Keyboard.Enter(insertText);
			} catch (System.Exception) {
				throw;
			}
		}

		public void LeaveKey(KeyboardEnum key, int timeout)
		{
			try {
				if (this.Window != null)
					this.Window.Keyboard.LeaveKey((global::TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys)key);
				else
					Keyboard.Instance.LeaveKey((global::TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys)key);
			} catch (Exception) {
				throw;
			}
        		
		}
        
		public void MouseLeftClick(int timeout)
		{
			try {
				Mouse.Instance.Click();	
			} catch (Exception) {
				throw;
			}
        	
		}
        
		public void MouseRightClick(int timeout)
		{
			try {
				Mouse.Instance.RightClick();
			} catch (Exception) {
				throw;
			}
		}

		public void OpenApplication(string fullPath, int timeout)
		{
			try {
				this.Application = Application.AttachOrLaunch(new System.Diagnostics.ProcessStartInfo(fullPath));
			} catch (Exception) {
				throw;
			}
		}

		public void OpenDesktopInstance(string title, int timeout)
		{
			try {
				this.Window = Desktop.Instance.Windows().Find(x => x.Title.Equals(title)); 
			} catch (Exception) {
				this.OpenDesktopInstance(title, timeout);
			}
		}

		public void OpenWindow(string url, int timeout)
		{
			try {
				this.Window = this.Application.GetWindow(url);
			} catch (Exception) {
				throw;
			}
		}

		public void PressKey(KeyboardEnum key, int timeout)
		{
			try {
				if (this.Window != null)
					this.Window.Keyboard.PressSpecialKey((global::TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys)key);
				else
					Keyboard.Instance.PressSpecialKey((global::TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys)key);
			} catch (Exception) {
				throw;
			}	        	
		}

		public bool SearchSubElementVisible(string wTitle, string subWtitle, int timeout)
		{
			try {
				return Desktop.Instance.Windows().Find(s => s.Title == wTitle)
					.MdiChild(SearchCriteria.ByControlType(ControlType.Button).AndByText(subWtitle)).Visible;
			} catch (Exception) {
				throw;
			}
		}
        
		public void SearchAndClickByClassName(string fieldClassName, int timeout)
		{
			try {
				this.Window.Get<Button>(SearchCriteria.ByClassName(fieldClassName)).Click();
			} catch (System.Exception) {
				throw;
			}
		}

		public void SearchAndClickByID(string ID, int timeout)
		{
			try {
				this.Window.Get<Button>(SearchCriteria.ByAutomationId(ID)).Click();
			} catch (System.Exception) {
				throw;
			}
		}

		public void SearchAndClickByName(string fieldName, int timeout)
		{
			throw new NotImplementedException();
		}

		public void SearchAndClickByText(string inputText, int timeout)
		{
			try {
				this.Window.Get<Button>(SearchCriteria.ByText(inputText)).Click();
			} catch (System.Exception) {
				throw;
			}
		}

		public IList<T> SearchAndReturnByClassName(string fieldClassName, int timeout)
		{
			try {
				var elements = this.Window.GetMultiple(SearchCriteria.ByClassName(fieldClassName));
				IList<T> elementsList = new List<T>();
				foreach (var item in elements) {
					elementsList.Add((T)item);
				}
				return elementsList;
			} catch (System.Exception) {
				throw;
			}
		}

		public T SearchAndReturnByID(string ID, int timeout)
		{
			try {
				return this.Window.Get<T>(SearchCriteria.ByAutomationId(ID));
			} catch (System.Exception) {
				throw;
			}
		}

		public T SearchAndReturnByName(string fieldName, int timeout)
		{
			throw new NotImplementedException();
		}

		public T SearchAndReturnByText(string fieldText, int timeout)
		{
			try {
				return this.Window.Get<T>(SearchCriteria.ByText(fieldText));
			} catch (System.Exception) {
				throw;
			}
		}

		public T SearchAndReturnFirstByClassName(string fieldClassName, int timeout)
		{
			throw new NotImplementedException();
		}
		
		public void SetClipboardText(string value, int timeout)
		{
			try {
				Thread staThread = new Thread(() => System.Windows.Forms.Clipboard.SetText(value));
				staThread.SetApartmentState(ApartmentState.STA);
				staThread.Start();
				staThread.Join();
			} catch {
			}
		}
		
		public void SetMousePosition(double x, double y, int timeout)
		{
			try {
				this.Window.Mouse.Location = new System.Windows.Point(x, y);
			} catch (Exception) {
				throw;
			}
		}
        
		public void ShowMousePosition(int timeout)
		{
			try {
				this.Window.Keyboard.PressSpecialKey(global::TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.CONTROL);
			} catch (Exception) {
				throw;
			}
		}

		public void TakeDefaultWindow(int timeout)
		{
			try {
				this.Window.Click();
			} catch (System.Exception) {
				//throw;
			}
		}

		public void TakeScreenshot(string path, string name, bool printTimeSpan, int timeout)
		{
			try {
				this.Window.Keyboard.HoldKey(global::TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.LWIN);
				this.Window.Keyboard.PressSpecialKey(global::TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.PRINTSCREEN);
				this.Window.Keyboard.LeaveKey(global::TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.LWIN);
			} catch (System.Exception) {
				throw;
			}
		}

		public void Wait(int seconds, int timeout)
		{
			try {
				Thread.Sleep(seconds);
			} catch (Exception) {
				throw;
			}
		}

		public void WaitWhileBusy(int timeout)
		{
			try {
				this.Window.WaitWhileBusy();
			} catch (Exception) {
				//throw;
			}
		}

		public void WindowClick(int timeout)
		{
			try {
				this.Window.Click();
			} catch (System.Exception) {
				//throw;
			}
		}

		public bool WindowExists(string title, int timeout)
		{
			try {
				return (Desktop.Instance.Windows().Exists(s => s != null && s.Title == title));
			} catch {
				return false;
			}
		}

		public void WindowFocus(int timeout)
		{
			try {
				this.Window.Focus();
			} catch (System.Exception) {
				//throw;
			}
		}
	}
}
