using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace ExemploDocumentDBWindows
{
    public static class EstruturasDB
    {
        public static async Task CriarBanco()
        {
            DocumentClient client =
                DocumentDBHelper.CreateClient();

            await client.CreateDatabaseAsync(
                new Database { Id = Configuracoes.Database });
        }

        public static async Task CriarColecao()
        {
            DocumentClient client =
                DocumentDBHelper.CreateClient();

            DocumentCollection collectionInfo = new DocumentCollection();
            collectionInfo.Id = Configuracoes.ColecaoCatalogo;

            collectionInfo.IndexingPolicy =
                new IndexingPolicy(new RangeIndex(DataType.String) { Precision = -1 });

            await client.CreateDocumentCollectionAsync(
                UriFactory.CreateDatabaseUri(Configuracoes.Database),
                collectionInfo,
                new RequestOptions { OfferThroughput = 400 });
        }
    }
}