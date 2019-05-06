using System.Linq;

namespace SOW.Orchestration.Workflow
{
    public class Workflow : IWorkflow
    {
        public System.Collections.Generic.List<Process> Processes { get; set; }

        private int Step;

        public Workflow() { Step = 0; }

        public Workflow(System.Collections.Generic.List<Process> processes, int step = 0)
        {
            Step = step;
            Processes = processes;
        }

        public void Exception()
        {
            Step = -1;
        }

        public int Get()
        {
            return Step;
        }

        public void Jump(int step)
        {
            Step = step;
        }

        public void Loop(bool condition, Process process)
        {
            while (condition) process.Method.Invoke();
        }

        public void Next()
        {
            Step++;
        }

        public void Previous()
        {
            Step--;
        }

        public void Repeat(int from, int to, bool condition)
        {
            while (condition) Processes.FindAll(x => x.Step >= from && x.Step <= to).OrderBy(y => y.Step).ToList().ForEach(Run);
            //Processes.FindAll(x => x.Step >= from && x.Step <= to).OrderBy(y=>y.Step).ToList().ForEach((Process process) => process.Method.Invoke());
        }

        public void Resume(int step)
        {
            Step = step;
        }

        public void Run(Process process)
        {
            process.Method.Invoke();
        }
    }
}
