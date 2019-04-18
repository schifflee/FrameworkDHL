using System;
using System.Collections.Generic;
using Sikuli4Net.sikuli_REST;
using Sikuli4Net.sikuli_UTIL;
using SOW.Automation.Common.OCR;

namespace SOW.Automation.Driver.Sikuli
{
	public class SikuliAutomate<T> : IOCRBaseElement<T>
	{
		private APILauncher _application;
		public APILauncher Application { get { return _application; } set { _application = value; } }
		
		private Screen _screen;
		public Screen Screen { get { return _screen; } set { _screen = value; } }
		
		private double _matching ;
		public double Matching { get { return _matching ; } set { _matching = value; } }

		private OCRDriverContextInfo _driverContextInfo;
		public OCRDriverContextInfo DriverContextInfo { get { return _driverContextInfo; } set { _driverContextInfo = value; } }

		public SikuliAutomate(OCRDriverContextInfo config)
		{
			try {
				this.DriverContextInfo = config;
				this.InitializeDriver(this.DriverContextInfo.Timeout);
			} catch (System.Exception) {
				throw;
			}
		}
		
		public bool CheckPattern(object pattern, double matching = 0.85, int timeout = 30)
		{
			try {
            	this.Screen = new Screen();
            	//this.Screen.Wait((Pattern)pattern, timeout);
            	this.Screen.Wait(new Pattern(((Pattern)pattern).ImagePath, matching), timeout);
            	return true;
			} catch (Exception) {
				return false;
			}
		}
		
		public void ClickPattern(object pattern, double matching = 0.85, int timeout = 30)
		{
			try {
            	this.Screen = new Screen();
            	//this.Screen.Click((Pattern)pattern, true);
            	this.Screen.Click(new Pattern(((Pattern)pattern).ImagePath, matching), true);
			} catch (Exception) {
				throw;
			}
		}
		
		public void DragAndDrop(object patternClick, object patternDrop, int timeout)
		{
			try {
            	this.Screen = new Screen();
            	this.Screen.DragDrop((Pattern)patternClick, (Pattern)patternDrop);
			} catch (Exception) {
				throw;
			}
		}
		
		public bool Exists(int timeout)
		{
			try {
				this.Application.VerifyJarExists();
				return true;
			} catch (Exception) {
				return false;
			}
		}
		
		public void InitializeDriver(int timeout)
		{
			try {
            	this.Application = new APILauncher(true);
			} catch (Exception) {
				throw;
			}
		}
	}
}