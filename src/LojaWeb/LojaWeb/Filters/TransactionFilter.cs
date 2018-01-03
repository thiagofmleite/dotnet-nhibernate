using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;

namespace LojaWeb.Filters
{
    public class TransactionFilter : ActionFilterAttribute
    {
        private ISession session;

        public TransactionFilter(ISession session)
        {
            this.session = session;
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            session.BeginTransaction();
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            session.Transaction.Commit();
            session.Close();
        }
    }
}