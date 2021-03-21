using System;
using Series.Classes;

namespace Series

{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcao = OpcaoUsuario();

            while (opcao != "0")
            {               
                switch (opcao)
                {
                    case "1":
                        ListarSeries();
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
                    case "6":
                        Console.Clear();
                        break;      
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcao = OpcaoUsuario();
            }
            Console.WriteLine("Obrigado por usar o sistema");
            Console.ReadLine();
        }
        private static string OpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("SISTEMA DE CADASTRO DE SÉRIES");
            Console.WriteLine("Escolha a opção: ");
            Console.WriteLine();
            Console.WriteLine("1 -> Listar séries");
            Console.WriteLine("2 -> Inserir nova série");
            Console.WriteLine("3 -> Atualizar séries");
            Console.WriteLine("4 -> Excluir série");
            Console.WriteLine("5 -> Visualizar séries");
            Console.WriteLine("6 -> Limpar a tela");
            Console.WriteLine("0 -> Sair");
            string op = Console.ReadLine();
            Console.WriteLine();
            return op;
        }

        private static void ListarSeries()
        {
            Console.WriteLine("LISTAR SÉRIES");
            var lista = repositorio.Lista();
            if (lista.Count == 0) 
            {
                Console.WriteLine("Nenhuma série cadastrada");
                return;
            }
            else
            {
                foreach (var serie in lista)
                {
                    var excluido = serie.RetornaExcluido();
                    Console.WriteLine(" ID {0}: {1} {2}", 
                    serie.retornaId(), 
                    serie.retornaTitulo(),
                    (excluido ? "(Excluído)" : ""));
                }
            } 
        }

        private static void InserirSerie()
        {
            Console.WriteLine("INSERIR SÉRIE");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{{0}} - {{1}}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o Gênero: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            
            Console.Write("Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());
            
            Console.Write("Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Insere(novaSerie);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("ATUALIZAR SÉRIE");
            Console.Write("Digite o ID da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine($"{{0}} - {{1}}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Entre com o número do Gênero da Série: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Entre com o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Entre com o Ano da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Entre com a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(
                id: indiceSerie,
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o número da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o ID da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);
        }
    }
}
