using Framework.OprationRes;
using Framework.SlugTool;
using Microsoft.Extensions.Options;
using ShopManagment.Application.Contracts.Product;
using ShopManagment.Domains.Agg.Product;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ShopManagment.Application.Services;

public class ProductApplication : IProductApplication {
    private readonly IProductRepository _productRepository;

    public ProductApplication(IProductRepository productRepository) {
        _productRepository = productRepository;
    }
    public OprationResult Create(CreateProduct command) {
        OprationResult op = new OprationResult();
        if (_productRepository.IsExist(x => x.Name == command.Name))
            return op.Failed("محصول مورد نظر در دیتابیس وجود دارد");
        string slug = command.Slug.ToSlug();
        var product = new Product(command.Name, command.UnitPraice, command.Code, command.ShortDescription,
            command.Description, command.Picture, command.PictureAlt, command.PictureTitle, command.CategoryId, slug,
            command.Keywords, command.MetaDescription);
        _productRepository.Add(product);
        _productRepository.SaveChanges();
        return op.Successed("محصول با موفقیت ثبت شد");
    }

    public OprationResult Edit(EditProduct command) {
        OprationResult op = new OprationResult();
        if (_productRepository.IsExist(x => x.Name == command.Name && x.Id != command.Id))
            return op.Failed("محصول مورد نظر در دیتابیس وجود دارد");
        string slug = command.Slug.ToSlug();
        var product = _productRepository.Get(command.Id);
        if (product == null)
            return op.Failed("محصولی با این مشخصه یافت نشد");
        product.Edit(command.Name, command.UnitPraice, command.Code, command.ShortDescription,
            command.Description, command.Picture, command.PictureAlt, command.PictureTitle, command.CategoryId, slug,
            command.Keywords, command.MetaDescription);
        _productRepository.SaveChanges();
        return op.Successed("محصول با موفقیت ویرایش شد");
    }

    public EditProduct? GetDetailes(long id) {
        return _productRepository.GetDetailes(id);
    }

    public OprationResult IsInStock(long id) {
        OprationResult op = new OprationResult();
        var product = _productRepository.Get(id);
        if (product == null)
            return op.Failed("محصولی با این مشخصه یافت نشد");
        product.InStock();
        _productRepository.SaveChanges();
        return op.Successed();
    }

    public OprationResult NotInStock(long id) {
        OprationResult op = new OprationResult();
        var product = _productRepository.Get(id);
        if (product == null)
            return op.Failed("محصولی با این مشخصه یافت نشد");
        product.NotingInStock();
        _productRepository.SaveChanges();
        return op.Successed();
    }

    public List<ProductViewModel> Search(ProductSearchModel model) {
        return _productRepository.Search(model);
    }

    public OprationResult Remove(long id) {
        OprationResult op = new OprationResult();
        var product = _productRepository.Get(id);
        if (product == null)
            return op.Failed("محصولی با این مشخصه یافت نشد");
        product.Remove();
        return op.Successed();
    }

    public OprationResult Restore(long id) {
        OprationResult op = new OprationResult();
        var product = _productRepository.Get(id);
        if (product == null)
            return op.Failed("محصولی با این مشخصه یافت نشد");
        product.Restore();
        return op.Successed();
    }
}