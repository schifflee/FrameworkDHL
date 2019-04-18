namespace SOW.Automation.Common
{
    public class DriverContextInfo
    {
        public string Path { get; set; }
        public DriverEnum Driver { get; set; }
        public int Timeout { get; set; }
        public int Attempts { get; set; }
        public int MaxAttempts { get; set; }
        public int Restore()
        {
        	return MaxAttempts;
        }
    }
}
