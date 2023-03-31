using BooksManager.Core.Application.Dtos.Users;
using BooksManager.Core.Application.Interfaces.Service;
using BooksManager.Infrastructure.Identity.Entities;
using Domain.Common;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Persistence.Context
{
    public partial class Books_ManagerContext : DbContext
    {
        private readonly IContextAccessorWrapper _contextAccessorWrapper;
        public Books_ManagerContext(DbContextOptions<Books_ManagerContext> options, IContextAccessorWrapper contextAccessorWrapper)
            : base(options)
        {
            _contextAccessorWrapper = contextAccessorWrapper;
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<AuthorsBook> AuthorsBooks { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Photograph> Photographs { get; set; } = null!;

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var userName = _contextAccessorWrapper.GetContextName() == null ? "Unknown user" :
                _contextAccessorWrapper.GetContextName();

            foreach (var entry in ChangeTracker.Entries<AuditBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.CreateBy = userName;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.Now;
                        entry.Entity.LastModifiedBy = userName;
                        break;
                }
            }
            
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
