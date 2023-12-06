using System.ComponentModel.DataAnnotations;

namespace Lanches_Mac.Models
{
    public class CarrinhoItem
    {
        public int Id { get; set; }
        public Lanche Lanche { get; set; }

        public int Quantidade { get; set; }

        [StringLength(200)]
        public string CarrinhoId { get; set; }
    }
}
