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

            Console.WriteLine("\nVocê digitou o número: " + numeroDigitado);
            Console.WriteLine("\nO número secreto é: " + numeroSecreto);

            Console.ReadLine();
        }
    }
}
