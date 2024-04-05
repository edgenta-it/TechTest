# Number to Words Web Page

This project is a backend API (REST) that converts numerical input into words and passes these words as a string output parameter.

## Introduction

The RestAPI provides a simple functionality to convert numerical input into words. This RestAPI is designed to be integrated into web applications and developed using ASP.NET Core, providing a seamless solution for converting numerical inputs into their textual representation.

## Development Practice

**Object-Oriented Programming (OOP):**

The code demonstrates principles of encapsulation, where methods like GenerateResult and ConvertNumberToWords encapsulate specific functionality. It also exhibits abstraction, as complex operations are broken down into smaller, more manageable methods. The use of classes and methods follows the object-oriented paradigm, promoting code reuse, maintainability, and scalability.

**Single Responsibility Principle (SRP):**

Each method in the IOController class has a single responsibility, such as handling HTTP requests (Main method), generating results (GenerateResult method), and converting numbers to words (ConvertNumberToWords method).
This adheres to the SRP, ensuring that each method is focused on a specific task, making the codebase more maintainable and easier to understand.

**Error Handling:**

The code includes robust error handling mechanisms, with exceptions being caught and appropriate HTTP status codes returned to clients.
This follows the principle of defensive programming, ensuring that the application can gracefully handle unexpected errors and provide meaningful feedback to users.

**Code Readability and Maintainability:**

The code is written in a clear and concise manner, with meaningful method and variable names that enhance readability.
Comments and regions are used to provide additional context and structure to the code, making it easier for developers to understand and maintain.

**Testability:**

The code can be easily unit tested, as each method performs a specific, well-defined task.
Unit tests can verify the behavior of individual methods, ensuring that they produce the expected output for different inputs.

## Features

**Numeric to Word Conversion:** The IOController API effortlessly converts numerical inputs into their respective textual representation, accurately representing both dollars and cents. For example, the input "123.45" would be transformed into "ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS".

**Robust Error Handling:** The API includes robust error handling mechanisms to gracefully manage various input errors. It detects non-numerical inputs and delivers informative error messages to guide users towards correct usage.

## Prerequisites

**1. Operating System Compatibility**

This project developed using .NET Core API and compatible with Windows, macOS, and Linux.

**2. .NET 6 SDK**

version 6.x.x of the SDK.

**3. Development Environment**

Visual Studio (Windows), Visual Studio for Mac (macOS), Visual Studio Code (Cross-platform) or JetBrains Rider (Cross-platform)

**4. Dependency Management Tool**

NuGet is the default package manager for .NET projects. Packages and dependencies are managed via the *.csproj file in the project. Dependencies are restored using the dotnet restore command.

**5. xUnit Testing Framework**

The project is tested using xUnit.

## Run Project

```markdown data-copy
#Clone the repository containing the .NET 6 Core API to local machine using Git
git clone https://github.com/edgenta-it/TechTest.git

#Change current directory to the root directory of the cloned repository
cd <project-directory>

#Use the .NET CLI to restore project dependencies
dotnet restore

#Build the .NET 6 Core API
dotnet build

#Start the .NET 6 Core API
dotnet run
```

## Executing XUnit Test

<img width="882" alt="image" src="https://github.com/edgenta-it/TechTest/assets/96462262/faa30307-6140-42b1-be35-577ce9007799">

```markdown data-copy
#Change current directory to the directory containing the xUnit test projec
cd <test-project-directory>

#Use the .NET CLI to restore project dependencies
dotnet restore

#Execute the xUnit tests (valid input)
dotnet test UnitTest.csproj --filter FullyQualifiedName~TestIO.xUnitConvertNumberToWords_ValidInput

#Execute the xUnit tests (invalid input)
dotnet test UnitTest.csproj --filter FullyQualifiedName~TestIO.xUnitConvertNumberToWords_InvalidInput
```

After running the tests, view the test results in the terminal. Any failed tests or errors will be displayed along with the test output.

## Validate Using Postman

<img width="746" alt="image" src="https://github.com/edgenta-it/TechTest/assets/96462262/fe4d9b41-cd71-4726-88f5-734a8a71aa21">

1. Open Postman and create a new request.
2. Set the request method to GET.
3. Enter the URL of API endpoint.

```markdown data-copy  
<baseURL>/api/IO.
```

4. Include "inputNumber" query params with value.
5. Click the "Send" button to send the GET request to API.

## Validate Using Script

<img width="659" alt="image" src="https://github.com/edgenta-it/TechTest/assets/96462262/4343e4ac-c365-4662-af41-f57fd1d49a65">

1. Open PowerShell on local machine.
2. Change current directory to the directory where the PowerShell script is located.

```markdown data-copy  
cd <script-directory>
```

