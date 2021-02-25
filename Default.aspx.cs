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
            public string LabelSystem { get; set; }               // NiceLabel, Bartender, ZPL
            public string LabelTemplate { get; set; }
            public string ZplFormat { get; set; }               // If ZplText is not provided, retrieve from database based on this value
            public string ZplText { get; set; }                 // Optionally provided from caller instead of using ZplFormat
            public string ImageData { get; set; }               // If LabelType is a JPG, PNG, etc. (future use)
            public List<LabelField> LabelFields { get; set; }
            public string PrinterName { get; set; }
            public string PrinterIpAddress { get; set; }
            public string PrinterPort { get; set; }
            public int LabelCopies { get; set; }
        }

        public class LabelField
        {
            public string FieldName { get; set; }
            public string FieldValue { get; set; }
        }
    }

 
}