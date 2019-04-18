namespace SOW.Automation.Common.Web
{
	public interface IWebBaseElement<T>
	{
        void AcceptAlert(int timeout);
	    void CloseProcess(int timeout);
        void DismissAlert(int timeout);
        void InicializeDriver(int timeout);
        void InsertTextByID(string fieldId, string insertText, int timeout);
        void InsertTextByName(string fieldName, string insertText, int timeout);
        void InsertTextByClassName(string fieldClassName, string insertText, int timeout);
        void MaximizeWindow(int timeout);
        void OpenURL(string url, int timeout);
        void QuitProcess(int timeout);
        void SearchAndClickByID(string ID, int timeout);
           T SearchAndReturnByID(string ID, int timeout);
        void SearchAndClickByCss(string cssSelector, int timeout);
        void TakeDefaultWindow(int seconds);
        void TakeScreenshot(string path, string name, bool printTimeSpan, int timeout);
	}
}
