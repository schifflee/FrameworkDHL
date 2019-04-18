/*
 * Created by SharpDevelop.
 * User: managsow
 * Date: 22/11/2018
 * Time: 14:32
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using SOW.Automation.Common.Desktop;
using SOW.Automation.Common.Web;
using SOW.Automation.Service.Desktop;
using SOW.Automation.Service.Web;

namespace SOW.Automation.Interface.DLx.Pages
{
	/// <summary>
	/// Description of LoginPage.
	/// </summary>
	public class LoginPage : PageBase
	{

        public LoginPage(WebDriverContextInfo driverContextInfo, DesktopDriverContextInfo desktopDriverContextInfo) : base(driverContextInfo, desktopDriverContextInfo){}
		public LoginPage(WebService webservice, DesktopService desktopService) : base(webservice, desktopService) { }	
		
		public void EfetuarLogin(string usuario, string senha, int timeout)
		{
			PreencherCampoTextoUsuario(usuario);
			PreencherCampoTextoSenha(senha);
			ClicarBotaoLogin(timeout);
		}
		
		private void PreencherCampoTextoUsuario(string value)
		{
			this.WebAutomationService.BaseElement.InsertTextByID("user",value,this.WebAutomationService.DriverContextInfo.Timeout);
		}
		private void PreencherCampoTextoSenha(string value)
		{
			this.WebAutomationService.BaseElement.InsertTextByID("password",value,this.WebAutomationService.DriverContextInfo.Timeout);
		}		
		private void ClicarBotaoLogin(int timeout)
		{
			this.WebAutomationService.BaseElement.SearchAndClickByID("btnLogin",timeout);
		}
	}
}
