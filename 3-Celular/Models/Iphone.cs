namespace DesafioPOO.Models
{
    // TODO: Herdar da classe "Smartphone"
    public class Iphone : Smartphone
    {
        // TODO: Sobrescrever o método "InstalarAplicativo"
        public override void InstalarAplicativo(string nomeApp)
        {
            Console.WriteLine($"Instalando aplicativo {nomeApp} na App Store");
        }
        
        public Iphone(string numero, string modelo, string imei,  int memoria): base(numero, modelo, imei, memoria)
        {
        }
    }
}