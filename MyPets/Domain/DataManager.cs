using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyPets.Domain.Repositories.Abstract;

namespace MyPets.Domain
{
    public class DataManager   //обслуживающий класс для управления репозиторием
    {
        public ITextFieldsRepository TextFields { get; set; }
        public IServiceItemsRepository ServiceItems { get; set; }

        public DataManager(ITextFieldsRepository textFieldsRepository, IServiceItemsRepository serviceItemsRepository)
        {
            TextFields = textFieldsRepository;
            ServiceItems = serviceItemsRepository;
        }
    }
}
