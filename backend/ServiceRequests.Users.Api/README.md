=> documentacao
https://www.mongodb.com/resources/products/compatibilities/docker

=> connection string para acessar o container do visual studio
mongodb://admin:m0ng0d4t4@localhost:27017/


# Creating a Docker Network

```sh
docker network create --driver bridge backend-bridge-network
```

# Windows - Creating mongodb com usuario admin e senha m0ng0d4t4 e disco mapeado para C:\data\mongodb

```sh
docker run --name mongodb3 -d -p 27019:27017 --network=backend-bridge-network  -v C:\data\mongodb3:/data/db -e MONGODB_INITDB_ROOT_USERNAME=admin -e MONGODB_INITDB_ROOT_PASSWORD=m0ng0d4t4 mongodb/mongodb-community-server:6.0-ubi8
```

# Linux - Creating mongodb com usuario admin e senha m0ng0d4t4 e disco mapeado para ~/mongo-data

```sh
docker run --name mongodb -d -p 27017:27017 --network=backend-bridge-network  -v /home/ubuntu/mongo-data:/data/db -e MONGODB_INITDB_ROOT_USERNAME=admin -e MONGODB_INITDB_ROOT_PASSWORD=m0ng0d4t4 mongodb/mongodb-community-server:6.0-ubi8
```

# building docker image

```sh
docker build -t svc-requests-users-api:8.0.3 .
docker tag svc-requests-users-api:8.0.3 renatomatos79/svc-requests-users-api:8.0.3
docker login
docker push renatomatos79/svc-requests-users-api:8.0.3
docker run -d --restart unless-stopped --network=backend-bridge-network --name svc-requests-users-api -p 8091:8080 -e APP_MONGODB_CS=mongodb://admin:m0ng0d4t4@mongodb:27017 renatomatos79/svc-requests-users-api:8.0.3
docker container logs svc-requests-users-api
```

# building docker image
mongodb://sysadmin:m0ng0d4t4@udemydb-20241201-992382569486.us-east-1.docdb-elastic.amazonaws.com:27017


=> running container
=> DONT FORGET TO BE LOGGED INTO DOCKER DESKTOP
docker run -d --name users-api -p 9081:8080 -e APP_MONGODB_CS=mongodb://admin:m0ng0d4t4@192.168.1.254:27019 users-api:8.0.1



=> accessing container logs
docker container logs users-api

=> how to use Patch
[
  { "op": "replace", "path": "/Roles", "value": "Dashboard,operator" },
  { "op": "replace", "path": "/ImageUrl", "value": "https://v4.mui.com/static/images/avatar/1.jpg" },
  { "op": "replace", "path": "/IsActive", "value": "true" }
]

