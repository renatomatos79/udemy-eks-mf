```sh
docker cp ./public/favicon.ico b638b6fe9d83:/usr/share/nginx/html
docker top b638b6fe9d83 <== where b638b6fe9d83 is the container ID
netstat -tuln <== verify ports
```

## Build Auth
```sh
cd auth
npm i && npm ci
docker build -t udemy-react-mf-auth:1.0.1 .
docker run -d --name udemy-react-mf-auth -p 8082:8082 udemy-react-mf-auth:1.0.1
docker container logs udemy-react-mf-auth
```

## Build Dashboard
```sh
cd dashboard
npm i && npm ci
docker build -t udemy-react-mf-dashboard:1.0.1 .
docker run -d --name udemy-react-mf-dashboard -e UDEMY_GOOGLE_MAPS_API_KEY=CONTENT_KEY_COMES_HERE -p 8083:8083 udemy-react-mf-dashboard:1.0.1
docker run -d --name udemy-react-mf-dashboard -e UDEMY_GOOGLE_MAPS_API_KEY=%UDEMY_GOOGLE_MAPS_API_KEY% -p 8083:8083 udemy-react-mf-dashboard:1.0.1
docker container logs udemy-react-mf-dashboard
```

## Build Admin
```sh
cd admin
npm i && npm ci
docker build -t udemy-react-mf-admin:1.0.1 .
docker run -d --name udemy-react-mf-admin -p 8081:8081 udemy-react-mf-admin:1.0.1
docker container logs udemy-react-mf-admin
```

## Build Root
```sh
cd root
npm i && npm ci
docker build -t udemy-react-mf-root:1.0.1 .
docker run -d --name udemy-react-mf-root -p 8080:8080 udemy-react-mf-root:1.0.1
docker container logs udemy-react-mf-root
```