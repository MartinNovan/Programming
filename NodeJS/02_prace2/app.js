const express = require('express');
const session = require('express-session');
const app = express();

app.use(express.static(__dirname));
app.use(express.json());
app.use(express.urlencoded({extended: true}));
app.use(session(
    {
        secret:'secret',
        saveUninitialized: false,
        resave: false
    }
));
app.set('view-engine', 'ejs');

app.get("/", (req, res) => {
    if(req.session.viewCount){
        req.session.viewCount++;
    }else {
        req.session.viewCount = 1;
    }
    res.render('index.ejs', {viewCount: req.session.viewCount, celeJmeno: req.session.celeJmeno})
});

app.post("/", (req, res) => {
    req.session.celeJmeno = req.body.jmeno + ' ' + req.body.prijimeni;
    res.redirect("/")
});

app.listen(7700);