# Step 1: Build the Vue.js application
FROM node:14 as build-stage
WORKDIR /app
COPY package*.json ./
RUN npm install
COPY . .
RUN npm run build

# Step 2: Use a lightweight HTTP server to serve the built files
FROM node:14 as production-stage
WORKDIR /app
COPY --from=build-stage /app/dist /app/dist

# Install http-server to serve the static files
RUN npm install -g http-server

# Expose the application port
EXPOSE 8080

# Start the HTTP server to serve the application
CMD ["http-server", "dist"]