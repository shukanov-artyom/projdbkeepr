using System;
using System.IO;
using projdbkeepr.Commands;

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
            string commandElement = applicationArgs[0];
            if (String.IsNullOrEmpty(commandElement))
            {
                throw new ArgumentException("Valid command must be provided.");
            }
            if (commandElement.Equals(ApplicationCommandStrings.ValidateCommandString))
            {
                string folder = applicationArgs[1];
                if (String.IsNullOrEmpty(folder))
                {
                    throw new ArgumentException("Folder must be set");
                }
                if (!Directory.Exists(folder))
                {
                    throw new DirectoryNotFoundException("Provide folder must exist.");
                }
                return new ValidateScriptsNamingApplicationCommandSettings()
                {
                    TargetFolder = folder
                };
            }
            else
            {
                string message = $"{commandElement} command is unknown";
                Console.WriteLine(message);
                throw new NotImplementedException(message);
            }
        }
    } 
}