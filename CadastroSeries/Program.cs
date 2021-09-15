using System;
using CadastroSeries.Classes;
using CadastroSeries.Exceptions;
namespace CadastroSeries
{
    class Program
    {
        static RepositorioDeSeries repositorio = new RepositorioDeSeries();
        static void Main(string[] args)
        {
            string inputUsuario;
            do
            {
                inputUsuario = OpcaoUsuario();
                switch (inputUsuario)
                {
                    case "1":
                        ListarTodasSeries();
                        break;
                    case "2":
                        InserirNovaSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarInfoSerie();
                        break;
                    case "6":
                        ListarInfoGenero();
                        break;
                    case "X":
                        Console.WriteLine("Programa finalizado");
                        break;
                    default:
                        try
                        {
                            throw new OpcaoInvalidaException();
                        }
                        catch (OpcaoInvalidaException)
                        {
                            Console.WriteLine("Opção inválida");
                        }
                        break;
                }
            } while (inputUsuario != "X");

        }

        private static int ObterIdGenero()
        {
            int countEnum = 0, result;
            try
            {
                foreach (int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
                    countEnum = countEnum + 1;
                }
                Console.WriteLine("\nInforme o número do gênero");
                result = int.Parse(Console.ReadLine());
                if (result < 0 || result > countEnum)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Endereço informado fora do alcance da lista");
                return -1;
            }
            return result;
        }

        private static void ListarInfoGenero()
        {
            int idGenero = ObterIdGenero();
            if (idGenero != -1) // se o usuário informou um genero válido
            {
                repositorio.InfoSeriesGeneroEspecifico((Genero)idGenero);
            }

        }

        private static void VisualizarInfoSerie()
        {
            int serieIdToView = ObterIdSerie();
            if (serieIdToView != -1) // se o usuário informou um id válido
            {
                Serie serieToView = repositorio.RetornaPorId(serieIdToView);
                Console.WriteLine(serieToView);
            }
        }

        private static void ExcluirSerie()
        {
            int serieIdToBeDeleted = ObterIdSerie();
            if (serieIdToBeDeleted != -1) // se o usuário informou um id válido
            {
                repositorio.ExcluirSeriePorId(serieIdToBeDeleted);
            }

        }

        private static int ObterIdSerie()
        {
            var todasSeries = repositorio.Lista();
            int result;
            try
            {
                if (todasSeries.Count == 0)
                {
                    throw new ListaVaziaException();
                }
                foreach (var serie in todasSeries)
                {
                    Console.WriteLine("ID: " + serie.Id + " - Titulo: " + serie.Titulo);
                }
                Console.WriteLine("\nInforme o id da série que deseja atualizar");
                result = int.Parse(Console.ReadLine());
                if (result < 0 || result > todasSeries.Count - 1)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            catch (ListaVaziaException)
            {
                Console.WriteLine("A lista está vazia, não há como atualizar uam série");
                return -1;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Escolha do id fora do alcance da lista");
                return -1;
            }
            return result;
        }
        private static void AtualizarSerie()
        {
            var todasSeries = repositorio.Lista();
            int idSerieToBeUpdated = ObterIdSerie();
            if (idSerieToBeUpdated != -1) // se o usuário informou um id válido
            {
                Console.WriteLine("Tudo certo, informe as novas informações da série");
                Console.WriteLine();
                Serie newSerieInfoToBeUpdated = ObterInfoSerie(); //informações novas que sobrescreverão as informações de uma série descrita pela id 'idSerieToBeUpdated'
                if (newSerieInfoToBeUpdated != null) // se o usuário informou tudo válido
                {
                    newSerieInfoToBeUpdated.Id = idSerieToBeUpdated;
                    repositorio.AtualizarInfoSerie(idSerieToBeUpdated, newSerieInfoToBeUpdated);
                }
            }
        }

        private static void InserirNovaSerie()
        {
            Serie newSerie = ObterInfoSerie();
            if (newSerie != null) // se o usuário informou tudo válido
            {
                newSerie.Id = repositorio.NextId();
                repositorio.InserirSerie(newSerie);
            }


        }


        /* Essa função 'ObterInfoSerie' é utilizada tanto para inserir quanto para atualizar séries.
           Como no código original havia repetção de código, eu resolvi criar essa função para evitar isso.
           Ao usar o construtor, eu passo o id como -1, porém nos métodos de inserção e atualização eu troco o id pelo correto.
        */
        private static Serie ObterInfoSerie()
        {
            int inputGenero = ObterIdGenero();
            if (inputGenero != -1) // se o usuário informou um genero válido
            {
                Console.WriteLine("Informe o título da série:");
                string inputTitulo = Console.ReadLine();

                Console.WriteLine("Informe a descrição da série:");
                string inputDescricao = Console.ReadLine();

                Console.WriteLine("Informe o dia de lançamento da série: ");
                int inputDia = int.Parse(Console.ReadLine());

                Console.WriteLine("Informe o mês de lançamento da série: ");
                int inputMes = int.Parse(Console.ReadLine());

                Console.WriteLine("Informe o ano de lançamento da série: ");
                int inputAno = int.Parse(Console.ReadLine());

                DateTime dateTimeSerie = new DateTime(inputAno, inputMes, inputDia);

                Serie result = new Serie(-1, (Genero)inputGenero, inputTitulo, inputDescricao, dateTimeSerie);
                return result;
            }
            return null;
        }
        private static void ListarTodasSeries()
        {
            var listaTodasSeries = repositorio.Lista();
            try
            {
                if (listaTodasSeries.Count == 0)
                {
                    throw new ListaVaziaException("A lista de séries está vazia");
                }
                else
                {
                    foreach (var serie in listaTodasSeries)
                    {
                        if (serie.Excluido == false)
                        {
                            Console.WriteLine("Id {0} - Título: {1} \nDescrição: {2}", serie.Id, serie.Titulo, serie.Descricao);
                        }
                    }
                }
            }
            catch (ListaVaziaException lve)
            {
                Console.WriteLine("A lista de séries está vazia");
            }


        }
        static string OpcaoUsuario()
        {
            Console.WriteLine("\nInforme a opção: ");
            Console.WriteLine("1 - Listar todas as séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar informações de ua série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar inforações de uma série");
            Console.WriteLine("6 - Listar informações de todas as séries de um gênero específico");
            Console.WriteLine("X - Finalizar programa");
            string result = Console.ReadLine().ToUpper();
            return result;
        }
    }
}
