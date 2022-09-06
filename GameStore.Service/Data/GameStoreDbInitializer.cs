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
                foreach (var testdata_game in TestData.Games)
                {
                    foreach (var item in TestData.GenresToList(testdata_game.Genre))    //Добавляем новые жанры в список
                        if (genres.Find(g => g.Name == item) is null)
                            genres.Add(new Genre { Name = item });

                    if (publishers.Find(p => p.Name == testdata_game.Publisher) is null)
                        publishers.Add(new Publisher { Name = testdata_game.Publisher });
                }




                //Заполняем список игр
                foreach (var testdata_game in TestData.Games)
                {
                    var testdata_game_genres = TestData.FindGenresByName(TestData.GenresToList(testdata_game.Genre), genres);
                    var game = new Game
                    {
                        Name = testdata_game.Game,
                        Publisher = publishers.FirstOrDefault(p=> p.Name== testdata_game.Publisher),
                        Genres = testdata_game_genres
                    };

                    foreach (var item in testdata_game_genres)
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
