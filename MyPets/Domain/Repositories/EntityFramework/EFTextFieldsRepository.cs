using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyPets.Domain.Entities;
using MyPets.Domain.Repositories.Abstract;

namespace MyPets.Domain.Repositories.EntityFramework
{
    public class EFTextFieldsRepository : ITextFieldsRepository
    {
        private readonly AppDbContext context;
        public EFTextFieldsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<TextField> GetTextFields()//получ всех записей
        {
            return context.TextFields;
        }

        public TextField GetTextFieldById(Guid id)//получ одной записи
        {
            return context.TextFields.FirstOrDefault(x => x.Id == id);
        }

        public TextField GetTextFieldByCodeWord(string codeWord)//по ключ слову
        {
            return context.TextFields.FirstOrDefault(x => x.CodeWord == codeWord);
        }

        public void SaveTextField(TextField entity)//новый объект
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;//добавлен
            else
                context.Entry(entity).State = EntityState.Modified;//изменен
            context.SaveChanges();
        }

        public void DeleteTextField(Guid id)//удаление
        {
            context.TextFields.Remove(new TextField() { Id = id });
            context.SaveChanges();
        }
    }
}
