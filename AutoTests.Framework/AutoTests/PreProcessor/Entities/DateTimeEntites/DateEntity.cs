using System;

namespace AutoTests.PreProcessor.Entities.DateTimeEntites
{
    public class DateEntity
    {
        public DateTime Value { get; }

        public DateEntity(DateTime value)
        {
            Value = value;
        }

        public static DateEntity operator +(DateEntity dateEntity, DayEntity dayEntity)
        {
            return new DateEntity(dateEntity.Value.AddDays(dayEntity.Value));
        }

        public static DateEntity operator -(DateEntity dateEntity, DayEntity dayEntity)
        {
            return new DateEntity(dateEntity.Value.AddDays(-dayEntity.Value));
        }

        public override bool Equals(object obj)
        {
            return obj is DateEntity x && x.Value.Date == Value.Date;
        }
    }
}