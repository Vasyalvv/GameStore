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
        /// <param name="id">Идентификатор игры</param>
        /// <returns>Игра</returns>
        GameDTO Get(int id);

        /// <summary>
        /// Получить игру по названию
        /// </summary>
        /// <param name="name">Название игры</param>
        /// <returns>Игра</returns>
        GameDTO GetByName(string name);

        /// <summary>
        /// Получить все игры определенного жанра
        /// </summary>
        /// <param name="id">Идентификатор жанра</param>
        /// <returns>Список игр</returns>
        IEnumerable<GameDTO> GetByGenre(int id);

        /// <summary>
        /// Получить все игры определенного жанра
        /// </summary>
        /// <param name="name">Имя жанра</param>
        /// <returns>Список игр</</returns>
        IEnumerable<GameDTO> GetByGenre(string name);

        /// <summary>
        /// Добавить игру
        /// </summary>
        /// <param name="game">Игра</param>
        /// <returns>Идентификатор добавленной игры</returns>
        int Add(GameDTO game);

        /// <summary>
        /// Обновить данные игры
        /// </summary>
        /// <param name="game">Игра</param>
        /// <returns>Результат обновления</returns>
        bool Update(GameDTO game);

        /// <summary>
        /// Удалить игру
        /// </summary>
        /// <param name="id">Идентификатор игры</param>
        /// <returns>Результат удаления</returns>
        bool Delete(int id);
    }
}
