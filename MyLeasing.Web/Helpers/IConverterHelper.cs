using System.Threading.Tasks;
using MyLeasing.Web.Data.Entities;
using MyLeasing.Web.Models;

namespace MyLeasing.Web.Helpers
{
    public interface IConverterHelper
    {
        Task<Property> ToPropertyAsync(PropertyViewModel model,bool IsNew);
        PropertyViewModel ToPropertyViewModel(Property property);
        Task<Contract> ToContractAsync(ContractViewModel model, bool IsNew);
        ContractViewModel ToContractViewModel(Contract contract);
    }
}