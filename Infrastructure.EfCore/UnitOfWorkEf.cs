﻿using _01_FrameWork.Infrastructure;
using Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class UnitOfWorkEf : IUnitOfWork
    {
        private readonly MasterBloggerContext _context;
        public UnitOfWorkEf(MasterBloggerContext context)
        {
            _context = context;
        }
        public void BeginTran()
        {
            _context.Database.BeginTransaction();
        }

        public void CommitTran()
        {
            _context.SaveChanges();
            _context.Database.CommitTransaction();
        }

        public void RollBack()
        {
            _context.Database.RollbackTransaction();
        }
    }
}
