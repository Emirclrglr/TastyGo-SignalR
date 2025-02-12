using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Concrete;

namespace SignalR.BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public async Task<int> TActiveCategoryCountAsync()
        {
            return await _categoryDal.ActiveCategoryCountAsync();
        }

        public void TAdd(Category entity)
        {
            _categoryDal.Add(entity);
        }

        public async Task<int> TCategoryCountAsync()
        {
            return await _categoryDal.CategoryCountAsync();
        }

        public void TDelete(Category entity)
        {
            _categoryDal.Delete(entity);
        }

        public async Task<Category> TGetByIdAsync(int id)
        {
            return await _categoryDal.GetByIdAsync(id);
        }

        public async Task<string> TGetLastCreatedCategory()
        {
           return await _categoryDal.GetLastCreatedCategory();
        }

        public async Task<IEnumerable<Category>> TGetListAsync()
        {
            return await _categoryDal.GetListAsync();
        }

        public Task<int> TPassiveCategoryCountAsync()
        {
            return _categoryDal.PassiveCategoryCountAsync();
        }

        public void TSetStatusActive(int id)
        {
            _categoryDal.SetStatusActive(id);
        }

        public void TSetStatusPassive(int id)
        {
            _categoryDal.SetStatusPassive(id);
        }

        public void TUpdate(Category entity)
        {
            _categoryDal.Update(entity);
        }
    }
}
