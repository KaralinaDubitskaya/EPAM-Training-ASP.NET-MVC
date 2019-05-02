using System;
using BankEntites.BLL.Entities;
using BankEntites.BLL.Interfaces;
using BankEntites.BLL.Services;
using BankEntites.DAL.Entities;
using BankEntites.DAL.Interfaces;
using BankEntites.DAL.Repositories;
using Ninject.Modules;

namespace BankEntites
{
    class ConfigModule : NinjectModule
    {
        // Ninject module should look kind of like that, won't rebuild whole project
        // for ninject usage, just tried to construct kernel's constructor argument
        public override void Load()
        {
            this.Bind<AccountOwner>().ToMethod(context => new AccountOwner("Kirill", "Fidz"));
            this.Bind<IidGenerator>().To<IdGeneratorBIC>();
            this.Bind<IPointsCounter>().To<PointsCounter>();
            this.Bind<Account>().To<BaseAccount>();
            this.Bind<IRepository>().To<AccountsStorage>();
            this.Bind<IService>().To<AccountStorageService>();
        }        
    }
}
