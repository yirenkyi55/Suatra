using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suatra.Application.Common.Contracts.Services
{
    public interface IUrlService
    {
        string GenerateAbsoluteUrl(string path);

        string AppendUriQueryInfo(string endpoitnUri, IDictionary<string, string> queries);
    }
}
