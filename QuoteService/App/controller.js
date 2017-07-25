'use strict';

var randomArray = [
    {
        "url":"http://satya-quote.azurewebsites.net/audio/democratize.mp3"
    },
    {
        "url":"http://satya-quote.azurewebsites.net/audio/dreams.mp3"
    },
    {
        "url":"http://satya-quote.azurewebsites.net/audio/edu_opportunities.mp3"
    },
    {
        "url":"http://satya-quote.azurewebsites.net/audio/dreams.mp3"
    },
    {
        "url":"http://satya-quote.azurewebsites.net/audio/dreams.mp3"
    },
]
exports.randomUrl = function(req, res) {
    var item = randomArray[Math.floor(Math.random()*randomArray.length)];
    res.send(item.url);
};
