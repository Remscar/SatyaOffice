// Create the Web Server
var http = require('http');
var server = http.createServer(function(request, response) {

    response.writeHead(200, {"Content-Type": "text/plain"});
    response.end("Welcome to Satya Office lol");

});

var port = process.env.PORT || 1337;
server.listen(port);
console.log("Server running at http://localhost:%d", port);

// Query the trigger relay API every 3 seconds.
var seconds = 2;
var interval = seconds * 1000;
var userid = "dirt";
setInterval(function() {
  	console.log("I am doing my 2 second check");
  	// Check the trigger relay API for a new signal.
  	var request = require("request");
	request ('http://satya-relay.azurewebsites.net/api/trigger/list/' + userid, function (error, response, body) {
		if (!error && response.statusCode == 200) {
			// Check if there is a positive response for some shit to go down.
			console.log(body)
			// If there is, then you're going to need to play a quote.
			request ('http://Satya-quote.azurewebsites.net/api/quotes/get/{UserID}', function (error, response, body) {
				if (!error && response.statusCode == 200) {
					// Play the fokin quote.
				}
			});
		}
	});
}, interval);
