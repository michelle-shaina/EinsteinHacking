var textLength = 0;
var text = '  Are you interested to learn some hacking and security basics? We`ve got the right thing for you!';
var timer;
var lastUrlUsed = location.href;
var hasUrlChanged = false;

function typeAnime() {
    if (hasUrlChanged) {
        clearInterval(timer);
        text = '  Are you interested to learn some hacking and security basics? We`ve got the right thing for you!';
        textLength = 0;
        hasUrlChanged = false;
    } else {
        if (textLength < text.length) {
            if (document.getElementById('typed') != null) {
                let element = document.createTextNode(text.charAt(textLength));
                document.getElementById('typed').appendChild(element);
                textLength++;
            }
        } else if (textLength >= text.length) {
            clearInterval(timer);
        } else {
            text = '';
        }
    }
}

function callTypeAnimationFunction() {
    hasUrlChanged = false;
    timer = setInterval(typeAnime, 50);
    document.getElementById('typed').innerHTML = '';
}

new MutationObserver(() => {
    const url = location.href;
    if (url !== lastUrlUsed) {
        hasUrlChanged = true;
    }
}).observe(document, { subtree: true, childList: true });
