using System.Collections.Generic;
using ComputerCompany.Models;

namespace ComputerCompany.DAL.Repositories.Interfaces
{
    public interface IClientRepository
    {
        /// <summary>
        /// Get all clients
        /// </summary>
        /// <returns>IEnumerable of <see cref="Client"/></returns>
        IEnumerable<Client> GetAll();

        /// <summary>
        /// Gets the client with specified id
        /// </summary>
        /// <param name="id">id of the client</param>
        /// <returns><see cref="Client"/></returns>
        Client GetById(int id);

        /// <summary>
        /// Creates and adds new client to database
        /// </summary>
        /// <param name="client">new client object</param>
        void Add(Client client);

        /// <summary>
        /// Changes the properties of the specified client in db
        /// </summary>
        /// <param name="client">the changed version of the client</param>
        void Change(Client client);

        /// <summary>
        /// Removes the client with specified id from the db
        /// </summary>
        /// <param name="id">id of the specified client</param>
        /// <returns>the deleted <see cref="Client"/> object</returns>
        Client DeleteById(int id);
    }
}