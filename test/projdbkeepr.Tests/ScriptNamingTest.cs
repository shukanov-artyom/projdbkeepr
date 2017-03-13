using System;
using projdbkeepr.Commands;
using Xunit;

namespace projdbkeepr.Tests
{
    public class ScriptNamingTesting
    {
        [Theory]
        [InlineData("12_OB-1234_Scriptname.sql")]
        [InlineData("12_OB-1234_usp_storedProcedure_NameScriptname.sql")]
        public void TestScriptNameCorrect(string scriptName)
        {
            UsualNameValidator validator = new UsualNameValidator();
            CommandResult result = validator.Validate(scriptName);
            if (result.ResultType != CommandResultType.Success)
            {
                throw new Exception();
            }
        }

        [Theory]
        [InlineData("OB-1234_Scriptname.sql")]
        [InlineData("12_Scriptname.sql")]
        [InlineData("12__Scriptname.sql")]
        public void TestScriptNameIncorrect(string scriptName)
        {
            UsualNameValidator validator = new UsualNameValidator();
            CommandResult result = validator.Validate(scriptName);
            if (result.ResultType == CommandResultType.Success)
            {
                throw new Exception();
            }
        }
    }
}