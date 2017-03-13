using System;

namespace projdbkeepr.Commands
{
    public class ValidateScriptsNamingApplicationCommandSettings
        : ApplicationSettings
    {
        public ValidateScriptsNamingApplicationCommandSettings() 
            : base(ApplicationCommandType.ValidateScriptsNaming)
        {
        }
        
        public string TargetFolder { get; set; }

        public string FilesSearchPattern => "*.sql";
    }
}
