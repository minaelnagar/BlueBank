using Autofac;
using BlueBank.Accounts.Core.Interfaces;
using BlueBank.Accounts.Core.Services;

namespace BlueBank.Accounts.Core
{
    public class DefaultCoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AccountService>()
                .As<IAccountService>().InstancePerLifetimeScope();
        }
    }
}
