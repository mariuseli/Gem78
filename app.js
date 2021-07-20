const express = require("express");
const app = express();
const mgs = require("mongoose");
const bdp = require("body-parser");
const dotenv = require("dotenv/config");

//config env variables 
dotenv.config();

// Log client info when someone comes is : log remote client infos
router.use(function (req, res, next) {

    //body parser middleware
    bdp.json();

    // .. some logic here .. like any other middleware
    console.log(`Hostname : ${req.hostName}`);
    console.log(`Remote IP : ${req.ip}`);
    console.log(`Method : ${req.method}`);
    console.log(`Query : ${req.query}`);
    next();
  });

// Connect to db
mgs.connect(
  process.env.CUSTOMCONNSTR_DbConnectionString, 
  {useNewUrlParser = true}, 
  ()=>console.log("Connected to DB Server")
);

// Start server on configured port
app.listen(process.env.SERVER_PORT,()=>{
    console.log(`Console is Up and Running on port ${process.env.SERVER_PORT} !`);
});