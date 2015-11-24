using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogisticaProdutos.ViewModel {
    public class EstoqueViewModel {

        public EstoqueViewModel() {
            Bebidas = new List<BebidaViewModel>();
        }


        public List<BebidaViewModel> Bebidas { get; set; }
        

    }
}