const express = require("express");
const userRoutes = express.Router;
const mgs = require("mongoose");
const gemUser = require("../models/GemUser");
const bcrypt = require("bcryptjs");
const {validateUserData} = require('../helpers/ModelValidation');

//Routes for Users Operations
userRoutes.get("/user-list", async (req, res)=>{
    try {
        const foundPosts = gemUser.find().limit(10);
        res.json(foundPosts);
        res.send(200);
    } catch (error) {
        res.status(400).send({message: err});
    }
});

//save user
userRoutes.post("/user-create", async(req,res)=>{
    try {
        //Get user data from request 
        const {firstName, lastName, login, password, emailAddress} = req.body;
        
        //validate data
        const {error} = validateUserData(req.body);
        if(error) return res.status(400).send(error);

        //check is user exists in database
        const emailExists = await gemUser.findOne({emailAddress: req.body.emailAddress});
        if(emailExists) res.status(400).send(`L'adresse e-mail fournie <${req.body.emailAddress}> existe déjà.`);

        //hash password
        const salt = await bcrypt.genSalt(10);
        const hashedPassword = await bcrypt.hash(req.body.password);

        //register new user
        const newUser = new GemUser({
            firstName: req.body.firstName,
            lastname: req.body.lastName,
            emailAddress: req.body.emailAddress,
            userAccessKey: hashedPassword
        });

        //register user
        await newUser.save();

        //send registered id
        req.status(200).send({_id});

    } catch (error) {
        res.status(400).send({message: err});
    }
});

//export
module.exports = userRoutes;