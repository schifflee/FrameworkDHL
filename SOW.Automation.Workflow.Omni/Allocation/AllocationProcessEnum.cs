namespace SOW.Automation.Workflow.Omni.Allocation
{
	public enum AllocationProcessEnum
	{
		Exception = -1,
		Waiting = 0,
		InitializeContext = 1,
		InitializeServices = 2,
		WebProcess = 3,
		DesktopProcess = 4,
		Close = 5,
		Finish = 6
	}
}
