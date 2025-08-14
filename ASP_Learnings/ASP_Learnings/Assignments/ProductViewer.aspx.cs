using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_Projects.Assignments
{
    public partial class ProductViewer : System.Web.UI.Page
    {
        /*protected void Page_Load(object sender, EventArgs e)
        {

        }*/


        private static readonly Dictionary<string, (string ImageUrl, decimal Price)> Products = new Dictionary<string, (string, decimal)>
        {
            { "Car", ("~/Assignments/Images/Car.jpg", 7500000m) },
            { "Bike", ("~/Assignments/Images/Bike.jpg", 2000000m) },
            { "Truck", ("~/Assignments/Images/Truck.jpg", 10000000m) },
            { "Train", ("~/Assignments/Images/Train.jpg", 2000000000m) },
            { "Aeroplane", ("~/Assignments/Images/Aeroplane.jpg", 800000000m) }
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlProducts.DataSource = Products.Keys;
                ddlProducts.DataBind();
                ddlProducts.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Select --", ""));
            }
        }

        protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = ddlProducts.SelectedValue;
            if (Products.ContainsKey(selected))
            {
                /*imgProduct.ImageUrl = Products[selected].ImageUrl;*/
                /*imgProduct.ImageUrl = ResolveUrl($"~/Assignment/Images/Car.jpg");*/
                imgProduct.ImageUrl = ResolveUrl(Products[selected].ImageUrl);
                lblPrice.Text = ""; // Clear previous price
            }
            else
            {
                imgProduct.ImageUrl = "";
                lblPrice.Text = "";
            }
        }

        protected void btnGetPrice_Click(object sender, EventArgs e)
        {
            string selected = ddlProducts.SelectedValue;
            if (Products.ContainsKey(selected))
            {
                lblPrice.Text = $"Price: ₹{Products[selected].Price:N0}";
            }
            else
            {
                lblPrice.Text = "Please select a product.";
            }
        }
    }
}