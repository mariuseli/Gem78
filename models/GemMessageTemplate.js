const mongoose = require('mongoose');
const Schema = mongoose.Schema;
const gemMessageTemplate = new Schema({
  templateName: {
    type: String
  },
  templateContent: {
    type: String
  }
});
const GemMessageTemplate = mongoose.model('GemMessageTemplate', gemMessageTemplate);