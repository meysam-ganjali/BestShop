using DiscountManagment.Application.Contracts.CustomerDiscount;
using DiscountManagment.Domains.Agg.CustomersDiscount;
using Framework.DateTools;
using Framework.OprationRes;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DiscountManagment.Application.Services;

public class CustomerDiscountApplication : ICustomerDiscountApplication {
    private readonly ICustomerDiscountRepository _customerDiscountRepository;
    public OprationResult Define(DefineCustomerDiscount command) {
        OprationResult op = new OprationResult();
        if (_customerDiscountRepository.IsExist(x => x.ProductId == command.ProductId&& x.DiscountRate == command.DiscountRate))
            return op.Failed("کاربر گزامی شما قبلا برای این محصول دارای تخفیف می باشد");
        var customerDiscount = new CustomerDiscount(command.ProductId, command.DiscountRate, command.StartDate,
            command.EndDate, command.Reason);
        _customerDiscountRepository.Add(customerDiscount);
        _customerDiscountRepository.SaveChanges();
        string startDate = command.StartDate.ToFarsi();
        string endDate = command.EndDate.ToFarsi();
        return op.Successed(
            $"تخفیف با موفقیت برای محصول مورد نظر ثبت شد. اطلاعات تخفیف : تاریخ شروع {startDate} - تاریخ پایان {endDate} و میزان تخفیف {command.DiscountRate}");
    }

    public OprationResult Edit(EditCustoemrDiscount command) {
        OprationResult op=new OprationResult();
        var customerDiscount = _customerDiscountRepository.Get(command.Id);
        if (customerDiscount == null)
            return op.Failed("تخفیف یافت نشد");
        if(_customerDiscountRepository.IsExist(x=>x.ProductId == command.ProductId && x.Id != command.Id))
            return op.Failed("کاربر گزامی شما قبلا برای این محصول دارای تخفیف می باشد");
        customerDiscount.Edit(command.ProductId, command.DiscountRate, command.StartDate,
            command.EndDate, command.Reason);
        _customerDiscountRepository.SaveChanges();
        return op.Successed("عملیات بروزرسانی تخفیف با موفقیت به پایان رسید");
    }

    public EditCustoemrDiscount? GetDetails(long id)
    {
        return _customerDiscountRepository.GetDetails(id);
    }

    public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel)
    {
        return _customerDiscountRepository.Search(searchModel);
    }

    public OprationResult Remove(long id) {
        OprationResult op = new OprationResult();
        var customerDiscount = _customerDiscountRepository.Get(id);
        if (customerDiscount == null)
            return op.Failed("تخفیف یافت نشد");
        customerDiscount.Remove();
        return op.Successed();
    }

    public OprationResult Restore(long id) {
        OprationResult op = new OprationResult();
        var customerDiscount = _customerDiscountRepository.Get(id);
        if (customerDiscount == null)
            return op.Failed("تخفیف یافت نشد");
        customerDiscount.Restore();
        return op.Successed();
    }
}