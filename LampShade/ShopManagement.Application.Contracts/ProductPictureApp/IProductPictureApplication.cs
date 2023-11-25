﻿using _0_Framework.Application;
using ShopManagement.Application.Contracts.ProductPictureApp;

namespace ShopManagement.Application.Contracts.ProductPictureApp
{
    public interface IProductPictureApplication
    {
        OperationResult Create(CreateProductPicture command);
        OperationResult Edit(EditProductPicture command);
        EditProductPicture GetDetails(long  id);
        List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel);
        OperationResult Remove(long id);
        OperationResult Restore(long id);   

    }
}
