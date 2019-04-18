using Sikuli4Net.sikuli_REST;
using SOW.Automation.Common;
using SOW.Automation.Common.OCR;
using SOW.Automation.Driver.Sikuli;

namespace SOW.Automation.Service.OCR
{
	public class OCRService
	{
        public OCRDriverContextInfo DriverContextInfo { get; set; }

        public IOCRBaseElement<Screen> BaseElement;

		public OCRService(OCRDriverContextInfo driverContextInfo)
		{
			this.DriverContextInfo = driverContextInfo;
			InitializeDriver();
		}

		private void InitializeDriver()
		{
			try {
				switch (this.DriverContextInfo.Driver) {
					case DriverEnum.Sikuli:
						BaseElement = new SikuliAutomate<Screen>(this.DriverContextInfo);
						break;
				}
			} catch (System.Exception) {
				throw;
			}
		}
	}
}
