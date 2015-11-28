using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LogisticaProdutos.ViewModel {
    public class EstoqueViewModel {

        public EstoqueViewModel() {
            Bebidas = new List<BebidaViewModel>();
        }

        public List<BebidaViewModel> Bebidas { get; set; }

        [Required, Display(Name = "Bebida")]
        public int BebidaId { get; set; }
        public List<Bebida> BebidaList { get; set; }
        [Required]
        public int Quantidade { get; set; }
        [Required]
        public string TipoTransacao { get; set; }

    }
}