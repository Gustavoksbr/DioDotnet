public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Olá de novo");
        
        int precoInicial = ObterInteiroDoUsuario("Qual será o preço inicial?");
        int precoPorHora = ObterInteiroDoUsuario("Qual será o preço por hora?");

        string opcao = "";
        List<Veiculo> lista = new List<Veiculo>();
        while (opcao != "5")
        {
            Console.WriteLine("\nDigite a sua opção:\n1- Cadastrar veículo\n2-Remover veículo\n3-Alterar veículos\n4-Listar veículos\n5-Encerrar\n");
            opcao = Console.ReadLine();
            switch (opcao)
            {
                case "1":
                    CadastrarVeiculo(lista);
                    break;

                case "2":
                    RemoverVeiculo(lista, precoInicial, precoPorHora);
                    break;

                case "3":
                    AlterarVeiculo(lista);
                    break;

                case "4":
                    ListarVeiculos(lista);
                    break;
            }
        }
    }

    private static void CadastrarVeiculo(List<Veiculo> lista)
    {
        string placa = ObterPlaca();
        if (lista.Exists(v => v.getPlaca().Equals(placa)))
        {
            Console.WriteLine("Já existe uma placa igual");
            return;
        }

        var veiculo = new Veiculo();
        veiculo.setPlaca(placa);
        lista.Add(veiculo);
        Console.WriteLine("Veículo cadastrado com sucesso.");
    }

    private static string ObterPlaca()
    {
        Console.WriteLine("Digite a placa do veículo:");
        return Console.ReadLine();
    }

    private static int ObterInteiroDoUsuario(string mensagem)
    {
        int valor;
        Console.WriteLine(mensagem);
        while (!int.TryParse(Console.ReadLine(), out valor))
        {
            Console.WriteLine("Por favor, digite um número válido.");
        }
        return valor;
    }

    private static void RemoverVeiculo(List<Veiculo> lista, int precoInicial, int precoPorHora)
    {
        string placa = ObterPlaca();
        var veiculo = lista.Find(v => v.getPlaca().Equals(placa));
        if (veiculo != null)
        {
            lista.Remove(veiculo);
            int horas = ObterInteiroDoUsuario("Quantas horas o veículo ficou estacionado?");
            int totalAPagar = precoInicial + (horas * precoPorHora);
            Console.WriteLine($"Você terá de pagar {totalAPagar}");
        }
        else
        {
            Console.WriteLine("Veículo não encontrado");
        }
    }

    private static void AlterarVeiculo(List<Veiculo> lista)
    {
        string placa = ObterPlaca();
        var veiculo = lista.Find(v => v.getPlaca().Equals(placa));
        if (veiculo != null)
        {
            Console.WriteLine("Digite a nova placa:");
            string novaPlaca = Console.ReadLine();
            veiculo.setPlaca(novaPlaca);
            Console.WriteLine("Placa alterada com sucesso.");
        }
        else
        {
            Console.WriteLine("Veículo não encontrado");
        }
    }

    private static void ListarVeiculos(List<Veiculo> lista)
    {
        if (lista.Count > 0)
        {
            Console.WriteLine("Veículos cadastrados:");
            foreach (Veiculo v in lista)
            {
                Console.WriteLine($"Veículo de placa: {v.getPlaca()}");
            }
        }
        else
        {
            Console.WriteLine("Nenhum veículo cadastrado.");
        }
    }
}