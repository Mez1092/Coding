

var CryptoJS = require("crypto-js");
var internal_token = "CWXCRD60S3GLIEAICLZE";
var file_url = "dlQI7LhIZ1d/bhbEhDvoNfscphYNM/jlNVGOWrfEDB3cDUOJX2Zr5yjAELqXMBgqFliZnpxd9lP0SBWOuDIm2YUSgcPCedA9LTuMmX10x6euockCvxiAHSWQ9DE4TEm8OzPrj/J2rKIy5s16YI84W/GV6t6T57szjrcMqRSkTCHdIqSZtcRawuulPx6/rDo7KYCLsDj9xKfLlyHYkXct6B4ZtI5Z+ZVXprX6pqJ3xp5GvSMy2TN9VHM4QDVwPdqe2FLmYv/FoPbla7UBxS32HWuNeMm/xoQ8HSFFHlXXiImuZ6xnne6pbc9joaLPJ/glbTD39VvgjjbNtZ1jWAsk2By+QhH4IX3M0Ykr0+/QGk/zj3O6hUekbks0q7t4S2fEmecYiunrag/AfwX7VovLz3PKnUlxLptuAb5vcptlymDYJ6rWOL9vYNtDggq4IWJBCnjpTFXwYdnVdzO1/sX36DeslTR7aKtZNpljdFNoIRmp4dsR1e6lo5FjHa/MV06YeqMwkutqSomxjVjnI5vJTpfaMnLIpyUJX87+AInEULeBkS+ghsbG7fHMWsrCeNzsa0OiSs5+g+U89hkXrIVyMp/IRG/3F7r6";



function decryptByDES(ciphertext, key) {
var keyHex = CryptoJS.enc.Utf8.parse(key);
console.log(keyHex);
// direct decrypt ciphertext
var decrypted = CryptoJS.DES.decrypt({
ciphertext: CryptoJS.enc.Base64.parse(ciphertext)
}, keyHex, {
mode: CryptoJS.mode.ECB,
padding: CryptoJS.pad.Pkcs7
});
return decrypted.toString(CryptoJS.enc.Utf8);
}



console.log("decrypted url:" + decryptByDES(file_url, internal_token))