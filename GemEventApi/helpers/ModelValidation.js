const validator = require("@hapi/joi");

// User data validation
const validateUserData = (data) => {
  const schema = {
    firstName: validator.string().min(6).required(),
    lastName: validator.string().min(6).required(),
    emailAddress: validator.string().min(6).required().email(),
    password: validator.string().min(6).required(),
  };

  return validator.validate(data, schema);
};

module.exports.validateUserData = this.validateUserData;