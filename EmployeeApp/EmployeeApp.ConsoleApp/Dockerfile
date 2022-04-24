# Which image we want to run from
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Change the working directory of the container into the specified directory (created if it doesn't exist)
WORKDIR /App

# Copy the content from the host (our computer) to the container
COPY ./ ./

# Here we run our commands inside the container
# Build the app everytime the container is ran
#RUN dotnet build

# Use dotnet publish instead of build after everything is set
RUN dotnet publish -c Release

# Two phase build - First we build the solution, then pare down the environment to the minimum required to run the executable
# Since SDK is a large package, we only want the aspnet
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS run

# CHange our container working directory
WORKDIR /App

# Instead of copying everything from where our Dockerfile is,
# We just copy it from the build that we just performed
#COPY --from=build ./App/EmployeeApp.ConsoleApp/bin/Debug/net6.0/ ./

# After we use dotnet publish, it creates another folder Release
# Now we change the directory where we copy of resources from
COPY --from=build ./App/EmployeeApp.ConsoleApp/bin/Release/net6.0/publish ./

# Tell the container to run this sepcific command when the container is started
#ENTRYPOINT ["dotnet", "EmployeeApp.ConsoleApp/bin/Debug/net6.0/EmployeeApp.ConsoleApp.dll"]

# Since we built it from the previous build. Now all of the files will be in the App folder within our container
ENTRYPOINT ["dotnet", "./EmployeeApp.ConsoleApp.dll"]