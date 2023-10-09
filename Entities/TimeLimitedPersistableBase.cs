namespace Sustain.Entities
{
    public abstract class TimeLimitedPersistableBase : PersistableBase
    {
        public DateTime effFrom { get; set; }
        public DateTime effTo { get; set; }
    }
}