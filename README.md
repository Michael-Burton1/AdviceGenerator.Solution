# _Goldblumin'_

#### _A C# web application to gain insightful words of wisdom from the mind of Jeff Goldblum_

#### By _Ryan Walker, Sammai Gutierrez, James Wyn, Michael Burton, Carlos Mendez_

## Description
This application will allow users to be presented with a random thought, a curated thought based upon a searched keyword, and chaotic thought all from the mind of Jeff Goldblum. The application utilizes two separate API calls, one to return quotes and one to return words that are similar to a searched keyword. 

## Setup and Use

### Prerequisites
* [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
* A text editor like [VS Code](https://code.visualstudio.com/)
* A command line interface like Terminal or GitBash to run and interact with the app.
* Acquire the word-finding API key from Datamuse by registering an account [here](https://www.datamuse.com/api/).


### Installation for Client App
1. Clone the repository: `$ git clone https://github.com/yesthecarlos/AdviceGenerator.Solution`
2. Navigate to the `AdviceGenerator.Solution/` directory on your computer
3. Open with your preferred text editor to view the code base
4. To run the app:
    * Navigate to `AdviceGenerator.Solution/AdviceGenerator` in your command line
    * Once in the AdviceGenerator folder, make a file called 'EnvironmentVariables.cs' 
    * Add the following content to 'EnvironmentVariables.cs' with your own API key without the squared brackets:
        ```
        namespace AdviceGenerator.Models
        {
            public static class EnvironmentVariables
            {
                public static string ApiKey = "[YOUR-API-KEY-HERE]";
            }
        } 
        ```
    * Run the command `dotnet restore` to restore the dependencies that are listed in the .csproj
    * Run the command `dotnet build` to build the project and its dependencies into a set of binaries
    * Finally, run the command `dotnet run` to run the project!
    * Note: `dotnet run` also restores and builds the project, so you can use this single command to start the app
    * View the application via your preferred web browser by visiting `localhost:5003/`


## Known Bugs
There were no bugs found

## Technologies Used
* ASP .NET Core MVC
* C#
* VS Code
* Entity Framework Core
* LINQ
* Json.NET - Newtonsoft
* RestSharp
* Adobe Illustrator
* GitHub
* [Datamuse API](https://www.datamuse.com/api/)
* [TheySaidSo API](https://theysaidso.com/)

### License

MIT

Copyright (c) 2021 _Ryan Walker, Sammai Gutierrez, James Wyn, Michael Burton, Carlos Mendez_

## Contact Information
_Please reach out via GitHub_




