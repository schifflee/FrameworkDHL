namespace SOW.Automation.Robot.DHL
{
	class Program
	{
		public static void Main(string[] args)
		{
			//new System.Threading.Timer((e) => Workflow.Alocacao(), null, System.TimeSpan.Zero, System.TimeSpan.FromMinutes(30));
			SOW.Automation.Workflow.DHL.Services Services = new SOW.Automation.Workflow.DHL.Services();
			System.Console.WriteLine(SOW.Automation.Workflow.DHL.Exception.ExceptionProcess.Run(Services));
            SOW.Automation.Workflow.DHL.Test.Run(Services);
            System.Console.WriteLine("Execução encerrada!\nPressione qualquer tecla para sair...");
            System.Console.ReadKey();
		}
	}
}