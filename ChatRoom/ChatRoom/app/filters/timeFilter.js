chatApp.filter('time', function () {
    return function (milliseconds) {
        var temp = Math.floor(milliseconds / 1000);
        var years = Math.floor(temp / 31536000);

        var ret = "";

        var minutes = Math.floor((temp %= 3600) / 60);
        if (minutes) {
            ret += " " + minutes + ' min.';
        }
        var seconds = temp % 60;
        if (seconds) {
            ret += " " + seconds + ' s.';
        }

        if (ret === "")
            return 'less than a minute';

        return ret + ' ago';
    };
});