FROM node:lts-alpine as build-stage
ENV NODE_ENV=production
WORKDIR /app
COPY /Frontend/package*.json .
RUN npm install

COPY ./Frontend/ .
RUN npm run build

# production stage
FROM nginx:stable-alpine as production-stage
COPY --from=build-stage /app/dist /usr/share/nginx/html
COPY /nginx/nginx.conf /etc/nginx/conf.d/default.conf
EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]