using System.Diagnostics;

namespace JogoDeAdivinhacao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Sistema de pontuação: Pontos perdidos = (número chutado - número aleatório) / 2

            while (true)
            {
                string escolhaDeDificuldade = Menu();

                List<int> numerosChutados = new List<int>();
                int pontuacao = 1000;

                int numeroAleatorio = NumeroAleatorio();

                //lógica do jogo
                for (int tentativa = 1; tentativa <= QuantidadeDeTentativas(escolhaDeDificuldade); tentativa++)
                {
                    int pontosPerdidos = 0;

                    //Cabeçalho do jogo
                    ExibirCabecalho(tentativa, escolhaDeDificuldade, pontuacao, numerosChutados, numeroAleatorio);

                    //Chute de número
                    int numeroDigitado = ChutarNumero();

                    while (NumeroChutadoAnteriormente(numerosChutados, numeroDigitado))
                    {
                        numeroDigitado = ChutarOutroNumero();
                    }

                    if (JogadorAcertou(numeroDigitado, pontuacao, numeroAleatorio))
                    {
                        MensagemDeVitoria(pontuacao);
                        break;
                    }
                    else if (JogadorNaoAcertou(numeroDigitado, tentativa, escolhaDeDificuldade, pontuacao, numeroAleatorio))
                    {
                        MensagemDeDerrota(pontuacao, numeroAleatorio);
                        break;
                    }
                    else if (ChuteMaiorQueNumero(numeroDigitado, numeroAleatorio))
                    {
                        MensagemChuteMaiorQueNumero();
                        pontuacao -= PontuacaoAtualizada(numeroDigitado, numerosChutados, pontosPerdidos, numeroAleatorio);
                    }
                    else if (ChuteMenorQueNumero(numeroDigitado, numeroAleatorio))
                    {
                        MensagemChuteMenorQueNumero();
                        pontuacao -= PontuacaoAtualizada(numeroDigitado, numerosChutados, pontosPerdidos, numeroAleatorio);
                    }

                    Console.Write("\nPressione qualquer tecla para continuar...");
                    Console.ReadLine();
                }
                if (JogarNovamente() == "S")
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("\nJogo encerrado, até mais!\n");
                    Console.ReadLine();
                    break;
                }
            }
        }

        static string Menu()
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Jogo de Adivinhação");
            Console.WriteLine("---------------------------------");

            Console.WriteLine("Escolha um nível de dificuldade:");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1 - Fácil (10 tentativas)");
            Console.WriteLine("2 - Normal (5 tentativas)");
            Console.WriteLine("3 - Difícil (3 tentativas)");
            Console.WriteLine("---------------------------------");

            Console.Write("Digite sua escolha: ");
            return Console.ReadLine();
        }

        static int QuantidadeDeTentativas(string escolhaDeDificuldade)
        {
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
            }
            return totalDeTentativas;
        }

        static int NumeroAleatorio()
        {
            Random geradorDeNumeros = new Random();
            int numeroSecreto = geradorDeNumeros.Next(1, 21);

            return numeroSecreto;
        }

        static string JogarNovamente()
        {
            Console.Write("\nDeseja jogar novamente? S/N: ");
            return Console.ReadLine().ToUpper();
        }

        static void ExibirCabecalho(int tentativa, string escolhaDeDificuldade, int pontuacao, List<int> numerosChutados, int numeroAleatorio)
        {
            Console.Clear();
            Debug.WriteLine("Número secreto: " + numeroAleatorio);
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"Tentativa {tentativa} de {QuantidadeDeTentativas(escolhaDeDificuldade)}");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"Pontuação atual: {pontuacao}");
            Console.WriteLine("-----------------------------------");
            Console.Write($"Números chutados: ");
            foreach (int numeroChutado in numerosChutados)
            {
                Console.Write(numeroChutado + " ");
            }
            Console.WriteLine("\n-----------------------------------");
        }

        static bool JogadorAcertou(int numeroDigitado, int pontuacao, int numeroAleatorio)
        {
            if (numeroDigitado == numeroAleatorio)
            {
                return true;
            }
            return false;
        }

        static void MensagemDeVitoria(int pontuacao)
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"Parabéns, você acertou o número secreto e finalizou o jogo com {pontuacao} pontos!");
            Console.WriteLine("-----------------------------------");
        }

        static bool JogadorNaoAcertou(int numeroDigitado, int tentativa, string escolhaDeDificuldade, int pontuacao, int numeroAleatorio)
        {
            if (numeroDigitado != numeroAleatorio && tentativa == QuantidadeDeTentativas(escolhaDeDificuldade))
            {
                return true;
            }
            return false;
        }

        static void MensagemDeDerrota(int pontuacao, int numeroAleatorio)
        {
            pontuacao = 0;
            Console.Clear();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"Game over! O número secreto era: {numeroAleatorio}");
            Console.WriteLine($"Você finalizou o jogo com {pontuacao} pontos!");
            Console.WriteLine("-----------------------------------");
        }

        static bool ChuteMaiorQueNumero(int numeroDigitado, int numeroAleatorio)
        {
            if (numeroDigitado > numeroAleatorio)
            {
                return true;
            }
            return false;
        }

        static void MensagemChuteMaiorQueNumero()
        {
            Console.WriteLine("\n----------------------------------------------");
            Console.WriteLine("O número digitado é maior que o número secreto!");
            Console.WriteLine("----------------------------------------------");
        }

        static bool ChuteMenorQueNumero(int numeroDigitado, int numeroAleatorio)
        {
            if (numeroDigitado < numeroAleatorio)
            {
                return true;
            }
            return false;
        }

        static void MensagemChuteMenorQueNumero()
        {
            Console.WriteLine("\n----------------------------------------------");
            Console.WriteLine("O número digitado é menor que o número secreto!");
            Console.WriteLine("----------------------------------------------");
        }

        static int PontuacaoAtualizada(int numeroDigitado, List<int> numerosChutados, int pontosPerdidos, int numeroAleatorio)
        {
            if (ChuteMaiorQueNumero(numeroDigitado, numeroAleatorio) || ChuteMenorQueNumero(numeroDigitado, numeroAleatorio))
            {
                numerosChutados.Add(numeroDigitado);
                pontosPerdidos = (numeroDigitado - numeroAleatorio) / 2;
                if (pontosPerdidos < 0)
                {
                    pontosPerdidos *= -1;
                }
                if (pontosPerdidos < 1)
                {
                    pontosPerdidos = 1;
                }
            }
            return pontosPerdidos;
        }

        static int ChutarNumero()
        {
            Console.Write("\nChute um número: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        static bool NumeroChutadoAnteriormente(List<int> numerosChutados, int numeroDigitado)
        {
            if (numerosChutados.Contains(numeroDigitado))
            {
                return true;
            }
            return false;
        }

        static int ChutarOutroNumero()
        {
            Console.WriteLine("\nEsse número já foi chutado anteriormente.");
            Console.Write("\nChute outro número: ");
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}