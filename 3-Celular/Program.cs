using DesafioPOO.Models;

namespace DesafioPOO
{
    class Program
    {
        static void Main(string[] args)
        {
            Smartphone nokia = new Nokia("123456789", "Nokia 3310", "123456789", 16);
            nokia.Ligar();
            nokia.ReceberLigacao();
            nokia.InstalarAplicativo("Cobrinha");

            Console.WriteLine("\n");

            Smartphone iphone = new Iphone("987654321", "Iphone 12", "987654321", 128);
            iphone.Ligar();
            iphone.ReceberLigacao();
            iphone.InstalarAplicativo("WhatsApp");

        }
    }
}
