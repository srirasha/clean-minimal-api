using MongoDB.Bson;

namespace Infrastructure.Persistence.Contexts.AssetsDb.Entities.BaseEntities.Documents
{
    public interface IDocument
    {
        ObjectId Id { get; set; }
    }
}