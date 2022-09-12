using GameStore.DAL.Context;
using GameStore.Domain.Entities;
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

        public GameStoreDbInitializer(GameStoreDB gameStoreDB)
        {
            _db = gameStoreDB;
        }

        public void Initialize()
        {
            if (_db.Database.GetPendingMigrations().Any())
                _db.Database.Migrate();

            InitializeGames();
        }

        /// <summary>
        /// Инициализация БД тестовыми данными
        /// </summary>
        private void InitializeGames()
        {
            List<Genre> genres = new List<Genre>();
            List<Game> games = new List<Game>();
            List<Publisher> publishers = new List<Publisher>();

            if (!_db.Genres.Any())
            {
                //Заполняем список жанров и разработчиков
                foreach (var testDataGame in TestData.Games)
                {
                    foreach (var item in TestData.GenresToList(testDataGame.Genre))    //Добавляем новые жанры в список
                        if (genres.Find(g => g.Name == item) is null)
                            genres.Add(new Genre { Name = item });

                    if (publishers.Find(p => p.Name == testDataGame.Publisher) is null)
                        publishers.Add(new Publisher { Name = testDataGame.Publisher });
                }




                //Заполняем список игр
                foreach (var testDataGame in TestData.Games)
                {
                    var testDataGameGenres = TestData.FindGenresByName(TestData.GenresToList(testDataGame.Genre), genres);
                    var game = new Game
                    {
                        Name = testDataGame.Game,
                        Publisher = publishers.FirstOrDefault(p=> p.Name== testDataGame.Publisher),
                        Genres = testDataGameGenres
                    };

                    foreach (var item in testDataGameGenres)
                        item.Games.Add(game);

                    games.Add(game);
                }



                _db.Genres.AddRange(genres);
                _db.Games.AddRange(games);
                _db.SaveChanges();
            }
        }
    }
}
