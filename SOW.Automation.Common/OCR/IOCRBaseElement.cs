using System;
namespace SOW.Automation.Common.OCR
{
	public interface IOCRBaseElement<T>
	{
		bool CheckPattern(object pattern, double matching = 0.85, int timeout = 30);
		
		void ClickPattern(object pattern, double matching = 0.85, int timeout = 30);
		
		void DragAndDrop(object patternClick, object patternDrop, int timeout);
		
		bool Exists(int timeout);
		
		void InitializeDriver(int timeout);
	}
}
