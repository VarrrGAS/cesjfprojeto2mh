using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogisticaProdutos.ViewModel {
    public class RelatorioViewModel {

        public RelatorioViewModel() {
            this.Bebida = new Bebida();
        }

        public Bebida Bebida { get; set; }

        public string TipoTransacao { get; set; }

        public int Qtd { get; set; }

    }
}