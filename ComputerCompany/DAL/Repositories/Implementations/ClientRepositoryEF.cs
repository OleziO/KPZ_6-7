using System.Collections.Generic;
using System.Linq;
using ComputerCompany.DAL.Repositories.Interfaces;
using ComputerCompany.Models;

namespace ComputerCompany.DAL.Repositories.Implementations
{
    public class ClientRepositoryEF : IClientRepository
    {
        private readonly ComputerCompanyDBContext _dbContext;

        public ClientRepositoryEF(ComputerCompanyDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Client> GetAll()
        {
            return _dbContext.Clients;
        }

        public Client GetById(int id)
        {
            return _dbContext.Clients.FirstOrDefault(goods => goods.Id == id);
        }

        public void Add(Client goods)
        {
            _dbContext.Clients.Add(goods);
            _dbContext.SaveChanges();
        }

        public void Change(Client goods)
        {
            if (goods is null)
                return;

            var currentClient = GetById(goods.Id);
            if (currentClient is null)
                return;

            currentClient.Name = goods.Name;
            currentClient.Surname = goods.Surname;

            _dbContext.Update(currentClient);
            _dbContext.SaveChanges();
        }

        public Client DeleteById(int id)
        {
            var goods = GetById(id);

            if (goods != null)
            {
                _dbContext.Clients.Remove(goods);
                _dbContext.SaveChanges();
            }

            return goods;
        }
    }
}