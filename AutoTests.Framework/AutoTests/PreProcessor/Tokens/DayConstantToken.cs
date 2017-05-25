using System;
using AutoTests.Framework.PreProcessor.Tokens;
using AutoTests.PreProcessor.Entities.DateTimeEntites;

namespace AutoTests.PreProcessor.Tokens
{
    public class DayConstantToken : Token
    {
        public override string Process()
        {
            State = new DayEntity(Int32.Parse(Value));
            return "&";
        }
    }
}