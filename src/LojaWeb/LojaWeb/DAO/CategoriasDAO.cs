using LojaWeb.Entidades;
using LojaWeb.Models;
using NHibernate;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaWeb.DAO
{
    public class CategoriasDAO
    {
        private ISession session;

        public CategoriasDAO(ISession session)
        {
            this.session = session;
        }

        public void Adiciona(Categoria categoria)
        {
            ITransaction trascation = session.BeginTransaction();
            session.Save(categoria);
            trascation.Commit();
        }

        public void Remove(Categoria categoria)
        {
            ITransaction transaction = session.BeginTransaction();
            session.Delete(categoria);
            transaction.Commit();
        }

        public void Atualiza(Categoria categoria)
        {
            ITransaction transaction = session.BeginTransaction();
            session.Update(categoria);
            transaction.Commit();
        }

        public Categoria BuscaPorId(int id)
        {
            return session.Get<Categoria>(id);
        }

        public IList<Categoria> Lista()
        {
            string hql = "select c from Categoria c join fetch c.Produtos";
            IQuery query = session.CreateQuery(hql);
            IList<Categoria> categorias = query.List<Categoria>();

            return categorias;
        }

        public IList<Categoria> BuscaPorNome(string nome)
        {
            string hql = "from Categoria c where c.Nome = :nome";
            IQuery query = session.CreateQuery(hql);
            query.SetParameter("nome", nome);

            var categorias = query.List<Categoria>();

            return categorias;
        }

        public IList<ProdutosPorCategoria> ListaNumeroDeProdutosPorCategoria()
        {
            string hql = "select p.Categoria as Categoria, count(p) as NumeroDeProdutos from Produto p group by p.Categoria";
            IQuery query = session.CreateQuery(hql);

            query.SetResultTransformer(Transformers.AliasToBean<ProdutosPorCategoria>());
            IList<ProdutosPorCategoria> lista = query.List<ProdutosPorCategoria>();

            return lista;
        }
    }

}