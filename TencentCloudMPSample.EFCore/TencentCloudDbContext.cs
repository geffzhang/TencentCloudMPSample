using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TencentCloudMPSample.EFCore.Models;

namespace TencentCloudMPSample.EFCore
{
    public class TencentCloudDbContext : DbContext
    {
        public TencentCloudDbContext(DbContextOptions<TencentCloudDbContext> options):base(options)
        {
        }

        public DbSet<WeixinInteraction> WeixinInteractions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
