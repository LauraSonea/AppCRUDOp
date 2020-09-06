using AppCRUDOp.Models;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppCRUDOp.Repositories
{
    public interface ISaleRepository
    {
        Sale FindSaleById(string id);

        IEnumerable<Sale> GetAllSales();

        void InsertOne(Sale saleObj);

        Task InsertOneAsync(Sale saleObj);

        void Delete(ObjectId id);

        void Update(string id, Sale saleIn);
    }
}
