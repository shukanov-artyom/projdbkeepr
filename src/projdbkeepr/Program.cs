using System;
using projdbkeepr.CommandLine;
using projdbkeepr.Commands;

namespace projdbkeepr
{
    public class Program
    {
        public static int Main(string[] args)
        {
            ApplicationSettingsFactory appSettingsFactory =
                new ApplicationSettingsFactory(args);
            ApplicationSettings settings;
            if (args.Length == 0)
            {
                Console.WriteLine("No parameters provided for a tool.");
                return -1;
            }
            try
            {
                settings = appSettingsFactory.Create();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
            CommandFactory commandFactory = new CommandFactory();
            ApplicationCommand command = commandFactory.Create(settings);
            try
            {
                CommandResult result = command.Execute();
                if (result.ResultType == CommandResultType.Success)
                {
                    return 0;
                }
                if (result.ResultType == CommandResultType.Error)
                {
                    Console.WriteLine(result.ErrorMessage);
                }
                if (result.ResultType == CommandResultType.ValidationErrorsFound)
                {
                    Console.WriteLine(result.CommandResultMessage);
                }
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }
    }
}
