using Framework.OprationRes;
using Framework.SlugTool;
using ShopManagment.Application.Contracts.ProductCategory;
using ShopManagment.Domains.Agg.ProductCategory;

namespace ShopManagment.Application.Services;

public class ProductCategoryApplication : IProductCategoryApplication {
    private readonly IProductCategoryRepository _categoryRepository;

    public ProductCategoryApplication(IProductCategoryRepository categoryRepository) {
        _categoryRepository = categoryRepository;
    }
    public OprationResult Create(CreateProductCategory command) {
        var op = new OprationResult();
        if (_categoryRepository.IsExist(x => x.Name == command.Name))
            return op.Failed("کاربر گرامی نام انتخابی در دیتابیس وجود دارد. لطفا نام دیگری را امتحان کنید");
        string slug = command.Slug.ToSlug();
        ProductCategory productCategory = new ProductCategory(command.Name, command.Picture, command.PictureAlt,
            command.PictureTitle, command.MetaDes, command.KeyWord, slug, command.Des);
        _categoryRepository.Add(productCategory);
        _categoryRepository.SaveChanges();
        return op.Successed($"دسته بندی محصول با عنوان {command.Name} در دیتابیس با موفقیت ثبت شد");
    }

    public OprationResult Edit(EditProductCategory command) {
        var op = new OprationResult();
        var productCategory = _categoryRepository.Get(command.Id);
        if (productCategory == null)
            return op.Failed("دسته بندی محصول با این مشخصه یافت نشد");
        if (_categoryRepository.IsExist(x => x.Name == command.Name && x.Id != command.Id))
            return op.Failed("کاربر گرامی نام انتخابی در دیتابیس وجود دارد. لطفا نام دیگری را امتحان کنید");
        string slug = command.Slug.ToSlug();
        productCategory.Edit(command.Name, command.Picture, command.PictureAlt,
            command.PictureTitle, command.MetaDes, command.KeyWord, slug, command.Des);
        _categoryRepository.SaveChanges();
        return op.Successed("عملیات بروزرسانی دسته بندی محصول با موفقیت به اتمام رسید");
    }

    public EditProductCategory? GetDetailes(long id) {
        return _categoryRepository.GetDetailes(id);
    }

    public List<ProductCategoryViewModel> Search(ProductCategorySearchModel model) {
        return _categoryRepository.Search(model);
    }
    public List<ProductCategoryViewModel> GetProductCategories() {
        return _categoryRepository.GetProductCategories();
    }
    public OprationResult Remove(long id) {
        var op = new OprationResult();
        _categoryRepository.Delete(id);
        _categoryRepository.SaveChanges();
        return op.Successed();
    }

    public OprationResult Restore(long id) {
        var op = new OprationResult();
        _categoryRepository.Restore(id);
        _categoryRepository.SaveChanges();
        return op.Successed();
    }
}