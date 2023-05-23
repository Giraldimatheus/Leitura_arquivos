using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Aula1205
{
    internal class Comunicacao
    {
        public static bool validaNome(string nome)
        {
            string[]vetor = nome.Split();
            if(vetor.Length < 2)
            {
                Console.WriteLine("Digite o nome completo");
                return false;
            }
            return true;
        }
        public static bool validaData(string data)
        {
            string[]vetor = data.Split('/');
            if(vetor.Length != 3|| vetor[0].Length > 2 || vetor[1].Length > 2|| vetor[2].Length != 4)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static void cadastrar(List<Pessoa> listaPessoas, string nomeArquivo)
        {
            
            string nome;
            string dataNascimento;
            Pessoa pessoa;

            do
            {
                Console.Write("Nome: ");
                nome = Console.ReadLine().ToUpper();
            } while (!validaNome(nome));
            

            Console.Write("Nascimento: ");
            dataNascimento = Console.ReadLine();

            pessoa = new Pessoa(nome, dataNascimento);

            if (!listaPessoas.Contains(pessoa)) 
            {
                listaPessoas.Add(pessoa);
                Persistencia.AtualizarPessoaArquivo(pessoa, nomeArquivo);
            }
            else
            {
                Console.WriteLine("Pessoa com este email já na base de dados.");
            }
        }

        public static void listar(List<Pessoa> listaPessoas, string nomeArquivo)
        {
            foreach (var item in listaPessoas)
            {
                Console.WriteLine(item);
            }

        }

        public static void pesquisar(List<Pessoa> listaPessoas, string nomeArquivo)
        {
            Console.WriteLine("Digite o nome a ser pesquisado:");
            string nome = Console.ReadLine().ToUpper();
            foreach(var item in listaPessoas)
            {
                if(nome == item.Nome)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public static void excluir(List<Pessoa> listaPessoas, string nomeArquivo)
        {
            Console.WriteLine("Digite o nome a ser excluído:");
            string nome = Console.ReadLine();

            bool removeu = false;
            foreach(var item in listaPessoas)
            {
                if (nome == item.Nome)
                {
                    listaPessoas.Remove(item);
                    removeu= true;
                    break;
                }
            }
            if (removeu)
            {
                Persistencia.gravarListaArquivo(listaPessoas, nomeArquivo);
            }
            
        }

    }
}
