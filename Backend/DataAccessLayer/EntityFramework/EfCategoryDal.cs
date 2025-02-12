using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repository;
using SignalR.EntityLayer.Concrete;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        private readonly Context _context;
        public EfCategoryDal(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<int> ActiveCategoryCountAsync()
        {
            return await _context.Categories.Where(x => x.Status == true).CountAsync();
        }

        public async Task<int> CategoryCountAsync()
        {
            return await _context.Categories.CountAsync();
        }

        public async Task<string> GetLastCreatedCategory()
        {
            return await _context.Categories.OrderBy(x => x.Id).Select(x => x.CategoryName).LastAsync();
        }

        public async Task<int> PassiveCategoryCountAsync()
        {
            return await _context.Categories.Where(x => x.Status == false).CountAsync();

        }

        public void SetStatusActive(int id)
        {
            var value = _context.Categories.Find(id);
            value.Status = true;
            _context.SaveChanges();
        }

        public void SetStatusPassive(int id)
        {
            var value = _context.Categories.Find(id);
            value.Status = false;
            _context.SaveChanges();
        }
    }
}
