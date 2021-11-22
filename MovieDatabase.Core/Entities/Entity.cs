namespace MovieDatabase.Core.Entities
{
    public abstract class Entity<TKey>
    {
        public TKey Id { get; set; }
    }
}
