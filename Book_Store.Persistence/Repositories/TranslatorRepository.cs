﻿using Book_Store.Application.Contracts.Persistence;
using Book_Store.Domain.Entites;

namespace Book_Store.Persistence.Repositories
{
    public class TranslatorRepository : GenericRepository<Translator>, ITranslatorRepository
    {
        private readonly BookStoreDbContext _context;

        public TranslatorRepository(BookStoreDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
