using System;
using AutoTests.Framework.PreProcessor.Assets;
using AutoTests.PreProcessor.Entities.DateTimeEntites;

namespace AutoTests.PreProcessor.Assets
{
    public class DateTimeAsset : Asset
    {
        public DateEntity CurrentDate => new DateEntity(DateTime.Now);
    }
}