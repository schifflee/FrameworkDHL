using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using SOW.Automation.Common.Web;
using SOW.Automation.Common.Desktop;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SOW.Automation.Driver.Selenium
{
	public class SeleniumAutomate<T> :
        DriverBase,
         IWebBaseElement<T> where T : IWebElement
	{
		private WebDriverContextInfo _driverContextInfo;

		public WebDriverContextInfo DriverContextInfo {
			get { return _driverContextInfo; }
			set { _driverContextInfo = value; }
		}

		private IWebDriver _webDriver;

		public IWebDriver WebDriver {
			get { return _webDriver; }
			set { _webDriver = value; }
		}

		public SeleniumAutomate(WebDriverContextInfo config)
		{
			try {
				this.DriverContextInfo = config;
				InicializeDriver(this.DriverContextInfo.Timeout);
			} catch (Exception) {
				throw;
			}
		}

		public void AcceptAlert(int timeout)
		{
			try {
				var wait = new WebDriverWait(this.WebDriver, TimeSpan.FromSeconds(timeout))
                    .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
				var alert = WebDriver.SwitchTo().Alert();
				alert.Accept();
			} catch (Exception) {
				throw;
			}
		}

		public void CloseProcess(int timeout)
		{
			try {
				this.WebDriver.Close();
			} catch (Exception) {
				throw;
			}
		}

		public void DismissAlert(int timeout)
		{
			try {
				var wait = new WebDriverWait(this.WebDriver, TimeSpan.FromSeconds(timeout))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
				var alert = WebDriver.SwitchTo().Alert();
				alert.Dismiss();
			} catch (Exception) {
				throw;
			}
		}

		public void InicializeDriver(int timeout)
		{
			try {
				switch (this.DriverContextInfo.Browser) {
					case BrowserEnum.Chrome:
						this.WebDriver = new ChromeDriver(this.DriverContextInfo.Path);
						//this.WebDriver = new ChromeDriver(this.DriverContextInfo.Path, new ChromeOptions(), TimeSpan.FromSeconds(180));
						break;
					case BrowserEnum.Edge:
						this.WebDriver = new EdgeDriver(this.DriverContextInfo.Path);
						break;
					case BrowserEnum.FireFox:
						//this.WebDriver = new FirefoxDriver(new FirefoxBinary(this.DriverContextInfo.Path), new FirefoxProfile(), TimeSpan.FromSeconds(180));
						this.WebDriver = new FirefoxDriver(this.DriverContextInfo.Path);
						break;
					case BrowserEnum.InternetExplorer:
						this.WebDriver = new InternetExplorerDriver(this.DriverContextInfo.Path);
						break;
					default:
						this.WebDriver = new ChromeDriver(this.DriverContextInfo.Path);
						break;
				}
				if (this.DriverContextInfo.MaximizeWindow) this.WebDriver.Manage().Window.Maximize();
			} catch (Exception) {
				throw;
			}
		}

		public void InicializeDriver(string path, int timeout)
		{
			try {
				switch (this.DriverContextInfo.Browser) {
					case BrowserEnum.Chrome:
						this.WebDriver = new ChromeDriver(path);
						break;
					case BrowserEnum.Edge:
						this.WebDriver = new EdgeDriver(path);
						break;
					case BrowserEnum.FireFox:
						this.WebDriver = new FirefoxDriver(path);
						break;
					case BrowserEnum.InternetExplorer:
						this.WebDriver = new InternetExplorerDriver(path);
						break;
					default:
						this.WebDriver = new ChromeDriver(path);
						break;
				}
			} catch (Exception) {
				throw;
			}
		}

		public void InsertTextByID(string fieldID, string inputText, int timeout)
		{
			try {
				new WebDriverWait(this.WebDriver, TimeSpan.FromSeconds(timeout))
                    .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible((By.Id(fieldID)))).SendKeys(inputText);
			} catch (Exception) {
				throw;
			}
		}

		public void InsertTextByName(string fieldName, string inputText, int timeout)
		{
			try {
				new WebDriverWait(this.WebDriver, TimeSpan.FromSeconds(timeout))
                    .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible((By.Name(fieldName)))).SendKeys(inputText);
			} catch (Exception) {
				throw;
			}
		}

		public void InsertTextByClassName(string fieldClassName, string inputText, int timeout)
		{
			try {
				var wait = new WebDriverWait(this.WebDriver, TimeSpan.FromSeconds(timeout))
                 .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible((By.ClassName(fieldClassName))));
				wait.SendKeys(inputText);
			} catch (Exception) {
				throw;
			}
		}
		
		public void MaximizeWindow(int timeout)
		{
			try {
				this.WebDriver.Manage().Window.Maximize();
			} catch (Exception) {
				throw;
			}
		}

		public void QuitProcess(int timeout)
		{
			try {
				this.WebDriver.Quit();
			} catch (Exception) {
				throw;
			}
		}

		public void OpenURL(string url, int timeout)
		{
			try {
				this.WebDriver.Navigate().GoToUrl(url);
			} catch (Exception) {
				throw;
			}
		}

		public void SearchAndClickByID(string ID, int timeout)
		{
			try {
				var wait = new WebDriverWait(this.WebDriver, TimeSpan.FromSeconds(timeout))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable((By.Id(ID))));
				wait.Click();
			} catch (Exception) {
				throw;
			}
		}

		public void SearchAndClickByCss(string cssSelector, int timeout)
		{

			try {
				var wait = new WebDriverWait(this.WebDriver, TimeSpan.FromSeconds(timeout))
                   .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable((By.CssSelector(cssSelector))));
				wait.Click();
			} catch (Exception) {
				throw;
			}
		}

		public T SearchAndReturnByID(string ID, int timeout)
		{
			try {
				return (T)new WebDriverWait(this.WebDriver, TimeSpan.FromSeconds(timeout))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible((By.Id(ID))));
			} catch (Exception) {
				// A FAZER : IMPLEMENTAÇÃO DE LOG
				return default(T);
			}
		}

		public T SearchAndReturnByTagName(string tag, int timeout)
		{
			try {
				return (T)new WebDriverWait(this.WebDriver, TimeSpan.FromSeconds(timeout))
                    .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible((By.TagName(tag))));
			} catch (Exception) {

				throw;
			}
		}

		public void TakeDefaultWindow(int timeout)
		{
			try {
				throw new NotImplementedException();
			} catch (Exception) {
				throw;
			}
		}

		public void TakeScreenshot(string path, string name, bool printTimeSpan, int timeout)
		{
			try {
				throw new NotImplementedException();
			} catch (Exception) {
				throw;
			}
		}
	}
}
