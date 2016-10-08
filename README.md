# October 2016 - Desert Code Camp
Code samples for my Desert Camp presentation, "Microservices with .NET Core and Docker"


# Pre-Requisites
To follow along w/ the demos, you'll need:
- [.NET Core SDK](https://www.microsoft.com/net/core#macos)
- [Visual Studio Code](https://code.visualstudio.com)
- [npm](https://nodejs.org/en/download/)
- [Docker](https://docs.docker.com/engine/installation/)

# Demo Scripts
Once you have installed the pre-requisites, you can follow along with the demos 

## Demo 1: First Dockerized .NET Core App
Execute the following steps in order to follow along with the first demo.

### Step 1: Create the Project
Fire up Visual Studio Code.  Then create and open a new folder in Visual Studio Code.

Open command terminal via Ctrl + \` \[Mac: Fn + \`\]

From the command terminal, execute `dotnet new -t Web`

Open package.json.  Ensure that VS Code runs a restore against package.json



### Step 2: Debug the Project (Not in Docker Yet)
Start debugging the project via F5 \[Mac: Fn + F5\]

Once done, stop debugging via the Stop button.



### Step 3: Create the Docker Image

Create a new file under root of the project named 'Dockerfile'.

Navigate to [DockerHub](http://dockerhub.com) and find an appropriate image for microsoft/dotnet:onbuild.

Configure the Dockerfile with the image we determined and set environment variables along with ports that we'll need to expose in the Docker host:

```
FROM microsoft/dotnet:1.0.0-preview2-onbuild

ENV ASPNETCORE_URLS http://*:5000

EXPOSE 5000
```

Back in the terminal (Ctrl + \` \[Mac: Fn + \`\] if it closed), execute `docker build -t dotnetfilenew .` in order to build our Docker image using the Dockerfile.

Examine the build output for informaiton about what Docker is doing.  Also execute `docker image` and examine the output.  You should see the image we just created.



### Step 4: Run the Web App in a Container

Now execute `docker run -i --rm -p 8080:5000 dotnetfilenew` in order to run the sample.

Test this out via a web browser by navigating to [http://localhost:8080/](http://localhost:8080/)


### Completed sample

Completed sample lives here: [samples/DotNetNew](samples/DotNetNew)

---



### Demo Steps
Steps to complete the first segment of demonstrations:







#### Step 1: Install YeoMan and Generators
Install [YeoMan](http://yeoman.io) via npm:
`npm install -g yo`

Install the [Docker Generator](https://github.com/Microsoft/generator-docker#readme) via npm:
`npm install -g generator-docker`

Install the [ASP.NET Generator](https://github.com/omnisharp/generator-aspnet#readme) via npm:
`npm install -g generator-aspnet`

#### Step 2: Run ASP.NET Generator
Create a directory somewhere and navigate to the directory.

Run the aspnet generator: 
`yo aspnet`


#### Step 3: Run Docker Generator
Create a directory somewhere and navigate to the directory.

Run the aspnet generator: 
`yo docker`

#### Step 4: Debug
Open VS Code and navigate to the StatefulValuesService folder.

Debug and note that you are running in a container.  View running containers in docker.
