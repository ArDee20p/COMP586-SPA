using COMP586.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace COMP586.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class OwnerController : ControllerBase
    {
        private readonly COMP586VehiclesDBContext db;

        public OwnerController(COMP586VehiclesDBContext db)
        {
            this.db = db;
        }

        public IConfiguration Configuration { get; }

        [HttpGet]
        [Authorize]
        public async Task<List<Owner>> GetVehicleInfosAsync()
        {
            return await db.Owners
                .FromSqlInterpolated($"SELECT * FROM dbo.Owner")
                .ToListAsync();
        }
    }
}