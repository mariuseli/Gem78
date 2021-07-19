const mongoose = require('mongoose');
const Schema = mongoose.Schema;
const gemEventCategory = new Schema({
  categoryName: {
    type: String
  },
  categoryColor: {
    type: String
  }
});

const GemEventCategory = mongoose.model('GemEventCategory',gemEventCategory );