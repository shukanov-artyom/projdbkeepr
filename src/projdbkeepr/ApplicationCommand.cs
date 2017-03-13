using System;
using projdbkeepr.Commands;

namespace projdbkeepr
{
    public abstract class ApplicationCommand
    {
        private readonly ApplicationCommandType type;

        protected ApplicationCommand(ApplicationCommandType type)
        {
            this.type = type;
        }

        public ApplicationCommandType Type => type;

        /// <summary>
        /// Executes command and provides result.
        /// </summary>
        /// <returns>Result object.</returns>
        public abstract CommandResult Execute();
    }
}
