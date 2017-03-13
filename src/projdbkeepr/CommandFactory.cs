using System;
using projdbkeepr.Commands;

namespace projdbkeepr
{
    public class CommandFactory
    {
        public ApplicationCommand Create(ApplicationSettings settings)
        {
            switch (settings.CurrentCommand)
            {
                case ApplicationCommandType.ValidateScriptsNaming:
                    return new ValidateScriptsNamingCommand(
                        settings as ValidateScriptsNamingApplicationCommandSettings);
                default:
                    throw new NotImplementedException("Command is not implemented yet in the factory.");
            }
        }
    }
}