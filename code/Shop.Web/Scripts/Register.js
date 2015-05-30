function RegisterOC() {
    $("#OCCompanyDiv").load("/Register/OCRegister")
}
function RegisterDC() {
    $("#OCCompanyDiv").load("/Register/DCRegister")
}
function RegisterPassword() {
    var y = document.getElementById(x).value
    document.getElementById(x).value = y.toUpperCase()
}