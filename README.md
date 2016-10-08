# October 2016 - Desert Code Camp
Code samples for my Desert Camp presentation, "Microservices with .NET Core and Docker"


# Pre-Requisites
To follow along w/ the demos, you'll need:
- [.NET Core SDK](https://www.microsoft.com/net/core#macos)
- [Visual Studio Code](https://code.visualstudio.com)
- [npm](https://nodejs.org/en/download/)
- [Docker](https://docs.docker.com/engine/installation/)
- [Postman](https://www.getpostman.com/) for testing APIs

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


## Demo 2: Yeoman Generators FTW
Execute the following steps in order to follow along with the first demo.  This section of the demo leverages [YeoMan](http://yeoman.io) to generate our files instead of `dotnet new`.

### Step 1: Setup Project
Open Visual Studio Code and then open / create a new working directory.

### Step 2: Install YeoMan and Generators
Open the command terminal in Visual Studio Code (Ctrl + \` \[Mac: Fn + \`\])

Install [YeoMan](http://yeoman.io) via npm: `npm install -g yo`

Install the [Docker Generator](https://github.com/Microsoft/generator-docker#readme) via npm: `npm install -g generator-docker`

Install the [ASP.NET Generator](https://github.com/omnisharp/generator-aspnet#readme) via npm: `npm install -g generator-aspnet`

### Step 2: Run ASP.NET Generator
In the command terminal, run the aspnet generator: `yo aspnet`.  Select the option to create a "Web API Application".  Name it whatever you like.

Browse the files to see what was created.

### Step 3: Run Docker Generator
In the command terminal, navigate to the new folder that was created (cd xyz) and run the aspnet generator: `yo docker`.  Choose the following options for the prompts:
- Project: .NET Core
- Version: rtm
- Web Server? Y (which is the default if you press \[Enter\])
- Port: 8080 (or whatever you like)
- Name: (default if fine)
- Service: (default if fine)
- Compose: (default if fine)
- Overwrite Dockerfile? Y (which is the default if you press \[Enter\])

### Step 4: Configure .vscode
Move the .vscode folder to the root level.  

Open the tasks.json file in the editor.  Set the Windows cwd value to `${workspaceRoot}\\WebAPIApplication` and the OSX version to `${workspaceRoot}/WebAPIApplication`.

Open the launch.json file in the editor.  Set the pipTransport > pipeCwd value to `${workspaceRoot}/WebAPIApplication` and the windows > pipeCwd value to `${workspaceRoot}\\WebAPIApplication`.

> These values were specified so that we can have a basic project directory structure and debug our project (`<root>/WebAPIApplication`) from the root directory. 

### Step 5: Restore project.json
At some point you should have seen a "Restore" popup.  If you didn't see this, or you did not click "Restore" when it was present, navigate within the terminal to the directory that houses our project.json file.

From there, execute `dotnet restore`

### Step 6: Debug
Start the debugger \[F5\] (Mac: \[Fn\] + \[F5\]) and pay close attention to the output.

> If you see any errors, you may have missed one of the steps in Step 4

Examine the running containers in docker as well.

Navigate in your browser to [http://localhost:8080/api/values](http://localhost:8080/api/values)

Set a breakpoint somewhere in the ValuesController and test.

[Postman](https://www.getpostman.com/) can be very useful for debugging RESTful services. 

### Completed sample

Completed sample lives here: [samples/YoAspnetAndYoDocker](samples/YoAspnetAndYoDocker)

## Remaining DCC Demos
The remaining demos presented at Desert Code Camp are not documented herein, but all the source code is available in the [samples](samples) directory.

### Demo 3: Initial Code for Service
Version 1 of the service with no backing state: [samples\BoilerPlate](samples\BoilerPlate)

### Demo 4: Storing State in a File
Version 2 of the service with state stored in a file: [samples\StatefulFileStorage](samples\StatefulFileStorage)

### Demo 5: Storing State in Mongo
Version 3 of the service with state stored in a separate MongoDB container: [samples\StatefulMongoStorage](samples\StatefulMongoStorage)
