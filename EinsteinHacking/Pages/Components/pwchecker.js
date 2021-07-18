function checkPW(string) {

    var hash = 0;
    var pw = "3077374";

    if (string.length == 0) return hash;

    for (i = 0; i < string.length; i++) {
        char = string.charCodeAt(i);
        hash = ((hash << 5) - hash) + char;
        hash = hash & hash;
    }

    return (hash.toString() == pw);
}