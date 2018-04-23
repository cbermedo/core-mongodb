using ApiCoreMongoDB.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCoreMongoDB.Interfaces
{
    public interface IMDBContext
    {
        IMongoCollection<Product> Products { get; }
    }
}
