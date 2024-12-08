# Use a base Node.js image
FROM alpine:3.19

# Set a maintainer label (optional)
LABEL maintainer="Renato Matos"

# Set the working directory
WORKDIR /app

# Install Node.js, npm, and build tools
RUN apk add --no-cache nodejs npm python3 build-base

# Copy package.json and install dependencies
COPY package*.json ./
RUN npm install --dry-run

# Copy the rest of your project files
COPY . .

# Expose the port on which webpack will run (default is 8080 for webpack-dev-server)
EXPOSE 8083

# Run webpack serve with the specified config file on startup
CMD ["npm", "run", "docker"]