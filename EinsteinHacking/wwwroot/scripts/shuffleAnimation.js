var $ = function (id) {
    return document.getElementById(id);
};
var inc = 0;
var out = 0;
var str = 'Welcome to Einstein Hacking!';
var chars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789@$%&';
var t;

var anim = function () {
    inc++;
    if (inc % 7 === 0 && out < str.length) {
        $('anim').appendChild(document.createTextNode(str[out]));
        out++;
    } else if (out >= str.length) {
        $('shuffle').innerHTML = '';
        clearInterval(t);
    }
    if (out < str.length) {
        $('shuffle').innerHTML =
            chars[Math.floor(Math.random() * chars.length)];
    }
};
t = setInterval(anim, 25);
$('anim').innerHTML = '';
