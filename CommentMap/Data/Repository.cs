using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommentMap.Models;
using Microsoft.EntityFrameworkCore;

namespace CommentMap.Data
{
    public class RepositoryContext : DbContext
    {

        public RepositoryContext(DbContextOptions<RepositoryContext> options)
            : base(options)
        {
        }

        public DbSet<Entry> Entries { get; set; }


    }
}
