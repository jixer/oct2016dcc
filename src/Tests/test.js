var supertest = require("supertest");
var should = require("should");

var server = supertest.agent("http://localhost:3000");

describe("Seeding data", function(){
    it("should insert first record", function(done){
        server
            .post("/api/values")
            .send({Key: "1", Value: "value1"})
            .expect(200, done);
    });
    it("should insert second record", function(done){
        server
            .post("/api/values")
            .send({Key: "2", Value: "value2"})
            .expect(200, done);
    });
});

describe("RESTful API at /api/Values",function(){
    describe("GET /", function() {        
        it("should return an array of one or more items", function(done){
            server
                .get("/api/Values")
                .set("Accept", "application/json")
                .expect(200)
                .expect("Content-Type", "application/json; charset=utf-8")
                .expect(function(res) {
                    res.body.should.be.an.Array;
                    res.body.length.should.be.above(0);
                })
                .end(done);
        });
    });
    describe("GET /{id}", function(){
        it("should return a value", function(done){
            server
                .get("/api/Values/1")
                .expect(200)
                .expect("Content-Type", "text/plain; charset=utf-8")
                .expect("value1", done);
        });

        it("should return 404 when a non-existent value is attempted", function(done){
            server
                .get("/api/Values/-99")
                .expect(404, done);
        });
    });
    describe("POST /", function() {
        it("should return success when you post", function(done){
            server
                .post("/api/values")
                .send({Key: "5001", Value: "Test Value"})
                .expect(200, done);
        });

        it("should create a value when you post", function(done){
            var testValue = "Some test value: " + Math.random();
            server
                .post("/api/values")
                .send({Key: "5002", Value: testValue})
                .expect(200)
                .end(function(err, res){
                    server
                        .get("/api/Values/5002")
                        .expect(200)
                        .expect(testValue, done);
                });
        });
    });
    describe("DELETE /{id}", function() {
        it("should remove the value delete a key", function(done){
            server
                .post("/api/values")
                .send({Key: "5004", Value: "Test Value"})
                .expect(200)
                .end(function(err, res) {
                    server
                        .del("/api/values/5004")
                        .expect(200)
                        .end(function(err, res) {
                            server
                                .get("/api/values/5004")
                                .expect(404, done);
                        })
                });
        });

        it("should not throw an error when you delete a key that doesn't exist", function(done){
            server
                .del("/api/values/9898989")
                .expect(200, done);            
        });
    });
});