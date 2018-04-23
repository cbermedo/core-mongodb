# Contributor: Cristian Bermedo Gonzalez

Crear base de datos en MongoDb
> use DBNAME
> db.createCollection('NAMECOLLECTION') --en este caso seria Products
> db.Products.insert({'ProductId':1,'ProductName':'Desktop All in One','Price':43000,'Category':'Electronics'})
> db.Products.find({})
