using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Service.Data
{
    public static class TestData
    {

        public static List<(string Game, string Publisher, string Genre)> Games { get; } = new()
        {
            new("Grand Theft Auto V", "Rockstar Games", "Adventure / Action"),
            new("The Witcher 3: Wild Hunt", "CD Projekt RED", "RPG"),
            new("Red Dead Redemption 2", "Rockstar Games", "Action"),
            new("God of War", "Sony Santa Monica", "Action"),
            new("Resident Evil 2", "Capcom", "Horror / Action"),
            new("Horizon Zero Dawn", "Guerrilla Games", "RPG / Action"),
            new("Divinity: Original Sin 2", "Larian Studios", "RPG / Strategy"),
            new("Half-Life: Alyx", "Valve", "Puzzle / Shooter"),
            new("Elden Ring", "FromSoftware", "RPG / Action"),
            new("Ori and the Will of the Wisps", "Moon Studios", "Platformer"),
            new("Dark Souls III", "FromSoftware", "RPG / Action"),
            new("Forza Horizon 3", "Playground Games Turn 10 Studios", "Racing"),
            new("Metro Exodus", "4A Games", "Shooter"),
            new("Detroit: Become Human", "Quantic Dream", "Adventure"),
            new("Ori and the Blind Forest", "Moon Studios", "Platformer / Adventure"),
            new("Disco Elysium", "ZA/UM", "RPG"),
            new("Cuphead", "StudioMDHR", "Arcade / Action"),
            new("Forza Horizon 4", "Playground Games", "Racing"),
            new("BioShock Infinite", "Irrational Games", "RPG / Shooter"),
            new("Rogue Legacy 2", "Cellar Door Games", "Platformer / Action"),
            new("Metal Gear Solid V: The Phantom Pain", "Kojima Productions", "Action"),
            new("Batman: Arkham Knight", "Rocksteady Studios", "Action"),
            new("Rise of the Tomb Raider", "Crystal Dynamix", "Adventure / Action"),
            new("Persona 4 Golden", "ATLUS", "RPG"),
            new("Sekiro: Shadows Die Twice", "FromSoftware", "RPG / Action"),
            new("Rayman Legends", "Ubisoft Montpellier", "Arcade / Platformer"),
            new("DOOM (2016)", "id Software", "Shooter"),
            new("Valiant Hearts: The Great War", "Valiant Hearts: The Great War", "Platformer / Action"),
        };

        /// <summary>
        /// Преобразование строки списка жанров в List<string>
        /// </summary>
        /// <param name="genres">Строка списка жанров с разделителем "/"</param>
        /// <returns>Список жанров</returns>
        public static List<string> GenresToList(string genres)
        {
            return genres.Replace(" ", "").Split('/').ToList();
        }

        /// <summary>
        /// Поиск списка жанров в источнике
        /// </summary>
        /// <param name="genres">Список жанров которые необходимо найти</param>
        /// <param name="source">Источник списка жанров</param>
        /// <returns>Список найденых жанров</returns>
        public static List<Genre> FindGenresByName(List<string> genres, List<Genre> source)
        {
            List<Genre> result = new List<Genre>();
            foreach (var genre in genres)
                if (source.Find(s => s.Name == genre) is { } item)
                    result.Add(item);

            return result;
        }
    }
}
