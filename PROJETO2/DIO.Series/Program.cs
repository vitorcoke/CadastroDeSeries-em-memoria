using System;

namespace DIO.Series
{
    class Program
    {
        static serieRepositorio repositorio = new serieRepositorio();
        static void Main(string[] args)
        {
            string opçãoUsuario = ObterOpcaoUsuario();

            while (opçãoUsuario.ToUpper() != "x")
            {
                switch (opçãoUsuario)
                {
                    case "1":
                        ListarSerie();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                         ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();

                }
                opçãoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigador por ultilizar nossos serviços!!");
            Console.WriteLine();
        }

        private static void ListarSerie()
        {
            Console.WriteLine("Listar series");
            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {   
                var excluido = serie.retornaExcluidoId();
                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), excluido ? "*Excluido*" : "");
            }
        }

         private static void ExcluirSerie()
        {
            Console.Write(" Digite o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.exclui(indiceSerie);
        }

          private static void VisualizarSerie()
        {
            Console.Write(" Digite o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

           var serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);
        }

        private static void AtualizarSerie()
        {
            Console.Write(" Digite o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine(" Digite o genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de inicio de série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Series atualizaSerie = new Series(id: indiceSerie, Genero: (Genero)entradaGenero, Titulo: entradaTitulo, ano: entradaAno, Descricao: entradaDescricao);

            repositorio.atualiza(indiceSerie, atualizaSerie);
        }

        private static void InserirSerie()
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {   
                Console.WriteLine("{0} {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine(" Digite o genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de inicio de série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Series novaSerie = new Series(id: repositorio.ProximoId(), Genero: (Genero)entradaGenero, Titulo: entradaTitulo, ano: entradaAno, Descricao: entradaDescricao);

            repositorio.Insere(novaSerie);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Series a seu dispor!!!");
            Console.WriteLine("informe a opção desejada");

            Console.WriteLine("1 - Listar Series");
            Console.WriteLine("2 - Inserir nova Série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opçãoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opçãoUsuario;
        }
    }
}

