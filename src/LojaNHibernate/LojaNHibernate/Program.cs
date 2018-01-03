using LojaNHibernate.DAO;
using LojaNHibernate.Entidades;
using LojaNHibernate.Infra;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaNHibernate
{
    class Program
    {
        static void Main(string[] args)
        {
            //ISession session = NHibernateHelper.AbreSession();
            ////string hql = "from Produto p where p.Preco > :minimo and p.Categoria.Nome = :categoria";
            //string hql = "select p.Categoria as Categoria, count(p) as NumeroDePedidos from Produto p group by p.Categoria";
            //IQuery query = session.CreateQuery(hql);
            ////query.SetParameter("minimo", 10);
            ////query.SetParameter("categoria", "Uma Categoria");

            //query.SetResultTransformer(Transformers.AliasToBean<ProdutosPorCategoria>());

            //IList<ProdutosPorCategoria> relatorio = query.List<ProdutosPorCategoria>();

            //foreach (var item in relatorio)
            //{
            //    Console.WriteLine("{0} : {1}", item.Categoria.Nome, item.NumeroDePedidos.ToString());
            //}


            //ISession session = NHibernateHelper.AbreSession();
            //IQuery query = session.CreateQuery("from Produto p join fetch p.Categoria");
            //IList<Produto> produtos = query.List<Produto>();

            //foreach (Produto produto in produtos)
            //{
            //    Console.WriteLine("{0} | {1}", produto.Nome, produto.Categoria.Nome);
            //}


            //session.Close();

            //Console.Read();

            //ISession session = NHibernateHelper.AbreSession();
            //IQuery query = session.CreateQuery("select distinct c from Categoria c join fetch c.Produtos");
            //IList<Categoria> categorias = query.List<Categoria>();

            //foreach (var item in categorias)
            //{
            //    Console.WriteLine("{0} | {1}", item.Nome, item.Produtos.Count);
            //}


            //ISession session = NHibernateHelper.AbreSession();
            //ProdutoDAO dao = new ProdutoDAO(session);
            //IList<Produto> produtos = dao.BuscaPorNomePrecoMinimoECategoria("", 100, "");

            //foreach (var item in produtos)
            //{
            //    Console.WriteLine("{0} | {1} | {2}", item.Nome, item.Preco, item.Categoria.Nome);
            //}

            //ISession session = NHibernateHelper.AbreSession();
            //ISession session2 = NHibernateHelper.AbreSession();

            //session.CreateQuery("from Usuario").SetCacheable(true).List<Usuario>();
            //session2.CreateQuery("from Usuario").SetCacheable(true).List<Usuario>();

            //ISession session = NHibernateHelper.AbreSession();
            //ITransaction transaction = session.BeginTransaction();

            //Venda venda = new Venda();
            //Usuario cliente = session.Get<Usuario>(1);
            //venda.Cliente = cliente;

            //Produto p1 = session.Get<Produto>(1);
            //Produto p2 = session.Get<Produto>(2);

            //venda.Produtos.Add(p1);
            //venda.Produtos.Add(p2);

            //session.Save(venda);

            //transaction.Commit();

            //NHibernateHelper.GeraSchema();

            ISession session = NHibernateHelper.AbreSession();

            PessoaFisica pf = new PessoaFisica();
            pf.Nome = "Murilo";
            pf.CPF = "123.456.789-00";

            PessoaJuridica pj = new PessoaJuridica();
            pj.Nome = "Caelum";
            pj.CNPJ = "123.456/0001-99";

            UsuarioDAO dao = new UsuarioDAO(session);
            dao.Adiciona(pf);
            dao.Adiciona(pj);


            session.Close();

            Console.Read();

        }
    }

    public class ProdutosPorCategoria
    {
        public Categoria Categoria { get; set; }
        public long NumeroDePedidos { get; set; }
    }
}


