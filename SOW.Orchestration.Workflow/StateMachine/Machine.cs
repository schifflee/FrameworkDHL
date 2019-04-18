namespace SOW.Orchestration.Workflow.StateMachine
{
	public class Machine : IMachine
	{
		private int State;
		
		public Machine()
		{
			State = 0;
		}
		
		public void Cancel()
		{
			State = 5;
		}
		
		public void Exception()
		{
			State = -1;
		}
		
		public void Next()
		{
			State++;
		}
		
		public void Previous()
		{
			State--;
		}
		
		public void Resume(int state)
		{
			State = state;
		}
		
		public int Show()
		{
			return State;
		}
		
		public void Stop()
		{
			State = 4;
		}
		
		public void Wait()
		{
			State = 0;
		}
	}
}
