using Autofac;
using BlueBank.Accounts.Api.Settings;
using BlueBank.Accounts.Infrastructure.Interfaces;

namespace BlueBank.Accounts.Api
{
    public class DefaultApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TransactionServiceSettings>()
                .As<ITransactionServiceSettings>().InstancePerLifetimeScope();
        }
    }
}
