using COMP586.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Configuration;
using Newtonsoft.Json;

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
        public IConfiguration Configuration { get; }

        [HttpGet]
        [Authorize]
        public string Get(int owner)
        {
            string jsonified = "";
            using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("VehiclesConnection")))
            {
                string query = "SELECT * FROM VehicleInfo WHERE ownerID=@owner";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    conn.Open(); //TODO: "The ConnectionString property has not been initialized."
                    List<VehicleInfo> returnData = new List<VehicleInfo>();
                    var reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            VehicleInfo vehicle = new VehicleInfo()
                            {
                                VehicleId = reader.GetInt32(0),
                                Vin = reader["VIN"].ToString(),
                                ModelYear = reader.GetInt32(2),
                                Make = reader["make"].ToString(),
                                Model = reader["model"].ToString(),
                                Color = reader["color"].ToString(),
                                Mileage = reader.GetInt32(6),
                                OwnerId = reader.GetInt32(7),
                            };
                            returnData.Add(vehicle);
                        }
                    }
                    jsonified = JsonConvert.SerializeObject(returnData);
                }
            }
            return jsonified;
        }
    }
}
