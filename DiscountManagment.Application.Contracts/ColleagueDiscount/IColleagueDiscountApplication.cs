using Framework.OprationRes;

namespace DiscountManagment.Application.Contracts.ColleagueDiscount;

public interface IColleagueDiscountApplication
{
    OprationResult Define(DefineColleagueDiscount command);
    OprationResult Edit(EditColleagueDiscount command);
    OprationResult Remove(long id);
    OprationResult Restore(long id);
    EditColleagueDiscount? GetDetails(long id);
    List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel);
}