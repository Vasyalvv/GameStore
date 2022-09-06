using GameStore.DAL.Context;
using GameStore.Domain.DTO;
using GameStore.Interfaces.Services;
using GameStore.Service.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Service.Services.InSQL
{
    public class SqlPublisherService : IPublisherService
    {
        private readonly GameStoreDB _db;
        private readonly ILogger _Logger;

        public SqlPublisherService(GameStoreDB GameStoreDB, ILogger<SqlPublisherService> Logger)
        {
            _db = GameStoreDB;
            _Logger = Logger;
        }

        public int Add(PublisherDTO Publisher)
        {
            int id = -1;    //В случае ошибки при создании, вернется несуществующий id
            try
            {
                Publisher.Id = 0;
                _db.Add(Publisher.FromDTO());
                _db.SaveChanges();
                id = _db.Publishers.FirstOrDefault(p => p.Name == Publisher.Name).Id;
            }
            catch (Exception)
            {
                _Logger.LogError("Не удалось создать издателя {0}", Publisher.Name);
            }
            return id;
        }

        public bool Delete(int Id)
        {
            var publisher = _db.Publishers.FirstOrDefault(p => p.Id == Id);
            try
            {
                //Удаляем издателя
                _db.Publishers.Remove(publisher);

                _db.SaveChanges();
            }
            catch (Exception)
            {
                _Logger.LogError("Не удалось удалить издателя Id:{0}", Id);
                return false;
            }

            return true;
        }

        public IEnumerable<PublisherDTO> Get() => _db.
            Publishers.
            Select(p => p.ToDTO());

        public PublisherDTO Get(int Id) => _db.
            Publishers.
            FirstOrDefault(p => p.Id == Id).
            ToDTO();

        public PublisherDTO GetByName(string Name) => _db.
            Publishers.
            FirstOrDefault(p => p.Name == Name).
            ToDTO();

        public PublisherDTO Update(PublisherDTO Publisher)
        {
            PublisherDTO result = null;
            int id = Publisher.Id;

            try
            {
                if (Publisher.Id == 0)  //Если Id==0 в DTO модели, то нужно создать нового издателя
                    id = Add(Publisher);
                else
                {                       //Иначе, редактируем существующего издателя
                    _db.Publishers.
                        FirstOrDefault(p => p.Id == Publisher.Id).
                        Name = Publisher.Name;
                    _db.SaveChanges();
                }
                result = _db.Publishers.FirstOrDefault(p => p.Id == id).ToDTO();
            }
            catch (Exception)
            {
                _Logger.LogError("Не удалось обновить издателя {0}", Publisher.Name);
            }
            return result;
        }
    }
}
