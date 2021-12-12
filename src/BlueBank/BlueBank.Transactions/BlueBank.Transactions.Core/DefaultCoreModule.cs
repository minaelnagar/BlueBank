using Autofac;
using BlueBank.Transactions.Core.Interfaces;
using BlueBank.Transactions.Core.Services;
namespace BlueBank.Transactions.Core
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
