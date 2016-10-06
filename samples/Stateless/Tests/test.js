var supertest = require("supertest");
var should = require("should");

var server = supertest.agent("http://localhost:3000");

describe("RESTful API at /api/Values",function(){
    describe("Get", function() {        
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
    describe("Get {id}", function(){
        it("should return a value", function(done){
            server
                .get("/api/Values/1")
                .expect(200)
                .expect("value1")                
                .end(done);
        });

        it("should return 404 when a non-existent value is attempted", function(done){
            server
                .get("/api/Values/-99")
                .expect(204)
                .end(done);
        });
    });
});