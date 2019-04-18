namespace SOW.Orchestration.Workflow.StateMachine
{
	public interface IMachine
	{
		void Cancel();
		void Exception();
		void Next();
		void Previous();
		void Resume(int state);
		 int Show();
		void Stop();
		void Wait();
	}
}
