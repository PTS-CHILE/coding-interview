using System.Threading.Tasks;

namespace Paytech.CodingInterview.API.Data
{
    public interface IMongoRepository
    {
        Task<T> InsertAsync<T>(T document);
    }
}