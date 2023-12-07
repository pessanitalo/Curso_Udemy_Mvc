using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lanches_Mac.Models
{
    public class Pedido
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Nome { get; set; }

        [StringLength(50)]
        public string Sobrenome { get; set; }

        [StringLength(100)]
        public string Endereco1 { get; set; }

        [StringLength(100)]
        public string Endereco2 { get; set; }

        [StringLength(10, MinimumLength =8)]
        public string Cep { get; set; }

        [StringLength(10)]
        public string Estado { get; set; }

        [StringLength(50)]
        public string Cidade { get; set; }

        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }

        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [ScaffoldColumn(false)]
        [Column(TypeName ="decimal(18,2)")]
        [DataType(DataType.EmailAddress)]
        public decimal TotalPedido { get; set; }

        [ScaffoldColumn(false)]
        public decimal TotalItensPedido { get; set; }


        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime PedidoEnviado { get; set; }


        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public decimal PedidoEntregue { get; set; }


        public List<PedidoDetalhe> PedidoItens { get; set; }



    }
}
