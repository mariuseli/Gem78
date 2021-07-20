const mongoose = require('mongoose');
const Schema = mongoose.Schema;
const gemUser = new Schema({
  firstName: {
    type: String,
    required: true,
    min: 3
  },
  lastName: {
    type: String,
    required: true,
    min: 3
  },
  emailAddress: {
    type: String
  },
  userAccessKey: {
    type: String,
    min: 3,
    required: true
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
