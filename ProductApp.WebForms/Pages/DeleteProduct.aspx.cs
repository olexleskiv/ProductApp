using System;
using System.Net.Http;

namespace ProductApp.WebForms.Pages
{
    public partial class DeleteProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.QueryString["id"] != null)
            {
                int id = int.Parse(Request.QueryString["id"]);

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7172/");
                    var response = client.DeleteAsync($"api/products/{id}").Result;

                    if (!response.IsSuccessStatusCode)
                    {
                        Response.Write($"<p>❌ Error deleting product. {response.StatusCode}</p>");
                        return;
                    }
                }
                Response.Redirect("https://localhost:7026/products");
            }
        }
    }
}
