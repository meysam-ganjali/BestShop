using DiscountManagment.Application.Contracts.ColleagueDiscount;
using DiscountManagment.Domains.Agg.ColleagueDiscount;
using Framework.OprationRes;

namespace DiscountManagment.Application.Services;

public class ColleagueDiscountApplication:IColleagueDiscountApplication
{
    private readonly IColleagueDiscountRepository _colleagueDiscountRepository;

    public ColleagueDiscountApplication(IColleagueDiscountRepository colleagueDiscountRepository) {
        _colleagueDiscountRepository = colleagueDiscountRepository;
    }

    public OprationResult Define(DefineColleagueDiscount command) {
        var operation = new OprationResult();
        if (_colleagueDiscountRepository.IsExist(x => x.ProductId == command.ProductId && x.DiscountRate == command.DiscountRate))
            return operation.Failed("این تخفیف از قبل در سیستم موجود میباشد");

        var colleagueDiscount = new ColleagueDiscount(command.ProductId, command.DiscountRate);

        _colleagueDiscountRepository.Add(colleagueDiscount);
        _colleagueDiscountRepository.SaveChanges();
        return operation.Successed("تخفیف همکاری با موفقیت ثبت شد");
    }

    public OprationResult Edit(EditColleagueDiscount command) {
        var operation = new OprationResult();
        var colleagueDiscount = _colleagueDiscountRepository.Get(command.Id);
        if (colleagueDiscount == null)
            return operation.Failed("رکورد یافت نشد");

        if (_colleagueDiscountRepository.IsExist(x => x.ProductId == command.ProductId && x.DiscountRate == command.DiscountRate && x.Id != command.Id))
            return operation.Failed("این تخفیف از قبل در سیستم موجود میباشد");

        colleagueDiscount.Edit(command.ProductId, command.DiscountRate);

        _colleagueDiscountRepository.SaveChanges();
        return operation.Successed("عملیات بروزرسانی با موفقیت به پایان رسید");
    }

    public EditColleagueDiscount? GetDetails(long id) {
        return _colleagueDiscountRepository.GetDetails(id);
    }

    public OprationResult Remove(long id) {
        var operation = new OprationResult();
        var colleagueDiscount = _colleagueDiscountRepository.Get(id);
        if (colleagueDiscount == null)
            return operation.Failed("رکورد یافت نشد");

        colleagueDiscount.Remove();

        _colleagueDiscountRepository.SaveChanges();
        return operation.Successed();
    }

    public OprationResult Restore(long id) {
        var operation = new OprationResult();
        var colleagueDiscount = _colleagueDiscountRepository.Get(id);
        if (colleagueDiscount == null)
            return operation.Failed("رکورد یافت نشد");

        colleagueDiscount.Restore();

        _colleagueDiscountRepository.SaveChanges();
        return operation.Successed();
    }

    public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel) {
        return _colleagueDiscountRepository.Search(searchModel);
    }
}