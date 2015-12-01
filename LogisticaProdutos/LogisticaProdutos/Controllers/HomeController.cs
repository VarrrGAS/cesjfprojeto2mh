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
            List<RelatorioViewModel> relatorio = new List<RelatorioViewModel>();

            foreach (Bebida item in bebidas) {
                int quantidade = 0;
                BebidaViewModel bebida = new BebidaViewModel();
                bebida.Nome = item.Nome;
                if (db.Transacao.Any()) {
                    foreach (var transacao in db.Transacao.Where(x => x.IdBebida == item.Id).ToList())
	                {
                        quantidade += transacao.Qtd;
	                }
                    bebida.Quantidade = quantidade;
                } else
                    bebida.Quantidade = 0;

                bebida.TipoBebida = item.TipoBebida;

                estoque.Bebidas.Add(bebida);
            }

            estoque.BebidaList = bebidas;


            List<Transacao> transacoes = db.Transacao.ToList();

            foreach (Transacao item in transacoes) {
                RelatorioViewModel itemRelat = new RelatorioViewModel();
                itemRelat.Bebida = item.Bebida;
                itemRelat.Qtd = item.Qtd;
                itemRelat.TipoTransacao = item.TipoTransacao.Tipo;
                relatorio.Add(itemRelat);
            }

            estoque.Relatorio = relatorio;
            return View("Index",estoque);
        }
    }
}
