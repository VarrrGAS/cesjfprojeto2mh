using LogisticaProdutos.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LogisticaProdutos.Controllers {
    [Authorize]
    public class HomeController : Controller {

        BebidasDB db = new BebidasDB();

        public ActionResult Index() {

            EstoqueViewModel estoque = new EstoqueViewModel();
            List<Bebida> bebidas = db.Bebida.ToList();

            foreach (Bebida item in bebidas) {
                BebidaViewModel bebida = new BebidaViewModel();
                bebida.Nome = item.Nome;
                if (db.Transacao.Any())
                    bebida.Quantidade = db.Transacao.Where(x => x.IdBebida == item.Id).Sum(x => x.Qtd);
                else
                    bebida.Quantidade = 0;

                bebida.TipoBebida = item.TipoBebida;

                estoque.Bebidas.Add(bebida);
            }

            return View(estoque);
        }
    }
}
