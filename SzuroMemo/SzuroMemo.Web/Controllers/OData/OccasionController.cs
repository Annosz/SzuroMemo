using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using SzuroMemo.Dal.Dtos;
using SzuroMemo.Dal.Services;

namespace SzuroMemo.Web.Controllers.OData
{
    [Produces("application/json")]
    public class OccasionController : ODataController
    {
        public OccasionController(OccasionService occasionService)
        {
            OccasionService = occasionService;
        }

        public OccasionService OccasionService { get; }

        [EnableQuery]
        public IQueryable<OccasionDto> Get() => OccasionService.GetOccasions().Results.AsQueryable();
    }
}