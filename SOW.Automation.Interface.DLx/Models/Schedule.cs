using System;
using System.Collections.Generic;
namespace SOW.Automation.Interface.DLx.Models
{
	public class Schedule
	{
		public ICollection<Shipment> Shipments { get; set; }
	}
}
