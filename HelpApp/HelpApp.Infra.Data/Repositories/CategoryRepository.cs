﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpApp.Domain.Entities;
using HelpApp.Domain.Interfaces;
using HelpApp.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
namespace HelpApp.Infra.Data.Repositories

{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetById(int? id)
        {

            return await _context.Categories.FindAsync(id);

        }

        public async Task<Category> Create(Category category)
        {
            _context.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> Remove(Category category)
        {
            _context.Remove(category);
            await _context.SaveChangesAsync();
            return category;

        }

        public Task<Category> Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}