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
        /// <param name="Id">Идентификатор игрового жанра</param>
        /// <returns>Игровой жанр</returns>
        GenreDTO Get(int Id);

        /// <summary>
        /// Получить игровой жанр по названию
        /// </summary>
        /// <param name="Name">Название игрового жанра</param>
        /// <returns>Игровой жанр</returns>
        GenreDTO GetByName(string Name);

        /// <summary>
        /// Добавить игровой жанр
        /// </summary>
        /// <param name="Genre">Игровой жанр</param>
        /// <returns>Идентификатор добавленного игрового жанра</returns>
        int Add(GenreDTO Genre);

        /// <summary>
        /// Добавить список игровых жанров
        /// </summary>
        /// <param name="Genres">Список игровых жанров</param>
        /// <returns>Список добавленных игровых жанров</returns>
        IEnumerable<GenreDTO> Add(IEnumerable<GenreDTO> Genres);

        /// <summary>
        /// Обновить игровой жанр
        /// </summary>
        /// <param name="Genre">Игровой жанр</param>
        /// <returns>Результат обновления</returns>
        GenreDTO Update(GenreDTO Genre);

        /// <summary>
        /// Удалить игровой жанр
        /// </summary>
        /// <param name="Id">Идентификатор игровых жанров</param>
        /// <returns>Результат удаления</returns>
        bool Delete(int Id);
    }
}
