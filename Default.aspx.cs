using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace WebFormsLabelTest
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e) {
       
            var labels = new List<AcsisLabel>();

            //// NiceLabel example:
            //var label = new AcsisLabel();
            //label.LabelTemplate = "https://elm-dev.acsisinc.com:8080/Labels/ADDRESS_ASH.nlbl";
            //label.PrinterName = "Zebra R4M Plus (203 dpi)";
            //// Label fields to populate:
            //label.LabelFields.Add(new LabelField { FieldName = "city", FieldValue = "Marlton" });
            //label.LabelFields.Add(new LabelField { FieldName = "street", FieldValue = "123 Mockingbird Ln" });

            // Acsis Label Example.
            var label = new AcsisLabel();
            label.LabelTemplate = @"c:\Temp\AcsisLabel2.tl";
            label.PrinterName = "Zebra R4M Plus (203 dpi)";
            // Label fields to populate:
            label.LabelFields.Add(new LabelField { FieldName = "Barcode1", FieldValue = "12345" });
            label.LabelFields.Add(new LabelField { FieldName = "RotatedText", FieldValue = "Jim K. ~" });

            labels.Add(label);

            AcsisLabelData.Value = JsonConvert.SerializeObject(labels);
        }

        public class AcsisLabel
        { 
            public AcsisLabel() {
                LabelFields = new List<LabelField>();
            }
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