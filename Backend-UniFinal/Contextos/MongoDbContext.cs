using Backend_UniFinal.Models;
using MongoDB.Driver;

namespace Backend_UniFinal.Contextos
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IConfiguration configuration) 
        {
            var connectionString = configuration.GetConnectionString("mongoDb");
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase("Desenvolvimento");
        }

        public IMongoCollection<Pesquisa> pesquisa => _database.GetCollection<Pesquisa>("Pesquisas");
        public IMongoCollection<Resposta> resposta => _database.GetCollection<Resposta>("Respostas");

    }
}
