using Infrastructure.Persistence.Contexts.AssetsDb.Entities.BaseEntities.Documents;

namespace Infrastructure.Persistence.Contexts.AssetsDb.Entities
{
    public class AvatarDocument : Document
    {
        public string Description { get; set; }

        public string Name { get; set; }
    }
}