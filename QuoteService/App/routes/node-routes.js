'use strict';
module.exports = function(app) {
  var apiExplore = require('../controller.js');

  app.route('/api/quote')
    .get(apiExplore.randomUrl)
    .post(apiExplore.randomUrl);

};
