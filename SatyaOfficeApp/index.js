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
setInterval(function() {
  	console.log("I am doing my 2 second check");
  	// Check the trigger relay API for a new signal.
  	var request = require("request");
	request('http://www.google.com', function (error, response, body) {
		if (!error && response.statusCode == 200) {
    		console.log(body)
  		}
	});
}, interval);
