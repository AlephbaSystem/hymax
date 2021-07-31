#!/usr/bin/env bash

clear
DIR="$( cd -- "$(dirname "$0")" >/dev/null 2>&1 ; pwd -P )"
NAME="$(basename "$DIR")"

if [ -f "$DIR/$NAME/$NAME.Android.csproj" ]; then
    DIR = "$DIR/$NAME";
elif [ -f "$DIR/$NAME.Android.csproj" ]; then
    DIR = "$DIR";
fi

echo "Android file found in $DIR"

build () {
    if [[ "$(docker images -q tspersian/xamarin-android 2> /dev/null)" == "" ]]; then
        printf "\nDocker image not found\n"
        read -p "Do you like to install it? (y/n) " -n 1 -r
        echo 
        if [[ $REPLY =~ ^[Yy]$ ]]
            sudo docker build -t tspersian/xamarin-android . &>> build.log  
            exec $0
        then
            printf "Script requires docker image with Mono, JDK, NDK and SDK installed you can use Dockerfile or install it manually\n"
            printf "To build your Docker image please run \`docker build -t tspersian/xamarin-android\` .\n"
        fi
    else
        sudo docker run -v $DIR/:/test tspersian/xamarin-android msbuild test/$NAME.Android/$NAME.Android.csproj /restore /p:AndroidSdkDirectory=/android/sdk /p:AndroidBuildApplicationPackage=true
    fi 
    exit
}

if [ ! -f "$NAME.sln" ]; then
printf "\n"
    echo "Solution file not found (.sln)"
printf "\n"
    echo "Please move script to project path where android folder in xamarin project exists(e.g. /home/{{user}}/Documents/Projects/{{Name}}/)"
    exit
else
    printf "\n"
    read -p "Project '$NAME' found continue? (y/n) " -n 1 -r
    echo 
    if [[ $REPLY =~ ^[Yy]$ ]]
        build
    then
        exit
    fi
fi
