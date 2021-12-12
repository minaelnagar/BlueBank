using AutoMapper;
using BlueBank.Accounts.Api.ApiModels;
using BlueBank.Accounts.Core.CustomerAggregates;

namespace BlueBank.Accounts.Api.Configurations
{
    /// <summary>
    /// 
    /// </summary>
    public class MappingProfileConfiguration : Profile
    {

        /// <summary>
        /// 
        /// </summary>
        public MappingProfileConfiguration()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Account, AccountDTO>().ReverseMap();
            CreateMap<Transaction, TransactionDTO>().ReverseMap();
        }
    }
}
