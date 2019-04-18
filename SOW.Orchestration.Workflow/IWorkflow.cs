using System.Collections.Generic;
namespace SOW.Orchestration.Workflow
{
	public interface IWorkflow
	{
		void Exception();
		 int Get();
		void Jump(int step);
		void Loop(bool condition, Process process);
		void Next();
		void Previous();
		void Repeat(int from, int to, bool condition);
		void Resume(int step);
		void Run(Process process);
	}
}
