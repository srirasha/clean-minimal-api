using MongoDB.Bson;

namespace Infrastructure.Persistence.Contexts.AssetsDb.Entities.BaseEntities.Documents
{
    public class BaseDocument
    {
        public ObjectId Id { get; set; }
    }
}