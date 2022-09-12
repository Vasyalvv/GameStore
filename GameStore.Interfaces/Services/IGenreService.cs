using GameStore.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Interfaces.Services
{
    public interface IGenreService
    {
        /// <summary>
        /// Получить все игровые жанры
        /// </summary>
        /// <returns>Список игровых жанров</returns>
        IEnumerable<GenreDTO> Get();

        /// <summary>
        /// Получить игровой жанр по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор игрового жанра</param>
        /// <returns>Игровой жанр</returns>
        GenreDTO Get(int id);

        /// <summary>
        /// Получить игровой жанр по названию
        /// </summary>
        /// <param name="name">Название игрового жанра</param>
        /// <returns>Игровой жанр</returns>
        GenreDTO GetByName(string name);

        /// <summary>
        /// Добавить игровой жанр
        /// </summary>
        /// <param name="genre">Игровой жанр</param>
        /// <returns>Идентификатор добавленного игрового жанра</returns>
        int Add(GenreDTO genre);

        /// <summary>
        /// Добавить список игровых жанров
        /// </summary>
        /// <param name="genres">Список игровых жанров</param>
        /// <returns>Список добавленных игровых жанров</returns>
        IEnumerable<GenreDTO> Add(IEnumerable<GenreDTO> genres);

        /// <summary>
        /// Обновить игровой жанр
        /// </summary>
        /// <param name="genre">Игровой жанр</param>
        /// <returns>Результат обновления</returns>
        GenreDTO Update(GenreDTO genre);

        /// <summary>
        /// Удалить игровой жанр
        /// </summary>
        /// <param name="id">Идентификатор игровых жанров</param>
        /// <returns>Результат удаления</returns>
        bool Delete(int id);
    }
}
