﻿(function () {
  fetch('http://127.0.0.1:9000/ClientIntegration/GetPrinters', {
    //fetch('https://192.168.1.191:9000/ClientIntegration/GetPrinters', {
    method: 'get',
    headers: {
      'Content-Type': 'application/json'
    }
  }).then(function (response) {
    return response.text();
  }).then(function (data) {
    var printerListSelect = document.getElementById("printerList");
    printerListSelect.remove(printerListSelect.selectedIndex);
    //document.getElementById("ZplText").value = data.length.toString() + data;
    var printers = JSON.parse(data);
    //var printers = data;
    for (var i = 0; i < printers.length; i++) {
      var opt = printers[i];
      var el = document.createElement("option");
      el.textContent = opt;
      el.value = opt;
      printerListSelect.appendChild(el);
    }
  }).catch(function (error) {
    console.log(error);
    document.getElementById("ZplText").value = "Client Integration is unavailable.";
    document.getElementsByName('printerList')[0].options[0].innerHTML = "List is unavailable.";
  });
})();


async function printLocalLabel() {
  //printerList
  var printerListSelect = document.getElementById("printerList");
  var selectedPrinter = printerListSelect.options[printerListSelect.selectedIndex].text;
  var AssetId = document.getElementById("AssetId").value;
  var AssetIdHdr = document.getElementById("AssetIdHdr").value;
  var printLabel = {
    "LabelType": "ZPL",
    "ZplFormat": "ASSET",
    "LabelImage": "",
    "PrinterName": selectedPrinter,
    "LabelData": [
      { "LabelProperty": "ASSETID", "LabelValue": AssetId },
      { "LabelProperty": "ASSETIDHR", "LabelValue": AssetIdHdr }
    ],
    "RequestPrintSettings": {
      "Copies": "2"
    }
  };

  fetch('http://127.0.0.1:9000/ClientIntegration/PrintLabel', {
    method: 'post',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(printLabel)
  }).then(function (response) {
    return response.text();
  }).then(function (data) {
    document.getElementById("ZplText").value = data;
  }).catch(function (error) {
    console.log(error);
    document.getElementById("ZplText").value = "Client Integration had an error.";
  });
}

async function printLabel() {
  var AssetId = document.getElementById("AssetId").value;
  var AssetIdHdr = document.getElementById("AssetIdHdr").value;
  var returnedBase64Zpl = "";
  var labelObject = {
    "LabelType": "ZPL",
    "ZplFormat": "Asset",
    "ZplText": btoa("^XA  Material:{Material} spaces here Batch:{Batch} - Done ^XZ"),
    "LabelData": [
      { "LabelProperty": "ASSETID", "LabelValue": AssetId },
      { "LabelProperty": "ASSETIDHR", "LabelValue": AssetIdHdr }
    ]
  };

  fetch('https://labelfunctiontesting.azurewebsites.net/api/ProcessLabel', {
    //fetch('http://localhost:7071/api/ProcessLabel', {
    method: 'post',
    body: JSON.stringify(labelObject)
  }).then(function (response) {
    return response.text();
  }).then(function (data) {
    returnedBase64Zpl = data;
    plainZpl = atob(data);
    document.getElementById("ZplText").value = plainZpl;

    var printerListSelect = document.getElementById("printerList");
    var selectedPrinter = printerListSelect.options[printerListSelect.selectedIndex].text;
    var AssetId = document.getElementById("AssetId").value;
    var AssetIdHdr = document.getElementById("AssetIdHdr").value;
    var printLabel = {
      "LabelType": "ZPL",
      "ZplFormat": "ASSET",
      "ZplText": returnedBase64Zpl,
      "LabelImage": "",
      "PrinterName": selectedPrinter,
      "LabelData": [
        { "LabelProperty": "ASSETID", "LabelValue": AssetId },
        { "LabelProperty": "ASSETIDHR", "LabelValue": AssetIdHdr }
      ],
      "RequestPrintSettings": {
        "Copies": "2"
      }
    };

    fetch('http://127.0.0.1:9000/ClientIntegration/PrintLabel', {
      method: 'post',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(printLabel)
    }).then(function (response) {
      return response.text();
    }).then(function (data) {
      document.getElementById("ZplText").value = data;
    }).catch(function (error) {
      console.log(error);
      document.getElementById("ZplText").value = "Failed to print to DeviceIntegration";
    });
  });
}

async function newPrintLabel() {
  var labelObject = document.getElementById("AcsisLabelData");

  fetch('http://127.0.0.1:9000/ClientIntegration/Print', {
    //fetch('http://localhost:7071/api/ProcessLabel', {
    method: 'post',
    headers: {
      'Content-Type': 'application/json'
    },
    //body: JSON.stringify(labelObject.value)
    body: labelObject.value
  }).then(function (response) {
    return response.text();
  }).then(function (data) {
    returnedBase64Zpl = data;

  });
}


// Get Label Info buried in Hidden Field
$(window).on("load", function () {
  var val = document.getElementById("AcsisLabelData");
  console.log(val.value);
});


