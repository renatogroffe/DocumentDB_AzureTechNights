using System;

namespace ExemploDocumentDBWindows
{
    public class Program
    {
        public static void Main(string[] args)
        {
            EstruturasDB.CriarBanco().Wait();
            Console.WriteLine("Criação do banco finalizada...");
            Console.ReadKey();

            EstruturasDB.CriarColecao().Wait();
            Console.WriteLine("Criação da coleção finalizada...");
            Console.ReadKey();

            CRUD.InserirDadosProdutos().Wait();
            CRUD.InserirDadosServicos().Wait();
            Console.WriteLine("Dados inseridos...");
            Console.ReadKey();

            CRUD.AtualizarServico().Wait();
            Console.ReadKey();

            CRUD.ExcluirServico().Wait();
            Console.WriteLine("Exclusão finalizada...");
            Console.ReadKey();

            CRUD.ConsultarLINQ();
            Console.ReadKey();
        }
    }
}