'use strict';

var randomArray = [
    {
        "url":"wwww.pornhub.com"
    },
    {
        "url":"wwww.pornhub2.com"
    },
    {
        "url":"wwww.pornhub3.com"
    },
    {
        "url":"wwww.pornhub4.com"
    },
    {
        "url":"wwww.pornhub5.com"
    },
]
exports.randomUrl = function(req, res) {
    console.log("fuck.. it worked!");
    var item = randomArray[Math.floor(Math.random()*randomArray.length)];
    res.send(item.url);
};
