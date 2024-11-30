=> documentacao
https://www.mongodb.com/resources/products/compatibilities/docker

=> criando o container mongodb com usuario admin e senha m0ng0d4t4 e disco mapeado para C:\data\mongodb
docker run --name mongodb2 -d -p 27017:27017 -v C:\data\mongodb2:/data/db -e MONGO_INITDB_ROOT_USERNAME=admin -e MONGO_INITDB_ROOT_PASSWORD=m0ng0d4t4 mongodb/mongodb-community-server:6.0-ubi8

=> acessando o container do visual studio
mongodb://admin:m0ng0d4t4@localhost:27017/

=> building docker image
docker build -t users-api:8.0.1 .
docker run -d unless-stopped --name users-api -p 8085:8080 users-api:8.0.1
docker container logs events-backend
