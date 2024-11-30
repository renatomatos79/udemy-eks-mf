=> documentacao
https://www.mongodb.com/resources/products/compatibilities/docker

=> criando o container mongodb com usuario admin e senha m0ng0d4t4 e disco mapeado para C:\data\mongodb
docker run --name mongodb3 -d -p 27019:27017 -v C:\data\mongodb3:/data/db -e MONGODB_INITDB_ROOT_USERNAME=admin -e MONGODB_INITDB_ROOT_PASSWORD=m0ng0d4t4 mongodb/mongodb-community-server:6.0-ubi8

=> connection string para acessar o container do visual studio
mongodb://admin:m0ng0d4t4@localhost:27017/

=> building docker image
docker build -t users-api:8.0.1 .

=> running container
=> DONT FORGET TO BE LOGGED INTO DOCKER DESKTOP
docker run -d --name users-api -p 8085:8080 -e APP_MONGODB_CS=mongodb://admin:m0ng0d4t4@192.168.1.254:27019 users-api:8.0.1

=> accessing container logs
docker container logs users-api
