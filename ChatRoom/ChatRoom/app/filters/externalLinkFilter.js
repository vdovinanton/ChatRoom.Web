chatApp.filter('externalLink', function () {
    // find & remove protocol (http, ftp, etc.) and get domain
    function extractDomain(url) {
        var domain;
        if (url.indexOf("://") > -1) {
            domain = url.split('/')[2];
        }
        else {
            domain = url.split('/')[0];
        }
        return domain.split(':')[0];
    }

    // parse url
    function urlify(text) {
        var urlRegex = /(https?:\/\/[^\s]+)/g;
        return text.replace(urlRegex, function (url) {
            return '<a href="' + url + '">' + extractDomain(url) + '</a>';
        });
    }
    return function (message) {
        return urlify(message);
    };
});