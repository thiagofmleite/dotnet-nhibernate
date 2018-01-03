using LojaWeb.Entidades;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaWeb.DAO
{
    public class ProdutosDAO
    {
        private ISession session;

        public ProdutosDAO(ISession session)
        {
            this.session = session;
        }

        public void Adiciona(Produto produto)
        {
            ITransaction transaction = session.BeginTransaction();
            session.Save(produto);
            transaction.Commit();
        }

        public void Remove(Produto produto)
        {

        }

        public void Atualiza(Produto produto)
        {
            ITransaction transaction = session.BeginTransaction();
            session.Update(produto);
            transaction.Commit();
        }

        public Produto BuscaPorId(int id)
        {
            return null;
        }

        public IList<Produto> Lista()
        {
            string hql = "from Produto p order by p.Nome";
            IQuery query = session.CreateQuery(hql);
            IList<Produto> produtos = query.List<Produto>();

            return produtos;
        }

        public IList<Produto> ProdutosComPrecoMaiorDoQue(double? preco)
        {
            string hql = "from Produto p where p.Preco > :preco";
            IQuery query = session.CreateQuery(hql);
            query.SetParameter("preco", preco.GetValueOrDefault(0));

            IList<Produto> produtos = query.List<Produto>();

            return produtos;
        }

        public IList<Produto> ProdutosDaCategoria(string nomeCategoria)
        {
            string hql = "from Produto p where p.Categoria.Nome = :categoria";
            IQuery query = session.CreateQuery(hql);
            query.SetParameter("categoria", nomeCategoria);
            var produtos = query.List<Produto>();

            return produtos;
        }

        public IList<Produto> ProdutosDaCategoriaComPrecoMaiorDoQue(double? preco, string nomeCategoria)
        {
            string hql = "from Produto p where p.Preco > :preco and p.Categoria.Nome = :categoria";
            IQuery query = session.CreateQuery(hql);
            query.SetParameter("preco", preco.GetValueOrDefault(0));
            query.SetParameter("categoria", nomeCategoria);

            var produtos = query.List<Produto>();

            return produtos;
        }

        public IList<Produto> ListaPaginada(int paginaAtual)
        {
            string hql = "from Produtos p order by p.Nome";
            IQuery query = session.CreateQuery(hql);
            query.SetFirstResult(paginaAtual);
            query.SetMaxResults(10);

            return query.List<Produto>();
        }

        public IList<Produto> BuscaPorPrecoCategoriaENome(double? preco, string nomeCategoria, string nome)
        {
            ICriteria criteria = session.CreateCriteria<Produto>();

            if (!string.IsNullOrEmpty(nome))
            {
                criteria.Add(Restrictions.Eq("Nome", nome));
            }

            if (preco != null)
            {
                criteria.Add(Restrictions.Gt("Preco", preco.Value));
            }

            if (!string.IsNullOrEmpty(nomeCategoria)) 
            {
                ICriteria criteriaCategoria = criteria.CreateCriteria("Categoria");
                criteriaCategoria.Add(Restrictions.Eq("Nome", nomeCategoria));
            }

            return criteria.List<Produto>();
        }
    }
}