// var http = require('http');
//
// const MongoClient = require('mongodb').MongoClient;
// const bodyParser = require('body-parser');
//
// var express = require('express'),
//   app = express(),
//   port = process.env.PORT || 3000;
// app.listen(port);
//
// 'use strict';
// module.exports = function(app) {
//   // todoList Routes
//   var todoList = require('controller');
//
//   console.log("sup");
//
//   app.route('/api')
//     .get(todoList.list_all_tasks)
//     .post(todoList.create_a_task);
// };



var express = require('express');
  var app = express();
  var port = process.env.PORT || 3000;
  //mongoose = require('mongoose'),
  //Task = require('./api/models/todoListModel'),

var bodyParser = require('body-parser');

//mongoose.Promise = global.Promise;
//mongoose.connect('mongodb://localhost/Tododb');


app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());

var routes = require('./routes/node-routes.js');
routes(app);

app.listen(port);


console.log('todo list RESTful API server started on: ' + port);

// http.createServer(function (req, res) {
//     res.writeHead(200, { 'Content-Type': 'text/html' });
//     res.end('Hello, Satya!');
// }).listen(process.env.PORT || 8080);
