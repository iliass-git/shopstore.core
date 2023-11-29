# Shopstore web api    
This documentation describes a straightforward web API application built using **ASP.NET Core 6**. The application is hosted on **GitHub** as a **Docker container**. When changes are made, such as committing to the main branch or opening a new pull request, a **CI/CD pipeline** is triggered and executing the following jobs:
* **Build**: The source code is compiled, and project dependencies are checked for vulnerabilities. A report is generated after the dependency check and deployed as an artifact.
* **Test**: Unit tests are performed.
* **Api-Test**: A Postman collection with tests is executed using Newman. The results are packaged into an artifact.
* **Publish**: After successful execution of the above jobs, the application is dockerized and pushed to GitHub Packages.
## Tools
* **ASP.NET Core 6**
* **Entity Framework**
* **Swagger**
* **PostgreSQL**
* **Docker**
* **CI/CD: Github Actions**
* **API Test: Newmann**
* **Dependency Check: OWASP Dependency-Check**
* **Postman**
### Setup locally
1. Clone the application
```
$> Git clone https://github.com/iliass-de/shopstore.git
```
2. Build the Docker image:
```
$> docker build . --tag shopstore:latest
```
3. Run the Docker container:
```
$> docker run -d -p 8080:80 shopstore:latest
```
4. Run a PostgreSQL container:
```
$> docker run -itd -e POSTGRES_USER=server_admin -e POSTGRES_PASSWORD=P@ssw0rd -p 5432:5432 --name postgresql postgres
```
5. Install the PostgreSQL client and execute the SQL script:
```
$> sudo apt-get install -y postgresql-client
$> psql -h localhost -U server_admin -f ./shopestore-schema.sql
```
6. Access the Swagger API definition at http://localhost:8080/swagger/index.html

