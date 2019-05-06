using System;
using System.Threading;
using SOW.Automation.Common.Desktop;
using SOW.Automation.Common.Web;
using System.Collections.Generic;
using SOW.Automation.Service.Desktop;
using SOW.Automation.Service.Web;
namespace SOW.Automation.Interface.DLx.Pages
{
	public class LoginPageHml : PageBase
	{
		public LoginPageHml(WebDriverContextInfo driverContextInfo, DesktopDriverContextInfo desktopDriverContextInfo)
			: base(driverContextInfo, desktopDriverContextInfo)
		{
		}
		public LoginPageHml(WebService webservice, DesktopService desktopService)
			: base(webservice, desktopService)
		{
		}
		
		public void EfetuarLogin(string usuario, string senha, int timeout)
		{
			//ClicarBotaoProtocolo(timeout);
			
			PreencherCampoTextoUsuario(usuario);
			PreencherCampoTextoSenha(senha);
			ClicarBotaoLogin(timeout);
		}
		
		private void PreencherCampoTextoUsuario(string value)
		{
			this.WebAutomationService.BaseElement.InsertTextByID("mat-input-0", value, this.WebAutomationService.DriverContextInfo.Timeout);
		}
		private void PreencherCampoTextoSenha(string value)
		{
			this.WebAutomationService.BaseElement.InsertTextByID("mat-input-1", value, this.WebAutomationService.DriverContextInfo.Timeout);
		}
		private void ClicarBotaoLogin(int timeout)
		{
			this.WebAutomationService.BaseElement.SearchAndClickByID("loginBtn", timeout);
		}
		
		private void ClicarBotaoProtocolo(int timeout)
		{
			this.WebAutomationService.BaseElement.SearchAndClickByID("protocolhandler-welcome-installButton", timeout);
			Thread.Sleep(5000);
			
			if (this.DeskAutomationService.BaseElement.SearchSubElementVisible("Citrix Receiver - Google Chrome","Open Citrix Receiver Launcher", this.DeskAutomationService.DriverContextInfo.Timeout)) {
				DeskAutomationService.BaseElement.PressKey(SOW.Automation.Common.KeyboardEnum.TAB, 0);
		
				DeskAutomationService.BaseElement.PressKey(SOW.Automation.Common.KeyboardEnum.SPACE, 0);
	
				DeskAutomationService.BaseElement.PressKey(SOW.Automation.Common.KeyboardEnum.TAB, 0);
       
				DeskAutomationService.BaseElement.PressKey(SOW.Automation.Common.KeyboardEnum.RETURN, 0);
			}
			
		}
	}
}
