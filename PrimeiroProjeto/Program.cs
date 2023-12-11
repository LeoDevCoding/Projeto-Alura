// Screen Sound
//a viariável mensagemDeBoasVindas está recebebendo o valor "Boas vindas ao Screen Sound" e está sendo chamada dentro do Console.WriteLine(mDbV);
string mensagemDeBoasVindas = "Boas vindas ao Screen Sound";
//List<string> ListaDasBandas = new List<string> { "Iron Maiden", "Metalica", "Judas Prist"};
Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Linkin Park", new List<int> { 10, 9, 6 });
bandasRegistradas.Add("Audioslave", new List<int> { 10, 6, 4});

//função void não retorna valor algum
void ExibirLogo()
{
    //Verbatin Literal (@) trás a string da forma que ela é
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");  
    Console.WriteLine(mensagemDeBoasVindas);
}


void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média das bandas");
    Console.WriteLine("Digite -1 para sair");

    // o Console.Write() serve para escrever o texto na mesma linha do argumento do Console.WriteLine.
    Console.Write("\nDigite uma opção: "); 
    // o Console.RedLine() serve para ler valores vindo do Console.WriteLine(). Junto dele vai a variável para atribuir valor de escolha.
    string opcaoEscolhida = Console.ReadLine()!;
    // o int.Parse converte string para inteiro.
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida)!;
   
    switch (opcaoEscolhidaNumerica)
    {
        case 1:
            RegistrarBandas();
            break;
        case 2:
            MostrarBandasRegistradas();
            break;
        case 3:
            AvaliarUmaBanda();
            break;
        case 4:
            ExibirMediaBanda();
            break;
        case -1:
            Console.WriteLine("Até mais ;) !!!");
            break;
        default:
            Console.WriteLine("Opção invalida!");
            break;
    }

    void RegistrarBandas()
    {
        Console.Clear();
        ExibirTituloDaOpcao("Registro de bandas");
        Console.WriteLine("Digite o nome da banda que deseja registrar: ");
        string nomeDaBanda = Console.ReadLine()!;
        bandasRegistradas.Add(nomeDaBanda, new List<int>());
        Console.WriteLine($"A banda {nomeDaBanda} foi registrada");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirOpcoesDoMenu();
    }

}

void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibindo todas as bandas registradas na nossa aplicação");
    //for (int i = 0; i < ListaDasBandas.Count; i++)
    //{
        //Console.WriteLine($"Bandas: {ListaDasBandas[i]}");
    //}

    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Bandas: {banda}");
    }
    Console.WriteLine("\nDigite uma tecla para voltar ao menu pricnpal!");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}
void AvaliarUmaBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Avaliar banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"Qual a nota que a banda {nomeDaBanda} merece: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {nomeDaBanda}");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
        Console.WriteLine("Digite uma tecla para voltar ao menu!");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    } 
    
}

void ExibirMediaBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibir media das bandas!");
    Console.Write("Qual banda você deseja ver a média de avaliação: ");
    string nomeBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeBanda))
    {
        List<int> notasDaBanda = bandasRegistradas[nomeBanda];
        Console.WriteLine($"\nA média da banda {nomeBanda} é {notasDaBanda.Average()}.");
        Console.WriteLine("Aperte qualquer tecla para voltar ao menu!");
        Console.ReadKey();
        Console.Clear();    
        ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine($"A banda {nomeBanda} não foi encontrada!");
        Console.WriteLine("Digite uma tecla para voltar ao menu!");
        Console.ReadKey(); 
        Console.Clear();
        ExibirOpcoesDoMenu();

    }

}

    ExibirOpcoesDoMenu();

