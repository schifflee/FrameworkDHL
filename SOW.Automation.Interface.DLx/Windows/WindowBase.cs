using Sikuli4Net.sikuli_REST;
using SOW.Automation.Common;
using SOW.Automation.Common.Desktop;
using SOW.Automation.Common.OCR;
using SOW.Automation.Common.Web;
using SOW.Automation.Interface.DLx.Helpers;
using SOW.Automation.Service.Desktop;
using SOW.Automation.Service.OCR;
using SOW.Automation.Service.Web;
using System;
namespace SOW.Automation.Interface.DLx.Windows
{
    public class WindowBase
    {
        public WebService WebAutomationService { get; set; }
        public DesktopService DeskAutomationService { get; set; }
        public OCRService OCRAutomationService { get; set; }
        public OCRHelper OCRHelper { get; set; }

        public WindowBase(WebService webService, DesktopService desktopService, OCRService ocrService)
        {
            this.WebAutomationService = webService;
            this.DeskAutomationService = desktopService;
            this.OCRAutomationService = ocrService;
        }

        public virtual void ApplicationClose()
        {
            this.WebAutomationService.BaseElement.QuitProcess(this.WebAutomationService.DriverContextInfo.Timeout);
        }

        public virtual void InsertText(string value)
        {
            this.DeskAutomationService.BaseElement.EnterKeys(value, 0);
        }

        public virtual void KeyboardHold(KeyboardEnum key)
        {
            this.DeskAutomationService.BaseElement.HoldKey(key, this.DeskAutomationService.DriverContextInfo.Timeout);
        }

        public virtual void KeyboardLeave(KeyboardEnum key)
        {
            this.DeskAutomationService.BaseElement.LeaveKey(key, this.DeskAutomationService.DriverContextInfo.Timeout);
        }

        public virtual void KeyboardPress(KeyboardEnum key)
        {
            this.DeskAutomationService.BaseElement.PressKey(key, this.DeskAutomationService.DriverContextInfo.Timeout);
        }

        public virtual void MaximizeWindow()
        {
            this.DeskAutomationService.BaseElement.HoldKey(SOW.Automation.Common.KeyboardEnum.LWIN, this.DeskAutomationService.DriverContextInfo.Timeout);
            this.DeskAutomationService.BaseElement.PressKey(SOW.Automation.Common.KeyboardEnum.UP, this.DeskAutomationService.DriverContextInfo.Timeout);
            this.DeskAutomationService.BaseElement.LeaveKey(SOW.Automation.Common.KeyboardEnum.LWIN, this.DeskAutomationService.DriverContextInfo.Timeout);
            this.DeskAutomationService.BaseElement.WaitWhileBusy(0);
        }

        public virtual void MouseRightClick()
        {
            try
            {
                this.DeskAutomationService.BaseElement.MouseRightClick(this.DeskAutomationService.DriverContextInfo.Timeout);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public virtual void MouseLeftClick()
        {
            try
            {
                this.DeskAutomationService.BaseElement.MouseLeftClick(this.DeskAutomationService.DriverContextInfo.Timeout);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public virtual void PointAndClick(double x, double y)
        {
            try
            {
                this.DeskAutomationService.BaseElement.SetMousePosition(x, y, this.DeskAutomationService.DriverContextInfo.Timeout);
                this.DeskAutomationService.BaseElement.MouseLeftClick(this.DeskAutomationService.DriverContextInfo.Timeout);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual void WhereIsTheMouse()
        {
            //this.DeskAutomationService.BaseElement.ShowMousePosition(this.DeskAutomationService.DriverContextInfo.Timeout);
            //this.DeskAutomationService.BaseElement.Wait(500, this.DeskAutomationService.DriverContextInfo.Timeout);
        }

        public virtual void Wait(int miliseconds)
        {
            try
            {
                this.DeskAutomationService.BaseElement.Wait(miliseconds, this.DeskAutomationService.DriverContextInfo.Timeout);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual bool WindowCheck(string imagePath)
        {
            try
            {
                return this.OCRAutomationService.BaseElement.CheckPattern(this.OCRHelper.GetPattern(imagePath), this.OCRAutomationService.DriverContextInfo.Matching, this.OCRAutomationService.DriverContextInfo.Timeout);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual void WindowClick()
        {
            try
            {
                this.DeskAutomationService.BaseElement.WindowClick(this.DeskAutomationService.DriverContextInfo.Timeout);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual void WindowClick(string imagePath)
        {
            try
            {
                this.OCRAutomationService.BaseElement.ClickPattern(this.OCRHelper.GetPattern(imagePath), this.OCRAutomationService.DriverContextInfo.Matching, this.OCRAutomationService.DriverContextInfo.Timeout);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual void WindowClose()
        {
            try
            {
                this.DeskAutomationService.BaseElement.CloseWindow(this.DeskAutomationService.DriverContextInfo.Timeout);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual void WindowFocus()
        {
            try
            {
                this.DeskAutomationService.BaseElement.WindowFocus(this.DeskAutomationService.DriverContextInfo.Timeout);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual void WindowOpen(string title)
        {
            try
            {
                this.DeskAutomationService.BaseElement.OpenDesktopInstance(title, this.DeskAutomationService.DriverContextInfo.Timeout);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual void WindowSelect()
        {
            try
            {
                this.WindowClick();
                this.WindowFocus();
                this.DeskAutomationService.BaseElement.WaitWhileBusy(this.DeskAutomationService.DriverContextInfo.Timeout);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
