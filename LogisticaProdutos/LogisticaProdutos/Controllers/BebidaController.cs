using LogisticaProdutos.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LogisticaProdutos.Controllers
{
    [Authorize(Roles="Admin")]
    public class BebidaController : AccountController
    {
        BebidasDB db = new BebidasDB();

        public ActionResult Lista()
        {
            List<BebidaViewModel> lista = new List<BebidaViewModel>();
            List<Bebida> listaDB = new List<Bebida>();
            listaDB = db.Bebida.ToList();

            foreach (Bebida item in listaDB) {
                BebidaViewModel bebidaViewModel = new BebidaViewModel();
                bebidaViewModel.Nome = item.Nome;
                bebidaViewModel.Id = item.Id;
                bebidaViewModel.IdTipoBebida = item.IdTipoBebida;
                bebidaViewModel.TipoBebida = item.TipoBebida;
                bebidaViewModel.Transacao = item.Transacao;
                lista.Add(bebidaViewModel);
            }

            return View(lista);
        }

        [HttpPost]
        public ActionResult Create(BebidaViewModel bebidaViewModel) {

            if (!ModelState.IsValid) {
                bebidaViewModel.TipoBebidaList = db.TipoBebida.ToList();
                return View(bebidaViewModel);
            }


            Bebida bebida = new Bebida();

            bebida.Nome = bebidaViewModel.Nome;
            bebida.IdTipoBebida = bebidaViewModel.IdTipoBebida.Value;

            db.Bebida.Add(bebida);
            db.SaveChanges();

            return RedirectToAction("Lista");
        }


        public ActionResult Create() {
            BebidaViewModel bebidaViewModel = new BebidaViewModel();
            bebidaViewModel.TipoBebidaList = db.TipoBebida.ToList();

            return View(bebidaViewModel);
        }

        public ActionResult Excluir(int Id) {
            Bebida bebida = db.Bebida.Find(new object[]{ Id });
            db.Bebida.Remove(bebida);
            db.SaveChanges();
            return RedirectToAction("Lista");
        }

        public ActionResult Editar(int Id) {
            Bebida bebida = db.Bebida.Find(new object[] { Id });
            BebidaViewModel bebidaViewModel = new BebidaViewModel();
            bebidaViewModel.Nome = bebida.Nome;
            bebidaViewModel.Id = bebida.Id;
            bebidaViewModel.IdTipoBebida = bebida.IdTipoBebida;
            bebidaViewModel.TipoBebida = bebida.TipoBebida;
            bebidaViewModel.Transacao = bebida.Transacao;
            bebidaViewModel.TipoBebidaList = db.TipoBebida.ToList();

            return View(bebidaViewModel);
        }

        [HttpPost]
        public ActionResult Editar(BebidaViewModel bebidaViewModel) {
            Bebida bebida = db.Bebida.Find(new object[] { bebidaViewModel.Id });
            bebida.Nome = bebidaViewModel.Nome;
            bebida.Id = bebidaViewModel.Id.Value;
            bebida.IdTipoBebida = bebidaViewModel.IdTipoBebida.Value;
            bebida.TipoBebida = bebidaViewModel.TipoBebida;
            bebida.Transacao = bebidaViewModel.Transacao;
            db.Entry(bebida).State = System.Data.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Lista");
        }

        [HttpPost]
        public ActionResult RealizarTransacao(EstoqueViewModel estoque){

            Transacao transacao = new Transacao();

            transacao.IdBebida = estoque.BebidaId;
            transacao.Qtd += estoque.TipoTransacao == "Entrada" ? estoque.Quantidade : -estoque.Quantidade;

            string userName = Membership.GetUser().UserName;
            List<Usuario> users = db.Usuario.ToList();
            Usuario user = db.Usuario.FirstOrDefault(x => x.User == userName);

            transacao.Usuario = user;
            transacao.IdUsuario = user.Id;
            transacao.TipoTransacao = db.TipoTransacao.FirstOrDefault(x => x.Tipo == estoque.TipoTransacao);

            db.Transacao.Add(transacao);
            db.SaveChanges();

            return RedirectToAction("Index","Home");
        }

    }
}
