namespace Test.Models
{
    public class Personagem
    {
        public int Id { get; set; } 
        public string Nome { get; set; } = "Schev";
        public int PontosDeDano { get; set; } = 100;
        public int Forca { get; set; } = 100;
        public int Defesa { get; set; } = 100;
        public int Inteligencia { get; set; } = 50;
        //Personagem padrão
        public RpgClass Classe {get; set;} = RpgClass.Cavalheiro;
    }
}