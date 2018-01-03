using LojaNHibernate.Entidades;
using LojaNHibernate.Infra;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaNHibernate.DAO
{
    public class UsuarioDAO
    {
        private ISession session;

        public UsuarioDAO(ISession session)
        {
            this.session = session;
        }

        public void Adiciona(Usuario usuario)
        {
            ITransaction transacao = session.BeginTransaction();
            session.Save(usuario);
            transacao.Commit();
        }

        public Usuario BuscaPorId(int id)
        {
            return session.Get<Usuario>(id);
        }

        public void Apaga(Usuario usuario)
        {
            ITransaction transacao = session.BeginTransaction();
            session.Delete(usuario);
            transacao.Commit();
        }
    }
}
