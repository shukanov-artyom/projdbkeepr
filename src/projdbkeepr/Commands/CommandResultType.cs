using System;

namespace projdbkeepr.Commands
{
    public enum CommandResultType
    {
        Success = 0,

        ValidationErrorsFound = 1,

        Error = 2
    }
}
