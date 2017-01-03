using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Primer.Infrastructure
{
    public interface ICustomController
    {
        Task<long> GetPageSize(CancellationToken cToken);

        Task PostUrl(string newUrl, CancellationToken cToken);
    }
}