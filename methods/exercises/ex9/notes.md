# Serveless Applications with Azure

Modern businesses run on multiple applications and services. How well your business runs can often be impacted by how efficiently you can distribute the right data to the right task. Automating this flow of data can streamline your business even further. Chossing the right technology for these critical data integrations and process automation is also an important consideration.

In business, one way to guarantee a high-quality service to users and high-quality products is to design and implement strict business processes. Such processes may involve multiple steps, multiple people and multiple software packages.

Business processes modeled in software are often called workflows. Azure includes four different technologies that you can use to build and implement workflows that integrate multiple systems:
- Logic Apps
- Microsoft Flow
- WebJobs
- Azure Functions

All these technologies:
- Accept inputs. An input is a piece of data that is supplied to the workflow
- Run actions. An action is a simple operation that the workflow executes and may often modify data or cause another action to be performed.
- Can include conditions. A condition is a test, often run against an input, that may decide which action to execute next.
- They can all produce outputs. An output is a piece of data or a file that is created by the workflow.

## Logic Apps

Logic Apps is a service within Azure that you can use to automate, orchestrate and integrate disparate components of a distributed application.

## Microsoft Flow

Microsoft Flow is a service that you can use to create workflows even when you have no deployment or IT Pro experience. You can create workflows that integrate and orchestrate many different components by using the website or the Microsoft Flow mobile app.

    - Automated
    - Button
    - Scheduled
    - Business process

## WebJobs and the WebJobs SDK

The Azure App Service is a cloud-based hosting service for web applications, mobile back-ends and RESTful APIs.These applications often need to perform some kind of background task.

WebJobs are a part of the Azure App Service that you can use to run a program or script automatically. There are two kinds of WebJobs:
    - Continous
    - Triggered
To determine what actions your WebJobs takes, you can write code in several different languages.

## Azure Functions
An Azure Function is a simple way for you to run small pieces of code in the cloud, without having to worry about the infrastructure required to host the code. HttpTrigger, TimerTrigger, BlobTrigger,CosmosDBTrigger
Azure functions can integrate with many different services both within Azure and from third parties. These services can trigger your function, or send data input to your function, or receive data output from your function.

