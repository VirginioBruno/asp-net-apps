﻿using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public class BaseRepository<T> where T : BaseModel
    {
        protected readonly ApplicationContext context;
        protected readonly DbSet<T> dbSet;

        protected BaseRepository(ApplicationContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }
    }
}