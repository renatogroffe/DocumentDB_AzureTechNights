namespace ExemploDocumentDBWindows
{
    public static class Configuracoes
    {
        private const string ENDPOINT = "https://docdbazuretechnights.documents.azure.com:443/";
        private const string PK = "TdvcbrRonmUA0ThYwEOogZLC0xf9dzDeDNOeHzvXYHxeD9NkAXsiHAez2cJNYtMVPWHegAx66vclHtHSjynb7Q==";
        private const string DATABASE = "AzureTechNights";
        private const string COLECAO_CATALOGO = "Catalogo";

        public static string EndpointUri { get { return ENDPOINT; } }

        public static string PrimaryKey { get { return PK; } }

        public static string Database { get { return DATABASE; } }

        public static string ColecaoCatalogo { get { return COLECAO_CATALOGO; } }
    }
}