using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsLabelTest
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e) {

            //if (!IsPostBack) {
            //    ClientScriptManager cs = Page.ClientScript;
            //    cs.RegisterClientScriptInclude("teste", "../Scripts/printmore.js");
            //}

            hdnSomeText.Value = "JK Test";
            dynamic label = new JObject();
            label.lType = "test";
            label.lprinter = "printer1";
            hdnSomeText.Value = JsonConvert.SerializeObject(label);
        }
    }
}