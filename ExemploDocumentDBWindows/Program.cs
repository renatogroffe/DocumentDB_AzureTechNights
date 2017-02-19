using System;

namespace ExemploDocumentDBWindows
{
    public class Program
    {
        public static void Main(string[] args)
        {
            EstruturasDB.CriarBanco().Wait();
            Console.WriteLine("Cria��o do banco finalizada...");
            Console.ReadKey();

            EstruturasDB.CriarColecao().Wait();
            Console.WriteLine("Cria��o da cole��o finalizada...");
            Console.ReadKey();

            CRUD.InserirDadosProdutos().Wait();
            CRUD.InserirDadosServicos().Wait();
            Console.WriteLine("Dados inseridos...");
            Console.ReadKey();

            CRUD.AtualizarServico().Wait();
            Console.ReadKey();

            CRUD.ExcluirServico().Wait();
            Console.WriteLine("Exclus�o finalizada...");
            Console.ReadKey();

            CRUD.ConsultarLINQ();
            Console.ReadKey();
        }
    }
}