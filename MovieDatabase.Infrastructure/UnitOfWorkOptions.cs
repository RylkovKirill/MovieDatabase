namespace MovieDatabase.Infrastructure
{
    public class UnitOfWorkOptions
    {
        public string ConnectionString { get; set; }
        public int? CommandTimeout { get; set; }
    }
}
