using System.Threading.Tasks;

namespace MasGlobal.Common.Wrappers
{
    public interface IHttpClientWrapper<T> where T : class
    {
        Task<T> Get(string url);
    }
}
