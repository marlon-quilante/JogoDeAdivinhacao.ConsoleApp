namespace JogoDeAdivinhacao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Jogo de Adivinhação");
            Console.WriteLine("---------------------------------");

            Console.Write("Digite um número para chutar: ");
            int numeroDigitado = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nVocê digitou o número: " + numeroDigitado);

            Console.ReadLine();
        }
    }
}
