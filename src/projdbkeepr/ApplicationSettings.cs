using projdbkeepr.CommandLine;

namespace projdbkeepr
{
    public class ApplicationSettings
    {
        public ApplicationSettings(ApplicationCommandType command)
        {
            CurrentCommand = command;
        }
        public ApplicationCommandType CurrentCommand { get; private set; }
    }
}