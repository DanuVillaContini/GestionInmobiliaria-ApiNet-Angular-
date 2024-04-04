FROM node:17.2.0 as builder

RUN mkdir -p /app
WORKDIR /app

COPY package.json /app

RUN npm install

COPY . /app

RUN npm run build -- --prod

#Segunda etapa para una usar una imagen de nginix
FROM nginx:alpine
COPY --from=builder /app/dist/front /usr/share/nginx/html
EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]
