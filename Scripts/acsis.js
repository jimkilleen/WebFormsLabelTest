async function AcsisPrintLabel() {
  var labelObject = document.getElementById("AcsisLabelData");
  fetch('http://127.0.0.1:9000/ClientIntegration/Print', {
    method: 'post',
    headers: {
      'Content-Type': 'application/json'
    },
    body: labelObject.value
  }).then(function (response) {
    return response.text();
  }).then(function (data) {
    console.log(data);
  }).catch(function (error) {
    console.log(error);
  });
};


(function () {
  fetch('http://127.0.0.1:9000/ClientIntegration/GetPrinters', {
    method: 'get',
    headers: {
      'Content-Type': 'application/json'
    }
  }).then(function (response) {
    return response.text();
  }).then(function (data) {
    var printerListSelect = document.getElementById("printerList");
    printerListSelect.remove(printerListSelect.selectedIndex);
    var printers = JSON.parse(data);
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

async function Test() {
  var e = document.getElementById("printerList");
  var result = e.options[e.selectedIndex].value;
  alert(result);
  var txt = e.options[e.selectedIndex].text;
  alert(txt); 
  
};
