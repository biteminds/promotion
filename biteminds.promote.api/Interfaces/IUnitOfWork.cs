using biteminds.promote.data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace biteminds.promote.api.Interfaces
{
    interface IUnitOfWork : IDisposable
    {
        #region Repositories
        IPromocionRepository Promocion { get; }
        #endregion
        void SaveChanges();
        void BeginTransaction();
        bool Commit();
        void Rollback();
    }
}
