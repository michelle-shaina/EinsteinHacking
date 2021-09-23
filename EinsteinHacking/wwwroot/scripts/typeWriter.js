var textLength = 0;
var textq = '     Would you like to learn some hacking and security basics? We`ve got the right thing for you!';
var text = '      Are you interested to learn some hacking and security basics? We`ve got the right thing for you!';

function type() {
    let textChar = text.charAt(textLength++);
    let paragraph = document.getElementById("typed");
    let charElement = document.createTextNode(textChar);
    paragraph.appendChild(charElement);
    if (textLength < text.length + 1) {
        setTimeout('type()', 50);
    } else {
        text = '';
    }
}

document.addEventListener("DOMContentLoaded", function () {
    type();
});

