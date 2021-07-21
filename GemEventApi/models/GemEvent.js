const mongoose = require('mongoose');
const Schema = mongoose.Schema;
const gemEvent = new Schema({
  eventName: {
    type: Date,
    required: true
  },
  eventDate: {
    type: Date,
    required: true
  },
  eventStartHour: {
    type: Date,
    required: true
  },
  eventEndHour: {
    type: Date,
    required: true
  },
  isGmt: {
    type: Boolean
  },
  eventColor: {
    type: Boolean,
    required: true
  },
  eventCategory: {
    type: Schema.Types.ObjectId
  },
  eventAddress: {
    type: String
  },
  eventDefaultConnectionLink: {
    type: String
  }
});

const GemEvent = mongoose.model('GemEvent', gemEvent);