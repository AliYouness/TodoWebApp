using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TODO_Solution.Model
{
    public class TodoItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        
        public string title { get;  set; }
        public bool isDone { get; set; }


    }
}
