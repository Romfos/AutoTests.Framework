namespace AutoTests.Tools.Refactroings.Entities
{
    public class Step
    {
        public StepType StepType { get; set; }
        public string Text { get; set; }
        public Table Table { get; } = new Table();
    }
}