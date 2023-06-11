using DiscountManagment.Application.Contracts.CustomerDiscount;
using Framework.IGenericRepository;

namespace DiscountManagment.Domains.Agg.CustomersDiscount;

public interface ICustomerDiscountRepository : IRepository<long, CustomerDiscount>
{
    EditCustoemrDiscount? GetDetails(long id);
    List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel);
}