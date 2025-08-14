using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace ASP_Projects.Assignments
{
    public partial class Validator : System.Web.UI.Page
    {
        /*protected void Page_Load(object sender, EventArgs e)
        {

        }*/

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                ClientScript.RegisterStartupScript(
                    GetType(),
                    "ok",
                    "alert('All validations passed!');",
                    true
                );
            }
        }
    }
}