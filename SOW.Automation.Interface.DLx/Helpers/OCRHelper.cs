using Sikuli4Net.sikuli_REST;
using SOW.Automation.Common;
using SOW.Automation.Common.Desktop;
using SOW.Automation.Common.OCR;
using SOW.Automation.Common.Web;
using SOW.Automation.Service.Desktop;
using SOW.Automation.Service.OCR;
using SOW.Automation.Service.Web;
using System;
namespace SOW.Automation.Interface.DLx.Helpers
{
	public class OCRHelper
	{
		public string Root { get; set; }
		public string Folder { get; set; }
		public string SubFolder { get; set; }
		public string WindowPath { get; set; }
		public string ImagePath { get; set; }
		public string FileExtension { get; set; }
		public OCRHelper(string root, string folder = "OCR", string subFolder = "RedPrairie", string windowPath = "Main", string imagePath = "OK", string fileExtension = "png")
		{
			try {
				this.Root = root;
				this.Folder = folder;
				this.SubFolder = subFolder;
				this.WindowPath = windowPath;
				this.ImagePath = imagePath;
				this.FileExtension = fileExtension;
			} catch {
				throw;
			}
		}
		
		public Pattern GetPattern(string imagePath = "OK", string fileExtension = "png")
		{
			try {
				return new Pattern(String.Concat(this.Root, @"\", this.Folder, @"\", this.SubFolder, @"\", this.WindowPath, @"\", imagePath, ".", fileExtension));
			} catch {
				throw;
			}
		}
		
		public Pattern GetPattern(string imagePath = "OK")
		{
			try {
				return new Pattern(String.Concat(this.Root, @"\", this.Folder, @"\", this.SubFolder, @"\", this.WindowPath, @"\", imagePath, ".", this.FileExtension));
			} catch {
				throw;
			}
		}
		
		public Pattern GetPattern()
		{
			try {
				return new Pattern(String.Concat(this.Root, @"\", this.Folder, @"\", this.SubFolder, @"\", this.WindowPath, @"\", this.ImagePath, ".", this.FileExtension));
			} catch {
				throw;
			}
		}
	}
}