3. Execute the PowerShell script

```markdown data-copy
#validate to show error if non-numerical value inserted 
./TestInvalidInputScript.ps1

#validate to show words if numerical value inserted 
./TestValidInputScript.ps1
```

## DockerFile

This Dockerfile is used to containerize and deploy the project using Docker. It follows a multi-stage build process to optimize the resulting Docker image size and runtime performance.

### Stages:

**Base Image:**

This stage sets up the runtime environment for the ASP.NET application.

**build-env stage:**

This stage prepares the application for deployment.

**Build Process:**

The Dockerfile starts by setting the working directory to /app.
It copies the project file (TechTest.csproj) into the container and restores NuGet dependencies using dotnet restore.
The entire application source code is copied into the container.
The application is built in Release mode and published to the out directory using dotnet publish -c Release -o out.

**Final Image:**

The final stage (final) uses the base image from the base stage and sets the working directory to /app.
It copies the published application from the build-env stage into the final image.
The entry point for the container is specified as dotnet TechTest.dll, which runs the ASP.NET application.

## CI/CD Using GitHub Action

This GitHub Actions workflow is designed to automate the continuous integration and deployment processes for the main branch of the project repository. It consists of two main jobs: run-sonarqube-scan and docker-build-and-push.

<img width="662" alt="image" src="https://github.com/edgenta-it/TechTest/assets/96462262/3d4eab2d-72be-43c1-8734-dd354263bf5b">

<img width="645" alt="image" src="https://github.com/edgenta-it/TechTest/assets/96462262/d7fe45a6-f855-4be4-b96c-eefed7fa6329">


### Purpose:
This workflow automates the processes of code analysis using SonarQube and building/pushing Docker images. It ensures that code changes pushed to the main branch are analyzed for quality and security issues, and the resulting Docker image is built and deployed to DockerHub for further use.

### Jobs:
**1. run-sonarqube-scan:**

**Trigger**: This job is triggered whenever code is pushed to the main branch.

**Runner**: It runs on a self-hosted runner provided by Azure.

**Steps**:

**Checkout Code**: Uses the actions/checkout action to fetch the latest code from the repository.

**Setup .NET Core SDK**: Sets up the .NET Core SDK using the actions/setup-dotnet action.

**Install Dependencies**: Restores project dependencies using the dotnet restore command.

**Import Secrets from Vault**: Retrieves sensitive information such as SonarQube project key, host URL, and token from HashiCorp Vault using the hashicorp/vault-action.

**Begin SonarQube Scanning**: Initiates SonarQube scanning for code analysis using the SonarScanner tool.

**Build with dotnet**: Builds the code using the dotnet build command.

**Test with dotnet**: Executes unit tests using the dotnet test command.

**End SonarQube Scanning**: Completes the SonarQube scanning process.


**2. docker-build-and-push:**

**Trigger**: This job is also triggered when code is pushed to the main branch.

**Runner**: It runs on a self-hosted runner provided by Azure.

**Steps**:

**Checkout Code**: Fetches the latest code from the repository using the actions/checkout action.

**Set up Docker Buildx**: Configures Docker Buildx for multi-platform builds using the docker/setup-buildx-action action.

**Import Docker Secrets from Vault**: Retrieves DockerHub username and token from HashiCorp Vault.

**Login to DockerHub**: Logs in to DockerHub using the retrieved credentials with the docker/login-action action.

**Build and push**: Builds the Docker image and pushes it to DockerHub using the docker/build-push-action.

## Deployment to Azure AKS Cluster

This GitHub Actions workflow automates the deployment of our application to the production Azure AKS (Azure Kubernetes Service) cluster.

### Workflow Steps:

**Checkout Code:**

Checks out the repository's code to prepare for the deployment process.

**Import GPG_PASSPHRASE Secrets from Vault:**

Retrieves the GPG_PASSPHRASE secret from HashiCorp Vault to decrypt the kube_config file necessary for Kubernetes cluster access.

**Decrypt kube_config file:**

Decrypts the encrypted kube_config file using the retrieved GPG_PASSPHRASE.

**Extract branch name:**

Extracts the branch name from the GitHub reference to determine the deployment environment.

**Deploy application to AKS cluster:**

Sets the Kubernetes configuration to use the decrypted kube_config file.
Deletes the existing deployment in the production Kubernetes namespace to ensure a clean deployment.
Updates the Docker image version placeholder in the deployment configuration file (prod-deployment.yml) with the latest Docker image version (GitHub SHA).
Applies the updated deployment configuration to deploy the application to the production Kubernetes cluster.

## Notes:
HashiCorp Vault serves as a critical component in the CI/CD pipeline, enabling secure secret management, seamless integration with external services, and compliance with security best practices.
