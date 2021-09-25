var inc = 0;
var out = 0;
var str = 'Welcome to Einstein Hacking!';
var chars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789@$%&';
var t;
var lastUrl = location.href;
var hasChanged = false;

function shuffleAnime() {
    if (hasChanged) {
        clearInterval(t);
        str = 'Welcome to Einstein Hacking!';
        inc = 0;
        out = 0;
        hasChanged = false;
    } else {
        inc++;
        if (inc % 7 == 0 && out < str.length) {
            document.getElementById('anim').appendChild(document.createTextNode(str[out]));
            out++;
        } else if (out >= str.length) {
            document.getElementById('shuffle').innerHTML = '';
            clearInterval(t);
        }
        if (out < str.length && document.getElementById('shuffle') != null) {
            document.getElementById('shuffle').innerHTML = chars[Math.floor(Math.random() * chars.length)];
        }
    }
}

function callShuffleAnimationFunction() {
    hasChanged = false;
    t = setInterval(shuffleAnime, 25);
    document.getElementById('anim').innerHTML = '';
}

new MutationObserver(() => {
    const url = location.href;
    if (url !== lastUrl) {
        hasChanged = true;
    }
}).observe(document, { subtree: true, childList: true });
