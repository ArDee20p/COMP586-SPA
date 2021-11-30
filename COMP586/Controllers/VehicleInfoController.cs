using COMP586.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace COMP586.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class VehicleInfoController : ControllerBase
    {
        private readonly COMP586VehiclesDBContext db;

        public VehicleInfoController(COMP586VehiclesDBContext db)
        {
            this.db = db;
        }

        public IConfiguration Configuration { get; }

        [HttpGet]
        [Authorize]
        public async Task<List<VehicleInfo>> GetVehicleInfosAsync(int owner)
        {
            return await db.VehicleInfos
                .FromSqlInterpolated($"SELECT * FROM dbo.VehicleInfo WHERE ownerID={owner}")
                .ToListAsync();
        }
    }
}
