# Salvage Portal API

This is a very private project and it's also the property of Custodian Plc.

## Installation

This installation is required.

If you have not configured .NET on your device go through this [documentation](https://docs.microsoft.com/en-us/dotnet/core/install/windows?tabs=net60).

If you already configured your device with .NET, continue the the following steps.

#### Step 1: CLONING THE PROJECT
This step allow's you to have a copy of the project on your local machine.
```bash
git clone URL
```
#### Step 2: BUILDING PROJECT
This stage will allow you to build the project. navigate into the project folder and run the following bash code.
```bash
dotnet build
```
If you get into error request for help by opening an issue on the repo.

#### Step 3: START UP SERVER LOCALLY
Getting to this step show you have not run into error or you have resolved the error, The following code will start you server locally.
```bash
dotnet run
```

#### Step 4: CREATING YOUR DB (DATABASE)
Run the following code on the terminal from your project folder
```bash
dotnet ef Migration add salvagePortalDB
```


## License
[MIT](https://choosealicense.com/licenses/mit/)