using VideojuegoAPI.Domain.Core;

namespace VideojuegoAPI.Domain.Entities
{
    public class Producto : BaseEntity
    {
      
        public string Nombre { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public decimal Precio { get; set; }
    }
}