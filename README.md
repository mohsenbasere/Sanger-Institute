# Sanger-Institute
Sanger Institute Test

# Install Dotnet Core on Ubuntu 20.04
## Step 1 – Enable Microsoft PPA
wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb 
sudo dpkg -i packages-microsoft-prod.deb 
## Step 2 – Installing Dotnet Core SDK
sudo apt update  
sudo apt install apt-transport-https  
sudo apt install dotnet-sdk-3.1  
## Step 4 – (Optional) Check .NET Core Version
dotnet --version
## Step 5 - Dotnet Publish Project
dotnet publish --output Sanger_publish
## Step 6 - Run Project 
./SangerClient -h 
## Step 7 - Sample Of Run Project
 ./SangerClient --file-path ~/Sanger-Institute/Sample/1_control_18S_2019_minq7.fastq --flag false


