```sh
docker cp ./public/favicon.ico b638b6fe9d83:/usr/share/nginx/html
docker top b638b6fe9d83 <== where b638b6fe9d83 is the container ID
netstat -tuln <== verify ports

## check dependences
npx npm-check

## check updates
npx npm-check-updates

## check updates and update package.json
npx npm-check-updates -u
```

## Build Admin
```sh
cd admin
npm i && npm ci
docker build -t udemy-react-mf-admin:1.0.1 .
docker tag udemy-react-mf-admin:1.0.1 renatomatos79/udemy-react-mf-admin:1.0.1
docker push renatomatos79/udemy-react-mf-admin:1.0.1
docker run --restart unless-stopped -d --name udemy-react-mf-admin -p 8081:8081 renatomatos79/udemy-react-mf-admin:1.0.1
docker container logs udemy-react-mf-admin
```

## Build Auth
```sh
cd auth
npm i && npm ci
docker build -t udemy-react-mf-auth:1.0.1 .
docker tag udemy-react-mf-auth:1.0.1 renatomatos79/udemy-react-mf-auth:1.0.1
docker push renatomatos79/udemy-react-mf-auth:1.0.1
docker run --restart unless-stopped -d --name udemy-react-mf-auth -p 8082:8082 renatomatos79/udemy-react-mf-auth:1.0.1
docker container logs udemy-react-mf-auth
```

## Build Dashboard
```sh
cd dashboard
npm i && npm ci
docker build -t udemy-react-mf-dashboard:1.0.1 .
docker tag udemy-react-mf-dashboard:1.0.1 renatomatos79/udemy-react-mf-dashboard:1.0.1
docker push renatomatos79/udemy-react-mf-dashboard:1.0.1
docker run --restart unless-stopped -d --name udemy-react-mf-dashboard -e UDEMY_GOOGLE_MAPS_API_KEY=CONTENT_KEY_COMES_HERE -p 8083:8083 renatomatos79/udemy-react-mf-dashboard:1.0.1
docker run -d --name udemy-react-mf-dashboard -e UDEMY_GOOGLE_MAPS_API_KEY=%UDEMY_GOOGLE_MAPS_API_KEY% -p 8083:8083 renatomatos79/udemy-react-mf-dashboard:1.0.1
docker container logs udemy-react-mf-dashboard
```

## Build Root
```sh
cd root
npm i && npm ci
docker build -t udemy-react-mf-root:1.0.1 .
docker tag udemy-react-mf-root:1.0.1 renatomatos79/udemy-react-mf-root:1.0.2
docker push renatomatos79/udemy-react-mf-root:1.0.2
docker run --restart unless-stopped -d --name udemy-react-mf-root -e UDEMY_DS_RH_ADMIN=http://3.84.216.40:8081 -e UDEMY_DS_RH_AUTH=http://3.84.216.40:8082 -e UDEMY_DS_RH_DASHBOARD=http://3.84.216.40:8083 -e UDEMY_DS_PUBLIC_PATH=http://3.84.216.40:8084/ -p 8084:8084 udemy-react-mf-root:1.0.1

docker run --restart unless-stopped -d --name udemy-react-mf-root -e UDEMY_DS_RH_ADMIN=http://3.84.216.40:8081 -e UDEMY_DS_RH_AUTH=http://3.84.216.40:8082 -e UDEMY_DS_RH_DASHBOARD=http://3.84.216.40:8083 -e UDEMY_DS_PUBLIC_PATH=http://3.84.216.40:8084/ -p 8084:8084 renatomatos79/udemy-react-mf-root:1.0.2

docker container logs udemy-react-mf-root
```
