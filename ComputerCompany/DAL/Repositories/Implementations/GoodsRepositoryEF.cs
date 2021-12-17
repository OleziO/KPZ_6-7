using System.Collections.Generic;
using System.Linq;
using ComputerCompany.DAL.Repositories.Interfaces;
using ComputerCompany.Models;

namespace ComputerCompany.DAL.Repositories.Implementations
{
    public class GoodsRepositoryEF : IGoodsRepository
    {
        private readonly ComputerCompanyDBContext _dbContext;

        public GoodsRepositoryEF(ComputerCompanyDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Goods> GetAll()
        {
            return _dbContext.Goods;
        }

        public Goods GetById(int id)
        {
            return _dbContext.Goods.FirstOrDefault(goods => goods.Id == id);
        }

        public void Add(Goods goods)
        {
            _dbContext.Goods.Add(goods);
            _dbContext.SaveChanges();
        }

        public void Change(Goods goods)
        {
            if (goods is null)
                return;

            var currentGoods = GetById(goods.Id);
            if (currentGoods is null)
                return;

            currentGoods.Name = goods.Name;
            currentGoods.Price = goods.Price;
          
            _dbContext.Update(currentGoods);
            _dbContext.SaveChanges();
        }

        public Goods DeleteById(int id)
        {
            var goods = GetById(id);

            if (goods != null)
            {
                _dbContext.Goods.Remove(goods);
                _dbContext.SaveChanges();
            }

            return goods;
        }
    }
}