namespace JogoDeAdivinhacao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Jogo de Adivinhação");
                Console.WriteLine("---------------------------------");

                //escolha de nível de dificuldade
                Console.WriteLine("Escolha um nível de dificuldade:");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("1 - Fácil (10 tentativas)");
                Console.WriteLine("2 - Normal (5 tentativas)");
                Console.WriteLine("3 - Difícil (3 tentativas)");
                Console.WriteLine("---------------------------------");

                Console.Write("Digite sua escolha: ");
                string escolhaDeDificuldade = Console.ReadLine();

                int totalDeTentativas = 0;

                if (escolhaDeDificuldade == "1")
                {
                    totalDeTentativas = 10;
                }
                else if (escolhaDeDificuldade == "2")
                {
                    totalDeTentativas = 5;
                }
                else if (escolhaDeDificuldade == "3")
                {
                    totalDeTentativas = 3;
                }
                else
                {
                    Console.Write("\nOpção inválida! Pressione qualquer tecla para continuar...");
                    Console.ReadLine();
                    continue;
                }

                //escolha do número aleatório
                Random geradorDeNumeros = new Random();

                int numeroSecreto = geradorDeNumeros.Next(1, 21);

                List<int> numerosChutados = new List<int>();

                //lógica do jogo
                for (int tentativa = 1; tentativa <= totalDeTentativas; tentativa++)
                {
                    Console.Clear();

                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine($"Tentativa {tentativa} de {totalDeTentativas}");
                    Console.WriteLine("-----------------------------------");
                    Console.Write($"Números chutados: ");

                    foreach (int numeroChutado in numerosChutados)
                    {
                        Console.Write(numeroChutado + " ");
                    }

                    Console.Write("\n\nChute um número: ");
                    int numeroDigitado = Convert.ToInt32(Console.ReadLine());

                    while (numerosChutados.Contains(numeroDigitado))
                    {
                        Console.WriteLine("\nEsse número já foi chutado anteriormente.");
                        Console.Write("\nChute outro número: ");
                        numeroDigitado = Convert.ToInt32(Console.ReadLine());
                    }

                    if (numeroDigitado == numeroSecreto)
                    {
                        Console.WriteLine("\n-----------------------------------");
                        Console.WriteLine("Parabéns, você acertou o número secreto!");
                        Console.WriteLine("-----------------------------------");
                        break;
                    }
                    else if (numeroDigitado != numeroSecreto && tentativa == totalDeTentativas)
                    {
                        Console.WriteLine("\n-----------------------------------");
                        Console.WriteLine($"Game over! O número secreto era: {numeroSecreto}");
                        Console.WriteLine("-----------------------------------");
                        break;
                    }

                    else if (numeroDigitado > numeroSecreto)
                    {
                        Console.WriteLine("\n----------------------------------------------");
                        Console.WriteLine("O número digitado é maior que o número secreto!");
                        Console.WriteLine("----------------------------------------------");
                        numerosChutados.Add(numeroDigitado);
                    }
                    else if (numeroDigitado < numeroSecreto)
                    {
                        Console.WriteLine("\n----------------------------------------------");
                        Console.WriteLine("O número digitado é menor que o número secreto!");
                        Console.WriteLine("----------------------------------------------");
                        numerosChutados.Add(numeroDigitado);
                    }
                    Console.Write("\nPressione qualquer tecla para continuar...");
                    Console.ReadLine();
                }

                Console.Write("\nDeseja jogar novamente? S/N: ");

                string continuar = Console.ReadLine().ToUpper();

                if (continuar == "S")
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("\nJogo encerrado, até mais!\n");
                    break;
                }
            }
        }
    }
}