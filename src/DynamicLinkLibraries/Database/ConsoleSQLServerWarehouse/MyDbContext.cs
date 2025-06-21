using Abp.Authorization.Users;
using Abp.Domain.Uow;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualStudio.Services.UserAccountMapping;
using Microsoft.VisualStudio.Services.Users;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRole = Abp.Authorization.Users.UserRole;

namespace ConsoleSQLServerWarehouse
{
    class A : IUnitOfWork
    {

    public class MyDbContext : IdentityDbContext<User, Role, Key, UserLogin, UserRole, UserClaim>, IUnitOfWork
    {
        public MyDbContext(string connectionString) : base(connectionString)
        {
           /* Database.SetInitializer(new DbInitializer());
            Database.Initialize(true);*/
        }
    }

        #region IUnitOfWork 

        private bool disposedValue;

        string IUnitOfWork.Id => throw new NotImplementedException();

        IUnitOfWork IUnitOfWork.Outer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        UnitOfWorkOptions IActiveUnitOfWork.Options => throw new NotImplementedException();

        IReadOnlyList<DataFilterConfiguration> IActiveUnitOfWork.Filters => throw new NotImplementedException();

        IReadOnlyList<AuditFieldConfiguration> IActiveUnitOfWork.AuditFieldConfiguration => throw new NotImplementedException();

        Dictionary<string, object> IActiveUnitOfWork.Items { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        bool IActiveUnitOfWork.IsDisposed => throw new NotImplementedException();

        event EventHandler IActiveUnitOfWork.Completed
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        event EventHandler<UnitOfWorkFailedEventArgs> IActiveUnitOfWork.Failed
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        event EventHandler IActiveUnitOfWork.Disposed
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        void IUnitOfWork.Begin(UnitOfWorkOptions options)
        {
            throw new NotImplementedException();
        }

        void IUnitOfWorkCompleteHandle.Complete()
        {
            throw new NotImplementedException();
        }

        Task IUnitOfWorkCompleteHandle.CompleteAsync()
        {
            throw new NotImplementedException();
        }

        IDisposable IActiveUnitOfWork.DisableAuditing(params string[] fieldNames)
        {
            throw new NotImplementedException();
        }

        IDisposable IActiveUnitOfWork.DisableFilter(params string[] filterNames)
        {
            throw new NotImplementedException();
        }

        IDisposable IActiveUnitOfWork.EnableAuditing(params string[] fieldNames)
        {
            throw new NotImplementedException();
        }

        IDisposable IActiveUnitOfWork.EnableFilter(params string[] filterNames)
        {
            throw new NotImplementedException();
        }

        int? IActiveUnitOfWork.GetTenantId()
        {
            throw new NotImplementedException();
        }

        bool IActiveUnitOfWork.IsFilterEnabled(string filterName)
        {
            throw new NotImplementedException();
        }

        void IActiveUnitOfWork.SaveChanges()
        {
            throw new NotImplementedException();
        }

        Task IActiveUnitOfWork.SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        IDisposable IActiveUnitOfWork.SetFilterParameter(string filterName, string parameterName, object value)
        {
            throw new NotImplementedException();
        }

        IDisposable IActiveUnitOfWork.SetTenantId(int? tenantId)
        {
            throw new NotImplementedException();
        }

        IDisposable IActiveUnitOfWork.SetTenantId(int? tenantId, bool switchMustHaveTenantEnableDisable)
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~A()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }

}
