using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_Assignments.Models;
using System.Threading.Tasks;

namespace MVC_Assignments.Repository
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetAllAsync();
        Task CreateAsync(Contact contact);
        Task DeleteAsync(long id);
    }
}