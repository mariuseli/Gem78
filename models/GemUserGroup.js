const mongoose = require('mongoose');
const Schema = mongoose.Schema;
const gemUserGroup = new Schema({
  groupName: {
    type: String,
    required: true
  },
  whatsappAccountId: {
    type: String
  },
  users: {
    type: String
  }
});
const GemUserGroup = mongoose.model('GemUserGroup', gemUserGroup);