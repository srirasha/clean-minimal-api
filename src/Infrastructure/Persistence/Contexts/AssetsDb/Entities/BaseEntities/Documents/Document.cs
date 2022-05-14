using MongoDB.Bson;

namespace Infrastructure.Persistence.Contexts.AssetsDb.Entities.BaseEntities.Documents
{
    public abstract class Document : IDocument
    {
        public ObjectId Id { get; set; }

        public DateTime CreatedAt => Id.CreationTime;
    }
}