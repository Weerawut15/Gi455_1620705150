const sqlite = require('sqlite3').verbose();

let db = new sqlite.Database('./db/chatDB.db', sqlite.OPEN_CREATE | sqlite.OPEN_READWRITE, (err)=>{

    if(err) throw err;

    console.log('Connected to database.');

    var id = "test01";
    var password = "12345";
    
});