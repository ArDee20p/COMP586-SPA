using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace COMP586.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class VehicleInfoController : ControllerBase
    {
        private readonly ILogger<VehicleInfoController> _logger;

        public VehicleInfoController(ILogger<VehicleInfoController> logger)
        {
            _logger = logger;
        }

        /*[HttpGet]
        [Authorize]
        public IEnumerable<VehicleInfo> Get()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Server=WESTON\\SQLEXPRESS;Database=COMP586-VehiclesDB;Trusted_Connection=True;MultipleActiveResultSets=true";
                try
                {
                    SqlCommand getVehicleInfo = new SqlCommand();
                    getVehicleInfo.CommandType = System.Data.CommandType.Text;
                    getVehicleInfo.CommandText = "SELECT * FROM VehicleInfo";
                    getVehicleInfo.Connection = conn;
                    conn.Open();
                    Console.WriteLine("Connection opened to SQL Vehicles DB.");

                    SqlDataAdapter da = new SqlDataAdapter(getVehicleInfo);
                    da.Fill(dataTable);

                    conn.Close();
                    Console.WriteLine("SQL Vehicles DB connection closed.");
                    da.Dispose();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Could not open connection to SQL server!");
                }
            }

            return Enumerable.Range(1, 5).Select(index => new VehicleInfo
            {

            })
            .ToArray();
        }*/
    }
}
