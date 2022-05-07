namespace Infrastructure.Persistence.Contexts.AssetsDb.Entities
{
    public class AvatarDocument : BaseDocument
    {
        public string Description { get; set; }

        public string Name { get; set; }
    }
}