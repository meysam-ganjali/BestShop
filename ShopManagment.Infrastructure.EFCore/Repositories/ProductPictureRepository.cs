using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagment.Application.Contracts.ProductPicture;
using ShopManagment.Domains.Agg.ProductPicture;
using ShopManagment.Infrastructure.EFCore.Context;

namespace ShopManagment.Infrastructure.EFCore.Repositories;

public class ProductPictureRepository:BaseRepository<long,ProductPicture>,IProductPictureRepository
{
    private readonly ShopDbContext _context;

    public ProductPictureRepository(ShopDbContext context) : base(context)
    {
        _context = context;
    }

    public EditProductPicture? GetDetailes(long id)
    {
        return _context.ProductPictures.Select(x => new EditProductPicture()
        {
            Picture = x.Picture,
            Id = x.Id,
            IsRemoved = x.IsRemove,
            PictureAlt = x.PictureAlt,
            PictureTitle = x.PictureTitle,
            ProductId = x.ProductId
        }).FirstOrDefault(x => x.Id == id);
    }

    public List<ProductPictureViewModel> Search(ProductPictureSearchModel model)
    {
        var query = _context.ProductPictures
            .Include(x=>x.Product)
            .Select(x => new ProductPictureViewModel()
        {
            Picture = x.Picture,
            Id = x.Id,
            ProductId = x.ProductId,
            CreatedDate = x.CreatedDate,
            IsRemoved = x.IsRemove,
            ProductName = x.Product.Name
        });
        if (model.ProductId > 0 || model.ProductId != 0)
            query = query.Where(x => x.ProductId == model.ProductId);
        return query.OrderByDescending(x => x.Id).ToList();
    }
}