#!/usr/bin/env bash

DIR="$( cd -- "$(dirname "$0")" >/dev/null 2>&1 ; pwd -P )"
NAME="$(basename "$DIR")"

build () {
    if [[ "$(docker images -q vonproteus/xamarin-android-docker 2> /dev/null)" == "" ]]; then
        docker pull vonproteus/xamarin-android-docker
        exec $0
    else
        sudo docker run -v $DIR/:/test vonproteus/xamarin-android-docker msbuild test/$NAME.Android/$NAME.Android.csproj /restore /p:AndroidSdkDirectory=/android/sdk /p:AndroidBuildApplicationPackage=true
    fi 
    exit
}

if [ ! -f "$DIR/$NAME.Android/$NAME.Android.csproj" ]; then
    echo "Please move script to project path where android folder in xamarin project exists(ex. /home/{{user}}/Documents/Projects/{{Name}}/)"
    exit
else
    echo "File '$DIR/$NAME.Android/$NAME.Android.csproj' found continue? " 
    select yn in "Yes" "No"; do
        case $yn in
            Yes ) build;;
            No ) exit;;
        esac
    done
fi