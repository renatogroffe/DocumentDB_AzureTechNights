using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;

namespace ExemploDocumentDBWindows
{
    public static class CRUD
    {
        public static async Task InserirDadosProdutos()
        {
            Produto prod001 = new Produto();
            prod001.id = "PROD001";
            prod001.Nome = "Detergente";
            prod001.Tipo = "Limpeza";
            prod001.Preco = 5.75;
            prod001.DadosFornecedor = new Fornecedor();
            prod001.DadosFornecedor.Codigo = "FORN001";
            prod001.DadosFornecedor.Nome = "EMPRESA XYZ";

            var prod002 = new
            {
                id = "PROD002",
                Nome = "Martelo",
                Tipo = "Ferramenta",
                Preco = 50.70
            };

            DocumentClient client =
                DocumentDBHelper.CreateClient();

            await client.CreateDocumentAsync(
                UriFactory.CreateDocumentCollectionUri(
                    Configuracoes.Database,
                    Configuracoes.ColecaoCatalogo), prod001);

            await client.CreateDocumentAsync(
                UriFactory.CreateDocumentCollectionUri(
                    Configuracoes.Database,
                    Configuracoes.ColecaoCatalogo), prod002);
        }

        public static async Task InserirDadosServicos()
        {
            Servico serv001 = new Servico();
            serv001.id = "SERV001";
            serv001.Nome = "LIMPEZA PREDIAL";
            serv001.ValorHora = 150.00;

            dynamic serv002 = new ExpandoObject();
            serv002.id = "SERV002";
            serv002.Nome = "GUARDA PATRIMONIAL";

            DocumentClient client =
                DocumentDBHelper.CreateClient();

            await client.CreateDocumentAsync(
                UriFactory.CreateDocumentCollectionUri(
                    Configuracoes.Database,
                    Configuracoes.ColecaoCatalogo), serv001);

            await client.CreateDocumentAsync(
                UriFactory.CreateDocumentCollectionUri(
                    Configuracoes.Database,
                    Configuracoes.ColecaoCatalogo), serv002);
        }

        public static async Task AtualizarServico()
        {
            DocumentClient client =
                 DocumentDBHelper.CreateClient();

            FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1 };

            IEnumerable<Servico> servicos =
                client.CreateDocumentQuery<Servico>(
                    UriFactory.CreateDocumentCollectionUri(
                        Configuracoes.Database, Configuracoes.ColecaoCatalogo),
                            queryOptions)
                        .Where(p => p.id == "SERV001").AsEnumerable();

            if (servicos.Count() == 1)
            {
                var serv001 = servicos.FirstOrDefault();
                serv001.ValorHora = 300.00;

                await client.ReplaceDocumentAsync(
                    UriFactory.CreateDocumentUri(
                        Configuracoes.Database,
                        Configuracoes.ColecaoCatalogo,
                        "SERV001"), serv001);

                Console.WriteLine("Atualização realizada...");
            }
        }

        public static async Task ExcluirServico()
        {
            DocumentClient client =
                 DocumentDBHelper.CreateClient();

            await client.DeleteDocumentAsync(
                UriFactory.CreateDocumentUri(
                    Configuracoes.Database,
                    Configuracoes.ColecaoCatalogo,
                    "SERV002"));
        }

        public static void ConsultarLINQ()
        {
            DocumentClient client =
                 DocumentDBHelper.CreateClient();

            FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1 };

            IEnumerable<Servico> servicos =
                client.CreateDocumentQuery<Servico>(
                    UriFactory.CreateDocumentCollectionUri(
                        Configuracoes.Database,
                        Configuracoes.ColecaoCatalogo), queryOptions)
                        .Where(p => p.id == "SERV001").AsEnumerable();

            Console.WriteLine("\nExemplo de uso de LINQ...");
            if (servicos.Count() == 1)
            {
                Console.WriteLine(
                    JsonConvert.SerializeObject(servicos.FirstOrDefault()));
            }
            Console.ReadKey();
        }
    }
}