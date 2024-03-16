using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using IMSLP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IMLSP.Infrastructure.EFCore.Context
{
    public class IMSLPDbContext: DbContext
    {
        public IMSLPDbContext(DbContextOptions<IMSLPDbContext> options): base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
