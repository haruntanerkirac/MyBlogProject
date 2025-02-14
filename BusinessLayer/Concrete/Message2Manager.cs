using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class Message2Manager : IMessage2Service
    {
        IMessage2Dal _messageDal;

        public Message2Manager(IMessage2Dal message2Dal)
        {
            _messageDal = message2Dal;
        }

        public List<Message2> GetAll()
        {
            return _messageDal.GetAll();
        }

        public List<Message2> GetInboxListByWriter(int id)
        {
            return _messageDal.GetListWithMessageByWriter(id);
        }

        public void TAdd(Message2 entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Message2 entity)
        {
            throw new NotImplementedException();
        }

        public Message2 TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Message2 entity)
        {
            throw new NotImplementedException();
        }
    }
}
