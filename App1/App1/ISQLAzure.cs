using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;

namespace App1
{
    public interface ISQLAzure
    {
        Task<MobileServiceUser> Authenticate();
    }
}
