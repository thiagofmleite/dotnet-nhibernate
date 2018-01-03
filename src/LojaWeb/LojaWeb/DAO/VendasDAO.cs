using LojaWeb.Entidades;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaWeb.DAO
{
    public class VendasDAO
    {
        private ISession session;

        public VendasDAO(ISession session)
        {
            this.session = session;
        }

        public void Adiciona(Venda venda)
        {
            ITransaction transaction = session.BeginTransaction();
            session.Save(venda);
            transaction.Commit();
        }

        public IList<Venda> Lista()
        {
            string hql = "from Venda";
            IQuery query = session.CreateQuery(hql);
            IList<Venda> vendas = query.List<Venda>();

            return vendas;
        }
    }
}