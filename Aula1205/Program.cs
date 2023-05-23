using Aula1205;


//List<Pessoa> listaPessoas = new List<Pessoa>();

//Persistencia.popularArquivoLista("C:\\Users\\mhgir\\source\\repos\\Aula1205\\dados.dat", listaPessoas);

//Persistencia.exibirLista(listaPessoas);

//string nome;
//string dataNascimento;
//Pessoa pessoa;

//for (int i = 0; i < 3; i++)
//{
//Console.Write("Nome: ");
//nome= Console.ReadLine();

//Console.Write("Nascimento: ");
//dataNascimento = Console.ReadLine();

//pessoa = new Pessoa(nome, dataNascimento);

//if (!listaPessoas.Contains(pessoa)) //???
//{
//    listaPessoas.Add(pessoa);
//    Persistencia.AtualizarPessoaArquivo(pessoa, "C:\\Users\\mhgir\\source\\repos\\Aula1205\\dados.dat");
//}
//else
//{
//    Console.WriteLine("Pessoa com este email já na base de dados.");
//}
//}
//Persistencia.gravarListaArquivo(listaPessoas, "C:\\Users\\mhgir\\source\\repos\\Aula1205\\dados.dat");

List<Pessoa> listaPessoas = new List<Pessoa>();
string nomeArquivo = "dados.dat";
Persistencia.popularArquivoLista(nomeArquivo, listaPessoas);
while (true)
{
    Console.WriteLine("Menu\n    1 - Cadastrar pessoa (controle de duplicidade: email)\n    2 - Listar pessoa\n    3 - Pesquisar pessoa (atributo nome)\n    4 - Excluir pessoa\n    5 - Sair");
    int op = int.Parse(Console.ReadLine());

    if (op == 1)
    {
        Console.WriteLine("Vamos cadastrar pessoa: ");
        Comunicacao.cadastrar(listaPessoas, nomeArquivo);
    }
    else if (op == 2)
    {
        Console.WriteLine("Listando pessoas");
        Comunicacao.listar(listaPessoas, nomeArquivo);
    }
    else if (op == 3)
    {
        Console.WriteLine("Pesquisando pessoa");
        Comunicacao.pesquisar(listaPessoas, nomeArquivo);
    }
    else if (op == 4)
    {
        Console.WriteLine("Excluindo pessoa");
        Comunicacao.excluir(listaPessoas, nomeArquivo);
    }
    else if (op == 5)
    {
        Console.WriteLine("Obrigado por usar o sistema.");
        break;
    }
    else
    {
        Console.WriteLine("Escolha entre as opções definidas");
    }
}
