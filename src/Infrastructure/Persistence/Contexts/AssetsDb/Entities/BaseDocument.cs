using MongoDB.Bson;

namespace Infrastructure.Persistence.Contexts.AssetsDb.Entities
{
    public class BaseDocument
    {
        public ObjectId Id { get; set; }
    }
}