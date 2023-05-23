using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula1205
{
    internal class Persistencia
    {
        /// <summary>
        /// método de classe que sabe ler o conteúdo de um arquivo, linha a linha e jogar na tela
        /// </summary>
        /// <param name="nomeArquivo"></param>
        public static void lerArquivoParaTela(string nomeArquivo)
        {
            try
            {
                StreamReader leitor = new StreamReader(nomeArquivo, Encoding.UTF8);
                do
                {
                    Console.WriteLine(leitor.ReadLine());
                } while (!leitor.EndOfStream);
                leitor.Close();
            }
            catch 
            {
                Console.WriteLine("Problemas com arquivo.");
            }
        }

        /// <summary>
        /// método de classe que sabe ler o conteúdo de um arquivo, exibe nome
        /// </summary>
        /// <param name="nomeArquivo"></param>
        public static void lerArquivoExibeNomes(string nomeArquivo)
        {
            StreamReader leitor = new StreamReader(nomeArquivo, Encoding.UTF8);
            string[] vetorLinha; //[nome, email, dataNascimento]
            string linha;
            try
            {
                do
                {
                    linha = leitor.ReadLine();
                    vetorLinha = linha.Split(";");
                    Console.WriteLine(vetorLinha[0]);
                } while (!leitor.EndOfStream);
                leitor.Close();
            }
            catch
            {
                Console.WriteLine("Problemas com arquivo.");
            }
        }

        public static void popularArquivoLista(string nomeArquivo, List<Pessoa> lista)
        {
            StreamReader leitor = new StreamReader(nomeArquivo, Encoding.UTF8);
            string[] vetorLinha; //[nome, email, dataNascimento]
            string linha;
            do
            {
                linha = leitor.ReadLine();//Leandro Di Nardo Lazarin;lazarin@ufn.edu.br;12/12/1990
                vetorLinha = linha.Split(";"); //[Leandro Di Nardo Lazarin, lazarin@ufn.edu.br, 12/12/1990]
                lista.Add(new Pessoa(vetorLinha[0], vetorLinha[1], vetorLinha[2]));

            } while (!leitor.EndOfStream);
            leitor.Close();
        }

        
        public static void gravarListaArquivo(List<Pessoa> lista, string nomeArquivo)
        {
            StreamWriter escritor = new StreamWriter(nomeArquivo); //possibilidade de adicionar dados no arquivo; StreamWriter escritor = new StreamWriter(nomeArquivo) arquivo é criado do zero
            // append: true
            foreach (var item in lista)
            {
                escritor.WriteLine(item.Nome+";"+item.Email+";"+item.DataNascimento);
                escritor.Flush();
            }


            escritor.Close();

        }
        /// <summary>
        /// método de classe que atualiza na hora o arquivo
        /// </summary>
        /// <param name="nomeArquivo"></param>
        public static void AtualizarPessoaArquivo(Pessoa pessoa, string nomeArquivo)
        {
            using (StreamWriter escritor = new StreamWriter(nomeArquivo, append: true))
            {
                escritor.WriteLine($"{pessoa.Nome};{pessoa.Email};{pessoa.DataNascimento}");
            }
        }


    }


}
