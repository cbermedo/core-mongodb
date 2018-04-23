using ApiCoreMongoDB.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCoreMongoDB.Models
{
    public class MDBContext : IMDBContext
    {
        private readonly IMongoDatabase _db;
        public MDBContext(IOptions<Settings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.Database);
        }
        public IMongoCollection<Product> Products => _db.GetCollection<Product>("Products");
    }
}
