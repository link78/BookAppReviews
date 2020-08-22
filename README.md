ASP.NET CORE 3.1 Application using EntityFrameWorkCore. Book Reviews Application is sample application that enable user to add his/her favorite book and 
also give a review. This App will be deployed later in Docker containers and also in kubernetes.

Click this button to depploy azure web, web app service, sql server and sql database with azure key vault

<a href="https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2Flink78%2FBookAppReviews%2Fmaster%2Fazuredeployapp.yaml" target="_blank">
    <img src="http://azuredeploy.net/deploybutton.png"/>
</a>


To run this AspNet core in docker:
1. clone it or fork
2. Navigate to root project
3. Make sure you have installed docker and docker-compose
4. Run => docker-compose up --build or docker-compose up --build -d to skip logs
5. To shutdown just docker-compose down and to view logs run docker-compose logs
5. docker-compose ps to view containers and browse into http://0.0.0.0:80 to run the app

 docker-compose images to list all images

6. docker-compose down to shut the containers

To run this app on azure kubernetes, first you need:

7. create a resource group: az create group -n mydemo-rg -l eastus

8. create an azure acr: az acr create -g mydemo-rg -n mydemoacr --sku basic

9. login into your acr: az acr login -n mydemoacr

10. create an alias of those images: 

docker tag bookreviewappcore_sqlserver mydemoacr.azurecr.io/websqlserver

docker push mydemoacr.azurecr.io/websqlserver to push the image into your acr repository

docker tag bookreviewappcore_webapp mydemoacr.azurecr.io/webappfront:v1

docker push mydemoacr.azurecr.io/webappfront:v1

11.Replace those images with those in the webappreview.yaml

12.Create azure aks: az aks create -g mydemo-rg -n mydemoAKS -c 1 --generate-ssh-keys --attach-acr mydemoacr --enable-addons monitoring

12.install the kubectl: az aks install-cli and run az aks get-credentials -g mydemo-rg -n mydemoAKS
kubectl get nodes to verify the command

13.Deploy web app: kubectl apply -f webappreview.yml
