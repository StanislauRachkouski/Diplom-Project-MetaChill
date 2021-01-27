using MetaChill.model;
using MetaChillServer.Prefs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace MetaChillServer.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class MetaChill : ControllerBase
    {
        [HttpGet]
        public string GetList()
        {
            Database db = new Database();
            List<ChillLists> advs = new List<ChillLists>();

            SqlConnection conn = new SqlConnection(db.connectionString);
            conn.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM [MetaChill].[dbo].[ChillPlace]", conn);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    ChillLists adv = new ChillLists((int)reader["id"], (string)reader["names"],
                                                        (string)reader["phonenumber"], Convert.ToSingle(reader["priceusd"]),
                                                        Convert.ToSingle(reader["course"]), Convert.ToSingle(reader["pricebyn"]));

                    advs.Add(adv);

                }
            }



            conn.Close();

            string output = JsonConvert.SerializeObject(advs, Formatting.None);
            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");

            return output;


        }

        [HttpPost]
        public StatusCodeResult addChillPlace ([FromBody] ChillLists chillLists)
        {
            Database db = new Database();
            SqlConnection conn = new SqlConnection(db.connectionString);
            conn.Open();

            String sqlQuery = $@"INSERT INTO [dbo].[ChillPlace]
           ([id]
           ,[names]
           ,[phonenumber]
           ,[priceusd]
           ,[course]
           ,[pricebyn])
           
            VALUES
           ({chillLists.id}
           ,'{chillLists.Name}'
           ,'{chillLists.phoneNumber}'
           ,{chillLists.priceUSD.ToString().Replace(",", ".")}
           ,{chillLists.courseOfUSD.ToString().Replace(",", ".")}
           ,{chillLists.priceBYN.ToString().Replace(",", ".")}
            )";

            SqlCommand command = new SqlCommand(sqlQuery, conn);
            try
            {
                command.ExecuteNonQuery();
                return StatusCode(200);

            }
            catch
            {
                return StatusCode(500);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}

 


