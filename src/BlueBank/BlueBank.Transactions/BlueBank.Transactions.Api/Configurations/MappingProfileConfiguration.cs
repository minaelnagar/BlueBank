using AutoMapper;
using BlueBank.Transactions.Api.ApiModels;
using BlueBank.Transactions.Core.AccountAggregates;

namespace BlueBank.Transactions.Api.Configurations
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
            CreateMap<Transaction, TransactionDTO>().ReverseMap();
            CreateMap<Account, AccountDTO>().ReverseMap();
        }
    }
}
