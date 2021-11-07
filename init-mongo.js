db.createUser({
    user: 'coder',
    pwd: '12345678',
    roles: [
        {
            role: 'readWrite',
            db: 'test',
        },
    ],
});

// db = new Mongo().getDB("docker");

// db.createCollection('log', { capped: false });

// db.log.insert([
//     { "item": 1 },
//     { "item": 2 },
//     { "item": 3 },
//     { "item": 4 },
//     { "item": 5 }
// ]);