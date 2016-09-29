# October 2016 - Desert Code Camp
Code samples for my Desert Camp presentation, "Microservices with .NET Core and Docker"

## Part 1
Follow along for Part 1 Demos:

### Pre-Requisites
- [.NET Core SDK](https://www.microsoft.com/net/core#macos)
- [Visual Studio Code](https://code.visualstudio.com)
- [npm](https://nodejs.org/en/download/)
- [Docker](https://docs.docker.com/engine/installation/)

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