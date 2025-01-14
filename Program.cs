﻿using System;
namespace APP_CRUD_Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                 switch (opcaoUsuario)
                 {
                    case "1":
                        ListarSeries();
                        break; 
                    case "2" :
                        InserirSerie();
                        break;
                    case "3" :
                       AtualizarSerie();
                        break;
                    case "4" :
                        ExcluirSerie();
                        break;
                    case "5" :
                        VisualizarSerie();
                        break;
                    case "C" :
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                 }
                 opcaoUsuario = ObterOpcaoUsuario();
              }
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");

            var lista = repositorio.Lista();
            
            if (lista.Count == 0)
            {
                Console.WriteLine("Não há séries para serem listadas.");
                return;
            }
            foreach (var serie in lista)
            {   
                var excluido = serie.retornaExcluido();

                
                Console.WriteLine($"#ID {serie.retornaId()}: - {serie.retornaTitulo()} - {(excluido ? "Excluido" : "")} ");
            }
            
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir Série");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero),i));
            }
            Console.WriteLine("Digite o Género entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de criação da série: ");
            int entradaAno = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Digitea descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

           Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                       Genero: (Genero)entradaGenero,
                                       Titulo: entradaTitulo,
                                       Ano: entradaAno,
                                       Descricao: entradaDescricao);
            repositorio.Insere(novaSerie);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero),i));
            }
            Console.WriteLine("Digite o Género entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de criação da série: ");
            int entradaAno = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Digitea descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

           Serie atualizaSerie = new Serie(id: indiceSerie,
                                       Genero: (Genero)entradaGenero,
                                       Titulo: entradaTitulo,
                                       Ano: entradaAno,
                                       Descricao: entradaDescricao);
            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

           var serie = repositorio.RetornaPorId(indiceSerie);

           Console.WriteLine(serie);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("IntoCast a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
             

        }
        
        
    }
}