using GameStore.Domain.DTO;
using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Interfaces.Services
{
    public interface IGameService
    {
        /// <summary>
        /// Получить все игры
        /// </summary>
        /// <returns>Список игр</returns>
        IEnumerable<GameDTO> Get();

        /// <summary>
        /// Получить игру по идентификатору
        /// </summary>
        /// <param name="Id">Идентификатор игры</param>
        /// <returns>Игра</returns>
        IEnumerable<GameDTO> Get(int Id);

        /// <summary>
        /// Получить игру по названию
        /// </summary>
        /// <param name="Name">Название игры</param>
        /// <returns>Игра</returns>
        IEnumerable<GameDTO> GetByName(string Name);

        /// <summary>
        /// Получить все игры определенного жанра
        /// </summary>
        /// <param name="Id">Идентификатор жанра</param>
        /// <returns>Список игр</returns>
        IEnumerable<GameDTO> GetByGenre(int Id);

        /// <summary>
        /// Получить все игры определенного жанра
        /// </summary>
        /// <param name="Name">Имя жанра</param>
        /// <returns>Список игр</</returns>
        IEnumerable<GameDTO> GetByGenre(string Name);

        /// <summary>
        /// Добавить игру
        /// </summary>
        /// <param name="Game">Игра</param>
        /// <returns>Идентификатор добавленной игры</returns>
        int Add(GameDTO Game);

        /// <summary>
        /// Обновить данные игры
        /// </summary>
        /// <param name="Game">Игра</param>
        /// <returns>Результат обновления</returns>
        bool Update(GameDTO Game);

        /// <summary>
        /// Удалить игру
        /// </summary>
        /// <param name="Id">Идентификатор игры</param>
        /// <returns>Результат удаления</returns>
        bool Delete(int Id);
    }
}
