using System;
using System.Collections.Generic;
using System.IO;

namespace projdbkeepr.Commands
{
    public class ValidateScriptsNamingCommand : ApplicationCommand
    {
        private readonly ValidateScriptsNamingApplicationCommandSettings settings;

        public ValidateScriptsNamingCommand(ValidateScriptsNamingApplicationCommandSettings settings)
            : base(ApplicationCommandType.ValidateScriptsNaming)
        {
            if (settings.CurrentCommand != ApplicationCommandType.ValidateScriptsNaming)
            {
                throw new InvalidOperationException("Incorrect command type applied.");
            }
            this.settings = settings;
        }

        public override CommandResult Execute()
        {
            string targetFolder = settings.TargetFolder;
            Console.WriteLine($"Exploring {settings.TargetFolder} directory.");
            if (String.IsNullOrEmpty(targetFolder))
            {
                return new CommandResult(CommandResultType.Error)
                {
                    ErrorMessage = "Target folder for scripts naming validation must be provided."
                };
            }
            DirectoryInfo dir = new DirectoryInfo(targetFolder);
            if (!dir.Exists)
            {
                return new CommandResult(CommandResultType.Error)
                {
                    ErrorMessage = "Target folder for scripts naming validation must exist."
                };
            }

            IEnumerable<FileInfo> files = dir.EnumerateFiles(settings.FilesSearchPattern);
            foreach (FileInfo sqlFileInfo in files)
            {
                CommandResult fileResult = IsConsistent(sqlFileInfo.Name);
                if (fileResult.ResultType != CommandResultType.Success)
                {
                    return fileResult;
                }
            }
            return new CommandResult(CommandResultType.Success);
        }

        private CommandResult IsConsistent(string filename)
        {
            // 15_OB-6636_MigrateTechniqueSpecialty.sql
            
            if (String.IsNullOrEmpty(filename))
            {
                return new CommandResult(CommandResultType.Error)
                {
                    ErrorMessage = "Filename provided was null or empty."
                };
            }
            UsualNameValidator validator = new UsualNameValidator();
            CommandResult comResult = validator.Validate(filename);
            if (comResult.ResultType != CommandResultType.Success)
            {
                return comResult;
            }
            return new CommandResult(CommandResultType.Success);
        }
    }
}
