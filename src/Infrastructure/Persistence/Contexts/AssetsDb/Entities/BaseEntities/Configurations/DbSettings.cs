namespace Infrastructure.Persistence.Contexts.AssetsDb.Entities.BaseEntities.Configurations
{
    public class DbSettings : IDbSettings
    {
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
    }
}