using LojaWeb.DAO;
using LojaWeb.Entidades;
using LojaWeb.Infra;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaWeb.Controllers
{
    public class UsuariosController : Controller
    {

        //
        // GET: /Usuarios/

        public ActionResult Index()
        {
            IList<Usuario> usuarios = new List<Usuario>();
            return View(usuarios);
        }

        public ActionResult Form()
        {
            return View();
        }

        public ActionResult Adiciona(Usuario usuario)
        {
            ISession session = NHibernateHelper.AbreSession();
            UsuariosDAO dao = new UsuariosDAO(session);
            dao.Adiciona(usuario);
            session.Close();

            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
            return RedirectToAction("Index");
        }

        public ActionResult Visualiza(int id)
        {
            Usuario usuario = new Usuario();
            return View(usuario);
        }

        public ActionResult Atualiza(Usuario usuario)
        {
            ISession session = NHibernateHelper.AbreSession();
            UsuariosDAO dao = new UsuariosDAO(session);
            dao.Atualiza(usuario);
            session.Close();

            return RedirectToAction("Index");
        }

    }
}
