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

            var labels = new List<AcsisLabel>();

            var label = new AcsisLabel();
            label.LabelSystem = "NiceLabel";
            label.LabelTemplate = "https://elm-dev.acsisinc.com:8080/Labels/ADDRESS_ASH.nlbl";
            // Fields to Add
            label.LabelFields.Add(new LabelField { FieldName = "city", FieldValue = "Philly" });
            label.LabelFields.Add(new LabelField { FieldName = "street", FieldValue = "Buck Dr" });

            labels.Add(label);

            AcsisLabelData.Value = JsonConvert.SerializeObject(labels);
        }

        public class AcsisLabel
        {
            public AcsisLabel() {
                LabelFields = new List<LabelField>();
            }
            public string LabelSystem { get; set; }             // NiceLabel, Bartender, ZPL
            public string PrinterName { get; set; }
            public string LabelTemplate { get; set; }           // URL to template or name of local file 
            public List<LabelField> LabelFields { get; set; }
            public int LabelCopies { get; set; }
        }

        public class LabelField
        {
            public string FieldName { get; set; }
            public string FieldValue { get; set; }
        }
    }

 
}