﻿using System;
using System.Threading.Tasks;
using UserStore.DAL.Entities;
using UserStore.DAL.Identity;

namespace UserStore.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationUserManager UserManager { get; }
        IClientManager ClientManager { get; }
        ApplicationRoleManager RoleManager { get; }
        IRepository<Event> Events { get; }
        IRepository<Report> Reports { get; }
        Task SaveAsync();
    }
}
