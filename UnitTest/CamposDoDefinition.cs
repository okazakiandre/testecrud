using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Linq;

namespace TesteCrud.UnitTest
{
    public class CamposDoDefinition
    {
        public static string[] ObterDoUpdate<T>(UpdateDefinition<T> upd)
        {
            var bval = upd.Render(BsonSerializer.LookupSerializer<T>(), BsonSerializer.SerializerRegistry);
            return bval[0].AsBsonDocument.ToArray().Select(b => b.ToString()).ToArray();
        }

        public static string[] ObterDoFilter<T>(FilterDefinition<T> flt)
        {
            var bdoc = flt.Render(BsonSerializer.LookupSerializer<T>(), BsonSerializer.SerializerRegistry);
            return bdoc.ToArray().Select(b => b.ToString()).ToArray();
        }
    }
}
