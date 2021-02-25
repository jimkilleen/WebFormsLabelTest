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

            dynamic label = new JObject();
            label.LabelType = "NiceLabel";
            label.LabelTemplate = "https://elm-dev.acsisinc.com:8080/Labels/ADDRESS_ASH.nlbl";
            label.PrinterName = "printer1";
            List<LabelDataPair> labelData = new List<LabelDataPair>();
            labelData.Add(new LabelDataPair { FieldName = "city", FieldValue = "Philly" });
            labelData.Add(new LabelDataPair { FieldName = "street", FieldValue = "Buck Dr" });
            JObject json = new JObject();
            json["LabelDatJK"] = JToken.FromObject(labelData);

            label.LabelData = json["LabelDatJK"];
            AcsisLabelData.Value = JsonConvert.SerializeObject(label);
        }
        private class LabelDataPair
        {
            public string FieldName { get; set; }
            public string FieldValue { get; set; }
        }
    }

 
}