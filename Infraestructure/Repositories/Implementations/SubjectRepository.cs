using Domain;
using Infraestructure.Context;
using Infraestructure.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories.Implementations
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly ApplicationDbContext _context;

        public SubjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Subject> Create(Subject entity)
        {
            _context.Subjects.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public Task<Subject?> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Subject?> Find(int id)
            => await _context.Subjects.FindAsync(id);

        public async Task<IList<Subject>> FindAll()
            => await _context.Subjects.ToListAsync();

        public async Task<Subject?> Update(Subject entity)
        {
            var model = await _context.Subjects.FindAsync(entity.Id);

            if (model != null)
            {
                model.Name = entity.Name;
                model.StreetAddress = entity.StreetAddress;
                model.PostCode = entity.PostCode;
                model.City = entity.City;
                model.Country = entity.Country;
                model.Email = entity.Email;

                _context.Subjects.Update(model);
                await _context.SaveChangesAsync();
            }

            return entity;
        }
    }
}
