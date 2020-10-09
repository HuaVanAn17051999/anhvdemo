using Application.Common;
using Application.Contract.Exceptions;
using Application.Contract.Model.Products;
using Application.Logging;
using Application.Repository.Products;
using Application.Settings.UrlHelper;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Application.Services.Product
{
    public class ProductAppService : BaseAppService , IProductAppService
    {
        private readonly string seviceName = nameof(ProductAppService);
        private readonly IProductRepository _productRepository;
        private readonly IStorageService _storageService;
        public ProductAppService(IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            UserManager<Entities.User> userManager,
            IStorageService storageService,
            IProductRepository  productRepository
             )
            :base (mapper,userManager, httpContextAccessor)
        {
            _productRepository = productRepository;
            _storageService = storageService;
        }
        //public async Task<ProductReponseModel> CreateAsync(CreateProductRequestModel createProductRequestModel)
        //{
        //    const string actionName = nameof(CreateAsync);

        //    createProductRequestModel = createProductRequestModel ?? throw new ArgumentNullException(nameof(createProductRequestModel));

        //    Logger.LogInfomation(LoggingMessage.ProcessingInService, actionName, seviceName, createProductRequestModel);

        //    var seotitle = FriendlyUrlHelper.GetFriendlyTitle(createProductRequestModel.Name);

        //    try
        //    {
        //            var product = new Entities.Product()
        //            {
        //                Name = createProductRequestModel.Name,
        //                Price = createProductRequestModel.Price,
        //                OldPrice = createProductRequestModel.OldPrice,
        //                Stock = createProductRequestModel.Stock,
        //                SeoTitle = seotitle,
        //                Caption = createProductRequestModel.Caption,
        //                CategoryId = createProductRequestModel.CategoryId,
                      
        //        };
        //        if(createProductRequestModel.ImagePath != null)
        //        {
        //            product.ImagePath = await this.SaveFile(createProductRequestModel.ImagePath);
        //            product.ImageSize = createProductRequestModel.ImagePath.Length;
        //        }
        //        var respone = await _productRepository.CreateAsync(product, true);
        //        Logger.LogInfomation(LoggingMessage.ActionSuccessfully, actionName, seviceName, respone);

        //        return _Mapper.Map<ProductReponseModel>(respone);
        //    }
        //    catch
        //    {
        //        throw new NotFoundException(nameof(createProductRequestModel));
        //    }
        //}
        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }
        public async Task DeleteAsync(int id)
        {
            const string actionName = nameof(DeleteAsync);

            Logger.LogDebug(LoggingMessage.ProcessingInService, actionName, seviceName, id);
            await _productRepository.DeleteAsync(id);
            Logger.LogDebug(LoggingMessage.ActionSuccessfully, actionName, seviceName, id);
        }

        public async Task<PagedList<Entities.Product>> ListProductByCategoryId(int id, OwnerParameters ownerParameters )
        {
            const string actionName = nameof(ListProductByCategoryId);

            if (String.IsNullOrEmpty(id.ToString()))
            {
                throw new NotFoundException(nameof(id));
            }
               
            if (ownerParameters == null)
            {
                throw new ArgumentException(nameof(ownerParameters));
            }

            Logger.LogDebug(LoggingMessage.ProcessingInService, actionName, seviceName, id);

            var response = await _productRepository.ListProductByCategoryId(id, ownerParameters);

            if(response == null)
            {
                throw new NotFoundException(nameof(id));
            }

            Logger.LogDebug(LoggingMessage.ActionSuccessfully, actionName, seviceName, id);

            //    return  _Mapper.Map<PagedList<ProductReponseModel>>(response);
            return response;
        }

        //public async Task<ProductReponseModel> UpdateAsync(int id , UpdateProductRequestModel updateProductRequestModel)
        //{
        //    var seotitle = FriendlyUrlHelper.GetFriendlyTitle(updateProductRequestModel.Name);

        //    const string actionName = nameof(UpdateAsync);

        //    updateProductRequestModel = updateProductRequestModel ?? throw new ArgumentNullException(nameof(updateProductRequestModel));

        //    if (id != updateProductRequestModel.Id)
        //        throw new InconsistentException(nameof(id));

        //    var prodcut = await _productRepository.GetAsync(id);

        //    if (prodcut == null)
        //        throw new NotFoundException(nameof(id));

        //    prodcut.Name = updateProductRequestModel.Name;
        //    prodcut.Price = updateProductRequestModel.Price;
        //    prodcut.OldPrice = updateProductRequestModel.OldPrice;
        //    prodcut.Stock = updateProductRequestModel.Stock;
        //    prodcut.CategoryId = updateProductRequestModel.CategoryId;

        //    if(updateProductRequestModel.ImageFile != null)
        //    {
        //        prodcut.ImagePath = await this.SaveFile(updateProductRequestModel.ImageFile);
        //        prodcut.ImageSize = updateProductRequestModel.ImageFile.Length;
        //    }

        //    var response = await _productRepository.UpdateAsync(prodcut, true);
        //    Logger.LogInfomation(LoggingMessage.ActionSuccessfully, actionName, seviceName, response);

        //    return _Mapper.Map<ProductReponseModel>(response); 
        //}

        public async Task<ProductReponseModel> GetByIdAsync(int id)
        {
            const string actionName = nameof(GetByIdAsync);

            Logger.LogDebug(LoggingMessage.ProcessingInService, actionName, seviceName, id);

            var respone = await _productRepository.GetAsync(id);

            if(respone == null)
            {
                throw new NotFoundException(nameof(id));
            }

            Logger.LogDebug(LoggingMessage.ActionSuccessfully, actionName, seviceName, id);

            return _Mapper.Map<ProductReponseModel>(respone);

        }
    }
}
