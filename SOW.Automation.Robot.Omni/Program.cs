namespace SOW.Automation.Robot.Omni
{
	class Program
	{
		public static void Main(string[] args)
		{
            //new System.Threading.Timer((e) => Workflow.Alocacao(), null, System.TimeSpan.Zero, System.TimeSpan.FromMinutes(30));0

            Workflow.Omni.Services Services = new SOW.Automation.Workflow.Omni.Services();

            System.Console.WriteLine(SOW.Automation.Workflow.Omni.Exception.ExceptionProcess.Run(Services));

            Workflow.Omni.Test.Run(Services);

            System.Console.WriteLine("Execução encerrada!\nPressione qualquer tecla para sair...");

            System.Console.ReadKey();
		}
	}
}