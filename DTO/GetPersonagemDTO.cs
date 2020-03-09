using Test.Models;

namespace Test.DTO
{
    public class GetPersonagemDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = "Schev";
        public int PontosDeDano { get; set; } = 100;
        public int Forca { get; set; } = 10;
        public int Defesa{ get; set; } = 10;
        public int Inteligencia { get; set; } = 10;
        public RpgClass Classe { get; set; } = RpgClass.Cavalheiro;
    }
}