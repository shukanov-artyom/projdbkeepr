using System;

namespace projdbkeepr.Commands
{
    public class CommandResult
    {
        public CommandResult(CommandResultType resultType)
        {
            this.ResultType = resultType;
        }

        public CommandResultType ResultType { get; private set; }

        public string ErrorMessage { get; set; }

        public string CommandResultMessage { get; set; }
    }
}
