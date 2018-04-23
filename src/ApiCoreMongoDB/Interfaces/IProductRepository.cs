using ApiCoreMongoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCoreMongoDB.Interfaces
{
    public interface IProductRepository
    {

        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProduct(string name);
        Task Create(Product product);
        Task<bool> Update(Product product);
        Task<bool> Delete(string name);
    };
}
