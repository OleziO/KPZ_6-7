using System.Collections.Generic;
using ComputerCompany.Models;

namespace ComputerCompany.DAL.Repositories.Interfaces
{
    public interface IGoodsRepository
    {
        /// <summary>
        /// Get all goods
        /// </summary>
        /// <returns>IEnumerable of <see cref="Goods"/></returns>
        IEnumerable<Goods> GetAll();

        /// <summary>
        /// Gets the good with specified id
        /// </summary>
        /// <param name="id">id of the goods</param>
        /// <returns><see cref="Goods"/></returns>
        Goods GetById(int id);

        /// <summary>
        /// Creates and adds new goods to database
        /// </summary>
        /// <param name="goods">new goods object</param>
        void Add(Goods goods);

        /// <summary>
        /// Changes the properties of the specified goods in db
        /// </summary>
        /// <param name="goods">the changed version of the goods</param>
        void Change(Goods goods);

        /// <summary>
        /// Removes the goods with specified id from the db
        /// </summary>
        /// <param name="id">id of the specified goods</param>
        /// <returns>the deleted <see cref="Goods"/> object</returns>
        Goods DeleteById(int id);
    }
}