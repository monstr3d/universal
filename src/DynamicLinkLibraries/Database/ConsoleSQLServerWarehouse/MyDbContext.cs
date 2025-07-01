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

        string IUnitOfWork.Id => throw new OwnNotImplemented();

        IUnitOfWork IUnitOfWork.Outer { get => throw new OwnNotImplemented(); set => throw new OwnNotImplemented(); }

        UnitOfWorkOptions IActiveUnitOfWork.Options => throw new OwnNotImplemented();

        IReadOnlyList<DataFilterConfiguration> IActiveUnitOfWork.Filters => throw new OwnNotImplemented();

        IReadOnlyList<AuditFieldConfiguration> IActiveUnitOfWork.AuditFieldConfiguration => throw new OwnNotImplemented();

        Dictionary<string, object> IActiveUnitOfWork.Items { get => throw new OwnNotImplemented(); set => throw new OwnNotImplemented(); }

        bool IActiveUnitOfWork.IsDisposed => throw new OwnNotImplemented();

        event EventHandler IActiveUnitOfWork.Completed
        {
            add
            {
                throw new OwnNotImplemented();
            }

            remove
            {
                throw new OwnNotImplemented();
            }
        }

        event EventHandler<UnitOfWorkFailedEventArgs> IActiveUnitOfWork.Failed
        {
            add
            {
                throw new OwnNotImplemented();
            }

            remove
            {
                throw new OwnNotImplemented();
            }
        }

        event EventHandler IActiveUnitOfWork.Disposed
        {
            add
            {
                throw new OwnNotImplemented();
            }

            remove
            {
                throw new OwnNotImplemented();
            }
        }

        void IUnitOfWork.Begin(UnitOfWorkOptions options)
        {
            throw new OwnNotImplemented();
        }

        void IUnitOfWorkCompleteHandle.Complete()
        {
            throw new OwnNotImplemented();
        }

        Task IUnitOfWorkCompleteHandle.CompleteAsync()
        {
            throw new OwnNotImplemented();
        }

        IDisposable IActiveUnitOfWork.DisableAuditing(params string[] fieldNames)
        {
            throw new OwnNotImplemented();
        }

        IDisposable IActiveUnitOfWork.DisableFilter(params string[] filterNames)
        {
            throw new OwnNotImplemented();
        }

        IDisposable IActiveUnitOfWork.EnableAuditing(params string[] fieldNames)
        {
            throw new OwnNotImplemented();
        }

        IDisposable IActiveUnitOfWork.EnableFilter(params string[] filterNames)
        {
            throw new OwnNotImplemented();
        }

        int? IActiveUnitOfWork.GetTenantId()
        {
            throw new OwnNotImplemented();
        }

        bool IActiveUnitOfWork.IsFilterEnabled(string filterName)
        {
            throw new OwnNotImplemented();
        }

        void IActiveUnitOfWork.SaveChanges()
        {
            throw new OwnNotImplemented();
        }

        Task IActiveUnitOfWork.SaveChangesAsync()
        {
            throw new OwnNotImplemented();
        }

        IDisposable IActiveUnitOfWork.SetFilterParameter(string filterName, string parameterName, object value)
        {
            throw new OwnNotImplemented();
        }

        IDisposable IActiveUnitOfWork.SetTenantId(int? tenantId)
        {
            throw new OwnNotImplemented();
        }

        IDisposable IActiveUnitOfWork.SetTenantId(int? tenantId, bool switchMustHaveTenantEnableDisable)
        {
            throw new OwnNotImplemented();
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
