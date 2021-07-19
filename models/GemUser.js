const mongoose = require('mongoose');
const Schema = mongoose.Schema;
const gemUser = new Schema({
  firstName: {
    type: String,
    required: true
  },
  lastName: {
    type: String,
    required: true
  },
  emailAddress: {
    type: String
  },
  isMale: {
    type: Boolean,
    required: true
  },
  whatsappPhoneNumber: {
    type: Number,
    required: true
  },
  groups: [{
    type: GemUserGroup
  }]
});

const GemUser = mongoose.model('GemUser', gemUser);
