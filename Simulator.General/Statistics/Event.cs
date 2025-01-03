namespace Simulator.General.Statistics
{
    public enum EventType
    {
        Win = 0,
        Feature = 1,
        FreeSpin = 2
    }

    public class Event
    {
        public string Name { get; set; } = string.Empty;
        public EventType Type { get; set; }
        public int? Value { get; set; }
    }
}
