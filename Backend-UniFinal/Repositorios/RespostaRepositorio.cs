using Backend_UniFinal.Contextos;
using Backend_UniFinal.Dto;
using Backend_UniFinal.Models;
using MongoDB.Driver;

namespace Backend_UniFinal.Repositorios
{
    public class RespostaRepositorio
    {
        private readonly MongoDbContext _db;
        public RespostaRepositorio( MongoDbContext db)
        {
            _db= db;
        }

        //Cadastrar nova resposta
        public  Resposta  CadastroResposta(Resposta resposta)
        {
            _db.resposta.InsertOne(resposta);
            return resposta;
        }
        //Pegar todas as respostas
        public List<Resposta> Respostas_get_todas()
        {
            var result = _db.resposta.Find(_=>true).ToList();
            return result;
        }
        //Pegar resposta Por Id
        public Resposta Respostas_get_id(string id)
        {
            var result = _db.resposta.Find(e => e.Id == id).FirstOrDefault();
            return result;
        }

        //Pegar resposta por pesquisa
        public List<Resposta> Respostas_por_pesquisa(string idPesquisa)
        {
            var result = _db.resposta.Find(e => e.PesquisaId == idPesquisa).ToList();
            return result;
        }

        //Pegar Resposta por pesquisa e por loja
        public List<Resposta> Resposta_por_loja(string pesquisaId, string lojaId)
        {
            var result = _db.resposta.Find(e => e.PesquisaId == pesquisaId && e.LojaId == lojaId).ToList();
            return result;
        }

        //Apagar resposta por Id
        public void ApagarResposta(string id)
        {
             _db.resposta.DeleteOne(e => e.Id == id);
        }

        //Inserir varias respostas
        public List<Resposta> InserirVariasRespostas(List<Resposta> respostas)
        {
            _db.resposta.InsertMany(respostas);
            return respostas;
        }
    }
}
