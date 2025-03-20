namespace JogoDeAdivinhacao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Jogo de Adivinhação");
            Console.WriteLine("---------------------------------");

            Random geradorDeNumeros = new Random();

            int numeroSecreto = geradorDeNumeros.Next(1, 21);

            Console.Write("Digite um número para chutar: ");
            int numeroDigitado = Convert.ToInt32(Console.ReadLine());

            if (numeroDigitado == numeroSecreto)
            {
                Console.WriteLine("\n---------------------------------");
                Console.WriteLine("Parabéns, você acertou!");
                Console.WriteLine("-----------------------------------");
            }
            else if (numeroDigitado > numeroSecreto)
            {
                Console.WriteLine("\n---------------------------------");
                Console.WriteLine("O número digitado é maior que o número secreto!");
                Console.WriteLine("-----------------------------------");
            }
            else if (numeroDigitado < numeroSecreto)
            {
                Console.WriteLine("\n---------------------------------");
                Console.WriteLine("O número digitado é menor que o número secreto!");
                Console.WriteLine("-----------------------------------");
            }

            Console.ReadLine();
        }
    }
}