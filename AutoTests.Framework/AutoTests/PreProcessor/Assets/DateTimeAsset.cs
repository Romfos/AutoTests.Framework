using System;
using AutoTests.Framework.PreProcessor.Assets;

namespace AutoTests.PreProcessor.Assets
{
    public class DateTimeAsset : Asset
    {
        private readonly Application application;

        public DateTimeAsset(Application application)
        {
            this.application = application;
        }

        public DateTime CurrentDate => DateTime.Now;
    }
}