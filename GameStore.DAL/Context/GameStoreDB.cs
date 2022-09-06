using GameStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.DAL.Context
{
    public class GameStoreDB:DbContext
    {
        public GameStoreDB(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Game> Games { get; set; }
    }
}
