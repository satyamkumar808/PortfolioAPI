﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.RepositoryInterface
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAll();
    }
}
