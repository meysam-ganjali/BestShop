using Framework.OprationRes;

namespace DiscountManagment.Application.Contracts.CustomerDiscount;

public interface ICustomerDiscountApplication
{
    OprationResult Define(DefineCustomerDiscount command);
    OprationResult Edit(EditCustoemrDiscount command);
    EditCustoemrDiscount? GetDetails(long id);
    List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel);
    OprationResult Remove(long id);
    OprationResult Restore(long id);
}