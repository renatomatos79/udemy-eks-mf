# Use a base Node.js image
FROM node:18-alpine

# Set a maintainer label (optional)
LABEL maintainer="Renato Matos"

# Set the working directory
WORKDIR /app

# Copy package.json and install dependencies
COPY package*.json ./
RUN npm install

# Copy the rest of your project files
COPY . .

# Expose the port on which webpack will run (default is 8080 for webpack-dev-server)
EXPOSE 8083

# Run webpack serve with the specified config file on startup
CMD ["npm", "run", "docker"]