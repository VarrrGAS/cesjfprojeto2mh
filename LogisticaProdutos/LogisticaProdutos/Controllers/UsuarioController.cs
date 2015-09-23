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
    public class UsuarioController : AccountController
    {
        BebidasDB db = new BebidasDB();

        public ActionResult Lista()
        {
            List<UsuarioViewModel> lista = new List<UsuarioViewModel>();
            List<Usuario> listaDB = new List<Usuario>();
            listaDB = db.Usuario.ToList();

            foreach (Usuario item in listaDB) {
                UsuarioViewModel user = new UsuarioViewModel();
                user.Id = item.Id;
                user.Nome = item.Nome;
                user.CPF = item.CPF;
                lista.Add(user);
            }

            return View(lista);
        }

        public void CreateUser(UsuarioViewModel user) {
            Usuario usuario = new Usuario();
            usuario.CPF = user.CPF;
            usuario.Nome = user.Nome;
            usuario.User = user.User;

            db.Usuario.Add(usuario);
            db.SaveChanges();
        }

        public ActionResult Excluir(int Id) {
            Usuario usuario = db.Usuario.Find(new object[]{ Id });
            db.Usuario.Remove(usuario);
            Membership.DeleteUser(usuario.User);
            db.SaveChanges();
            return RedirectToAction("Lista");
        }

        public ActionResult Editar(int Id) {
            Usuario usuario = db.Usuario.Find(new object[] { Id });
            UsuarioViewModel usuarioViewModel = new UsuarioViewModel();
            usuarioViewModel.Nome = usuario.Nome;
            usuarioViewModel.CPF = usuario.CPF;
            return View(usuarioViewModel);
        }

        [HttpPost]
        public ActionResult Editar(UsuarioViewModel user) {
            Usuario usuario = db.Usuario.Find(new object[] { user.Id });
            usuario.Nome = user.Nome;
            usuario.CPF = user.CPF;
            db.Entry(usuario).State = System.Data.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Lista");
        }

    }
}
