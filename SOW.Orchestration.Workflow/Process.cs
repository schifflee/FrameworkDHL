namespace SOW.Orchestration.Workflow
{
	public class Process
	{
		public string Name { get; set; }
		public int Step { get; set; }
		public System.Action Method { get; set; }
		public StateMachine.StateEnum State { get; set; }
	}
}
