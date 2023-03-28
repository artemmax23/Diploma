using System.Collections.Generic;
using System.Threading.Tasks;

namespace App1.Services
{
    public interface IRestService
    {
        Task<List<Book>> GetBooks(string query);
    }
}
