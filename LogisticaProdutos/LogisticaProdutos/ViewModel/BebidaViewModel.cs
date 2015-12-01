using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LogisticaProdutos.ViewModel {
    public class BebidaViewModel {

        public BebidaViewModel() {
            TipoBebidaList = new List<TipoBebida>();
            TipoBebida = new TipoBebida();
        }

        public int? Id { get; set; }
        [Required]
        public int? IdTipoBebida { get; set; }
        [Required]
        public string Nome { get; set; }

        public int Quantidade { get; set; }

        public List<TipoBebida> TipoBebidaList { get; set; }

        public TipoBebida TipoBebida { get; set; }
        public ICollection<Transacao> Transacao { get; set; }
    }
}