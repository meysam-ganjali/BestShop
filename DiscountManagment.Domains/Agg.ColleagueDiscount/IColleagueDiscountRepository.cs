using DiscountManagment.Application.Contracts.ColleagueDiscount;
using Framework.IGenericRepository;

namespace DiscountManagment.Domains.Agg.ColleagueDiscount;

public interface IColleagueDiscountRepository:IRepository<long,ColleagueDiscount>
{
    EditColleagueDiscount? GetDetails(long id);
    List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel);
}