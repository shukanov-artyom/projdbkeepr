using System;
using System.Text.RegularExpressions;

namespace projdbkeepr.Commands
{
    public class UsualNameValidator
    {
        public CommandResult Validate(string filename)
        {
            string[] split = filename.Split('_');
            string maybeNumber = split[0];
            int output;

            // parse script number 
            if (!Int32.TryParse(maybeNumber, out output))
            {
                CommandResult result = new CommandResult(CommandResultType.ValidationErrorsFound)
                {
                    CommandResultMessage = $"File {filename} is named incorrectly"
                };
                return result;
            }

            // parse issue name 
            string issueNameMaybe = split[1];
            Regex expression = new Regex(@"(OB|MB)-\d{4,6}");
            if (!expression.IsMatch(issueNameMaybe))
            {
                CommandResult result = new CommandResult(CommandResultType.ValidationErrorsFound)
                {
                    CommandResultMessage = $"Jira issue name must be included in {filename} script's name."
                };
                return result;
            }
            return new CommandResult(CommandResultType.Success);
        }
    }
}
