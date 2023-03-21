FROM node:18-alpine AS build
WORKDIR /usr/src/app

COPY package*.json ./
RUN npm install
COPY . .
RUN npm run build --prod

FROM nginx:1.23.3-alpine
COPY --from=build /usr/src/app/dist/comm_app /usr/share/nginx/html