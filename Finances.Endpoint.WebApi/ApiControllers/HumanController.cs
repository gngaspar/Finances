using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Finances.Endpoint.WebApi.ApiControllers
{
    using System.Threading.Tasks;

    using Finances.Contract;
    using Finances.Contract.Humans;
    [RoutePrefix("Human")]
    public class HumanController : ApiController, IHumanController
    {
        [HttpPost]
        [Route("{code:guid}/List")]
        public Task<ActionResponse<HumanListResponse>> List(Guid code, HumanListRequest input)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("{code:guid}/Add")]
        public Task<ActionResponse<int>> Add(Guid code, HumanIn input)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("{code:guid}/Edit/{human:guid}")]
        public Task<ActionResponse<int>> Edit(Guid code, Guid human, HumanIn input)
        {
            throw new NotImplementedException();
        }
    }
}
