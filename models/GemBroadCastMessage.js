const mongoose = require('mongoose');
const Schema = mongoose.Schema;
const gemBroadCastMessage = new Schema({
  creationDate: {
    type: Date
  },
  sendDate: {
    type: Date
  },
  messageContent: {
    type: String
  },
  status: {
    type: String
  },
  userGroups: [{
    type: Schema.Types.ObjectId
  }],
  eventConcerning: {
    type: Schema.Types.ObjectId
  },
  notifyByMail: {
    type: Boolean
  },
  notifyBySms: {
    type: Boolean
  },
  notifyByApp: {
    type: Boolean
  }
});

const GemBroadCastMessage = mongoose.model('GemBroadCastMessage', gemBroadCastMessage);