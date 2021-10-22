# Platform Catalog

## Applications

- Platform
- Command

### Case

The architecture for this application is based into microservices.

### Requirements

- .NET 5
- Docker
- Visual Studio or VS Code
- Postman (optional)

### Installation

- Code
1. Clone repository into your local machine

  Open cmd and paste it: ```git clone https://github.com/wbail/platform-microservice```

2. Open two instances of Visual Studio or VS Code and load each project in one instance

- Infrastructure
1. Start the Docker and make sure that Kubernetes option is enabled
2. Open cmd and navigate into ```K8S``` folder
3. Type: ```kubectl apply -f <file-name>``` to each file from the folder

- Postman collection

This collection located at Postman folder contains all endpoints divided by environment

1. Local
2. Docker
3. Kubernetes

### Usage

PS: This is a study purpose, multi-repo seems more organized way to handle with the applications.

### Tech

- .NET 5
- Docker
- Kubernetes
- Ingress Nginx

