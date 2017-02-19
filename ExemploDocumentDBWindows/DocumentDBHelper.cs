using System;
using Microsoft.Azure.Documents.Client;

namespace ExemploDocumentDBWindows
{
    public static class DocumentDBHelper
    {
        public static DocumentClient CreateClient()
        {
            return new DocumentClient(
                new Uri(Configuracoes.EndpointUri),
                Configuracoes.PrimaryKey);
        }
    }
}