using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Proje.Controllers
{
    public class ProductController : ApiController
    {
        public HttpResponseMessage Get()
        {

            string query = @"
                select CategoryID,CategoryName from dbo.Categories
                        ";
            DataTable table = new DataTable();
            using(var con= new SqlConnection(ConfigurationManager.
                ConnectionStrings["UrunSatisAppDB"].ConnectionString))
                using(var cmd=new SqlCommand(query,con))
                using(var da= new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
    }
}
