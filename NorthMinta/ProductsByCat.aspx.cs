using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NorthMinta {
    public partial class ProductsByCat : System.Web.UI.Page {

        private NorthwindEntities entities = new NorthwindEntities();
        protected void Page_Load(object sender, EventArgs e) {
            if (!this.IsPostBack) {
                DropKategoria.DataSource = entities.Categories.ToList();
                DropKategoria.DataTextField = "CategoryName";
                DropKategoria.DataValueField = "CategoryID";
                DropKategoria.DataBind();
            }
        }

        protected void DropKategoria_SelectedIndexChanged(object sender, EventArgs e) {
            int selectedId = Int32.Parse(DropKategoria.SelectedValue);
            if(selectedId == -1) {
                GridProducts.DataSource = null;
            } else {
                var products = from product in entities.Products
                               where product.CategoryID == selectedId
                               select new {
                                   Name = product.ProductName,
                                   Quantity = product.QuantityPerUnit,
                                   Stock = product.UnitsInStock
                               };
                GridProducts.DataSource = products.ToArray();
            }
            GridProducts.DataBind();

        }
    }
}