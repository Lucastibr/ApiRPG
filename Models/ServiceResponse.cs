
namespace Test.Models
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }

        public bool Sucesso {get; set; }

        public string Message {get; set; }
    }
}