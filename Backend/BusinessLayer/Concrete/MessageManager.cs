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
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void TAdd(Message entity)
        {
            _messageDal.Add(entity);
        }

        public void TDelete(Message entity)
        {
            _messageDal.Delete(entity);
        }

        public async Task<Message> TGetByIdAsync(int id)
        {
            return await _messageDal.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Message>> TGetListAsync()
        {
            return await _messageDal.GetListAsync();
        }

        public async Task<int> TMessageCount()
        {
            return await _messageDal.MessageCount();
        }

        public void TUpdate(Message entity)
        {
            _messageDal.Update(entity);
        }
    }
}
