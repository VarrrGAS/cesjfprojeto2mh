using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogisticaProdutos.ViewModel {
    public class UsuarioViewModel {
        public int? Id { get; set; }
        public string User { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
    }
}