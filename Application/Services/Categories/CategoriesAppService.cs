using Application.Contract.Criteria.Categoies;
using Application.Contract.Exceptions;
using Application.Contract.Model.Categories;
using Application.Contract.Model.Common;
using Application.Logging;
using Application.Repository.Categories;
using Application.Settings.UrlHelper;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Categories
{
    public class CategoriesAppService : BaseAppService, ICategoriesAppService
    {
        private readonly string seviceName = nameof(CategoriesAppService);
        private readonly ICategoryRepository _categoryRepository;
        private readonly ShopDbContext _db;
        public CategoriesAppService(IMapper mapper,
            UserManager<Entities.User> userManager,
            IHttpContextAccessor httpContextAccessor,
            ICategoryRepository categoryRepository,
            ShopDbContext db)
            : base(mapper, userManager, httpContextAccessor)
        {
            _db = db;
            _categoryRepository = categoryRepository;
        }
        public async Task<CategoriesReponseModel> CreateAsync(CreateCategoriesRequestModel createCategoriesRequestModel)
        {
            const string actionName = nameof(CreateAsync);

            createCategoriesRequestModel = createCategoriesRequestModel ?? throw new ArgumentNullException(nameof(createCategoriesRequestModel));

            var seoTitle = FriendlyUrlHelper.GetFriendlyTitle(createCategoriesRequestModel.Name);
            Logger.LogInfomation(LoggingMessage.ProcessingInService, actionName, seviceName, createCategoriesRequestModel);
            // var category = _Mapper.Map<Entities.Categories>(createCategoriesRequestModel);  

            var category = new Entities.Categories()
            {
                Name = createCategoriesRequestModel.Name,
                ParentId = createCategoriesRequestModel.ParentId,
                SeoTitle = seoTitle,
                Status = createCategoriesRequestModel.Status
            };

            //if (createCategoriesRequestModel.Status != Enums.Status.Active && createCategoriesRequestModel.Status != Enums.Status.InActive)
            //    throw new NotFoundException(nameof(createCategoriesRequestModel));

            var response = await _categoryRepository.CreateAsync(category, true);
            Logger.LogInfomation(LoggingMessage.ActionSuccessfully, actionName, seviceName, response);

            return _Mapper.Map<CategoriesReponseModel>(response);
        }
        public async Task<CategoriesReponseModel> UpdateAsync(int id, UpdateCategoriesRequestModel updateCategoriesRequestModel)
        {
            const string actionName = nameof(UpdateAsync);

            updateCategoriesRequestModel = updateCategoriesRequestModel ?? throw new ArgumentNullException(nameof(updateCategoriesRequestModel));

            if(id != updateCategoriesRequestModel.Id)
            {
                throw new InconsistentException(nameof(updateCategoriesRequestModel));
            }

            var seoTitle = FriendlyUrlHelper.GetFriendlyTitle(updateCategoriesRequestModel.Name);

            Logger.LogInfomation(LoggingMessage.ProcessingRequestWithModel, actionName, seviceName, updateCategoriesRequestModel);

            var category = await _categoryRepository.GetAsync(id);

            if (category == null)
                throw new NotFoundException(nameof(id));
 
            category.Name = updateCategoriesRequestModel.Name;
            category.Status = updateCategoriesRequestModel.Status;
            category.SeoTitle = seoTitle;
            category.ParentId = updateCategoriesRequestModel.ParentId;

            //if (updateCategoriesRequestModel.Status != Enums.Status.Active && updateCategoriesRequestModel.Status != Enums.Status.InActive)
            //    throw new NotFoundException(nameof(updateCategoriesRequestModel));

            var response = await _categoryRepository.UpdateAsync(category, true);
            Logger.LogInfomation(LoggingMessage.ActionSuccessfully, actionName, seviceName, response);

            return _Mapper.Map<CategoriesReponseModel>(response);
        }
        public async Task DeleteAsync(int id)
        {
            var listCategory = new List<Entities.Categories>();

            const string actionName = nameof(DeleteAsync);

            Logger.LogDebug(LoggingMessage.ProcessingInService, actionName, seviceName, id);

            var parent = await _db.Categories.Where(x => x.ParentId == id).ToListAsync();

             if(parent.Count > 0)
             {
                listCategory.AddRange(parent);

                foreach (Entities.Categories categories in listCategory)
                {
                    _db.Categories.Remove(categories);
                }
                await _db.SaveChangesAsync();
             }
             await _categoryRepository.DeleteAsync(id);

             Logger.LogDebug(LoggingMessage.ActionSuccessfully, actionName, id);
        }

        public async Task<PageResultData<CategoriesReponseModel>> SearchAsync(CategoriesCriteria criteria)
        {
            const string actionName = nameof(SearchAsync);

            Logger.LogDebug(LoggingMessage.ProcessingInService, actionName, seviceName, criteria);
            var response = await _categoryRepository.SearchAsync(criteria);
            Logger.LogDebug(LoggingMessage.ActionSuccessfully, actionName, criteria);

            return _Mapper.Map<PageResultData<CategoriesReponseModel>>(response);
        }

        public async Task<List<Category_Custom>> GetListAsync()
        {

            List<Category_Custom> _category = new List<Category_Custom>();

            var _l = await _db.Categories.Where(x => x.ParentId == 0)
                                         .Select(x => new Category_Custom()
                                         {
                                             Id = x.Id,
                                             Name = x.Name,
                                             DateCreate = x.DateCreate,
                                             Seotitle = x.SeoTitle,
                                             Status = x.Status,
                                             ParentId = x.ParentId
                                         }).ToListAsync();
            if(_l != null)
            {
                for (int i = 0; i < _l.Count; i++)
                {
                    int _id = _l[i].Id;
                    _l[i].Child = new List<Category_Custom>();
                    _l[i].Child = await _db.Categories
                        .Where(x => x.ParentId == _id)
                        .Select(x => new Category_Custom()
                        {
                            Id = x.Id,
                            Name = x.Name,
                            DateCreate = x.DateCreate,
                            Seotitle = x.SeoTitle,
                            Status = x.Status,
                            ParentId = x.ParentId
                        }).ToListAsync();
                    _category.AddRange(_l[i].Child);
                }
            }
            const string actionName = nameof(GetListAsync);

            Logger.LogDebug(LoggingMessage.ProcessingInServiceWithoutModel, actionName, seviceName);
            
            Logger.LogDebug(LoggingMessage.ActionSuccessfullyWithoutModel, actionName, seviceName);

            return _Mapper.Map<List<Category_Custom>>(_l);
        }



     
    }
}
