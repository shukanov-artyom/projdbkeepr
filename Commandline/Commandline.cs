namespace projdbkeepr.CommandLine
{
    public class ApplicationSettingsFactory
    {
        private readonly string[] applicationArgs;
        public ApplicationSettingsFactory(string[] applicationArgs)
        {
            this.applicationArgs = applicationArgs;
        }

        public ApplicationSettings Create()
        {
            
        }
    } 
}