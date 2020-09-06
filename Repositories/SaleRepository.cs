using AppCRUDOp.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppCRUDOp.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly IMongoCollection<Sale> _collection;

        public SaleRepository(IMongoDbSettings settings)
        {
            var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<Sale>("sales");
        }

        public void InsertOne(Sale saleObj)
        {
            _collection.InsertOne(saleObj);
        }

        public virtual Task InsertOneAsync(Sale saleObj)
        {
            return Task.Run(() => _collection.InsertOneAsync(saleObj));
        }

        public void Delete(ObjectId id)
        {
            _collection.DeleteOne(s => s.Id == id);
        }

        public Sale FindSaleById(string id)
        {
            var objectId = new ObjectId(id);
            var filter = Builders<Sale>.Filter.Eq(doc => doc.Id, objectId);
            return _collection.Find(filter).SingleOrDefault();
        }

        public IEnumerable<Sale> GetAllSales()
        {
            var result = _collection.AsQueryable();
            return result;
        }

        public void Update(string id, Sale saleIn)
        {
            var objectId = new ObjectId(id);
            var filter = Builders<Sale>.Filter.Eq(doc => doc.Id, objectId);
            _collection.ReplaceOne(filter, saleIn);
        }
    }
}
