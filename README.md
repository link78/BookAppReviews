ASP.NET CORE 3.1 Application using EntityFrameWorkCore. Book Reviews Application is sample application that enable user to add his/her favorite book and 
also give a review. This App will be deployed later in Docker containers and also in kubernetes.

To run this AspNet core in docker:
1. clone it or fork
2. Navigate to root project
3. Make sure you have installed docker and docker-compose
4. Run => docker-compose up --build or docker-compose up --build -d to skip logs
5. To shutdown just docker-compose down and to view logs run docker-compose logs
5. docker-compose ps to view containers and browse into http://0.0.0.0:80 to run the app
6. docker-compose down to shut the containers
