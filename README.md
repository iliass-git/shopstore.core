# Shopstore web api    
This is a simple web api application built with ASP.Net Core 6 and hosted in Github package as a docker container.  
When committing to the main Branch or opening a new Pull Request a CI/CD Pipeline is triggerd and the following Jobs are executed:
* **Build**: the source code is built and the project dependencies are checked for vulnerabilities. A report after the dependency check is generated and deplyoed as an artifact.
* **Test**: unit tests are performed.
* **Api-Test**: a postman collection with tests is excuted with newman. At the end an artifact which contains the result is deployed.
* **Publish**: After the above jobs have been successfully executed, the application is dockerized and pushed to github package.
## Tools
* ASP.NET Core 6
* Entity Framework
* Swagger
* PostgreSQL
* Docker
* CI/CD: Github Actions
* API Test: Newmann
* Dependency Check: OWASP Dependency-Check
* Postman
### Setup locally
* Clone the application
```
$> Git clone https://github.com/iliass-de/shopstore.git
```
* Run docker file
```
$> docker build . --tag shopstore:latest
$> docker run -d -p 8080:80 shopstore:latest
```
* Run PostgreSQL container
```
$> docker run -itd -e POSTGRES_USER=server_admin -e POSTGRES_PASSWORD=P@ssw0rd -p 5432:5432 --name postgresql postgres
```
* Install the postgresql-client and run the SQL Script
```
$> sudo apt-get install -y postgresql-client
$> psql -h localhost -U server_admin -f ./shopestore-schema.sql
```
* Access the swagger api definition throw http://localhost:8080/swagger/index.html

