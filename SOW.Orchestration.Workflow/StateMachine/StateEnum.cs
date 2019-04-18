namespace SOW.Orchestration.Workflow.StateMachine
{
	public enum StateEnum
	{
		Exception = -1,
		Waiting = 0,
		Started = 1,
		Processing = 2,
		Finished = 3,
		Stopped = 4,
		Cancelled = 5
	}
}
