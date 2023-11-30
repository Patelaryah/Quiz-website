function numofquiz(control) {
    document.getElementById("D10").style.display = "none";
    document.getElementById("D11").style.display = "none";
    document.getElementById("D12").style.display = "none";
    document.getElementById("D13").style.display = "none";
    document.getElementById("D14").style.display = "none";

    var numq = document.getElementById("DropDownList2");
    var selectednumq = numq.nodeValue;

    if (selectednumq == 2) {
        document.getElementById("D10").style.display = "block";
        document.getElementById("D11").style.display = "block";
    }
}