ASP.NET CORE 3.1 Application using EntityFrameWorkCore. Book Reviews Application is sample application that enable user to add his/her favorite book and 
also give a review. This App will be deployed later in Docker containers and also in kubernetes.

Click this button to depploy azure web, web app service, sql server and sql database with azure key vault

<a href="https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2Flink78%2FBookAppReviews%2Fmaster%2Fazuredeployapp.json" target="_blank">
    <img src="http://azuredeploy.net/deploybutton.png"/>
</a>

To run this AspNet core in docker:

clone it or fork
Navigate to root project
Make sure you have installed docker and docker-compose
This script will install docker and docker-compose for Ubuntu
```sh
$ sudo apt-get update && sudo apt install apt-transport-https ca-certificates curl software-properties-common
$ curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo apt-key add -
$ sudo add-apt-repository "deb [arch=amd64] https://download.docker.com/linux/ubuntu $(lsb_release -cs) stable"
$ sudo curl -L https://github.com/docker/compose/releases/download/1.21.2/docker-compose-`uname -s`-`uname -m` -o /usr/local/bin/docker-compose
$ sudo chmod +x /usr/local/bin/docker-compose
$ sudo usermod -aG docker $USER
$ docker version
```
To build the project run this docker-compose command:
```sh
$ docker-compose up --build -d
$ docker-compose logs (to view logs)
$ docker-compose ps (to list those running containers)
$ http://localhost:80 to browse the web application
$ docker-compose down (to shut down containers)
```
To run this app on azure kubernetes, first you need install azure cli first or use the azure cloud shell. Use this link to install in your local environment:
Azure cli: https://docs.microsoft.com/en-us/cli/azure/install-azure-cli?view=azure-cli-latest
Create a resource group:
```sh
$ az login (into Azure account)
$ az create group -n mydemo-rg -l eastus
```
Create an azure acr:
```sh
$ az acr create -g mydemo-rg -n mydemoacr --sku basic
```
login into your acr:
```sh
$ az acr login -n mydemoacr
```
Create an alias of those images:
```sh
$ docker tag bookreviewappcore_sqlserver mydemoacr.azurecr.io/websqlserver
$ docker push mydemoacr.azurecr.io/websqlserver (to push the image into your acr repository)
$ docker tag bookreviewappcore_webapp mydemoacr.azurecr.io/webappfront:v1
$ docker push mydemoacr.azurecr.io/webappfront:v1
```
11.Replace those images with those in the webappreview.yaml

12.Create azure aks:
```sh
$ az aks create -g mydemo-rg -n mydemoAKS -c 1 --generate-ssh-keys --attach-acr mydemoacr --enable-addons monitoring
```
12.Install the kubectl:
```sh
$ az aks install-cli  
$ az aks get-credentials -g mydemo-rg -n mydemoAKS 
$ kubectl get nodes (to verify the command if it works)
```
13.Deploy web app:
```sh
$ kubectl apply -f webappreview.yml
```
