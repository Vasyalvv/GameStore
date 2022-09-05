using GameStore.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Service.Data
{
    public class GameStoreDbInitializer
    {
        private readonly GameStoreDB _db;

        public GameStoreDbInitializer(GameStoreDB GameStoreDB)
        {
            _db = GameStoreDB;
        }

        public void Initialize()
        {
            if (_db.Database.GetPendingMigrations().Any())
                _db.Database.Migrate();

            InitializeGames();
        }

        private void InitializeGames()
        {

        }
    }
}
