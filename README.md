# windows-service-starter

This is a generic windows service to start/stop any process.

In this example, we are using it to start/stop pm2 process manager

# pm2

While pm2 is node.js' process manager, it can be used to manage process for Node, Java and Python applications.

# Building from source

To build the service executable from source, you must have Visual Studio. For open sources project, you can use Visual Studio community version.

After installing visual studio, the "dotnet" command is available.

Do the following to build the executable from source:

```bash
dotnet build --configuration release
```

The executable will then be created under the "bin/Release" folder.

# Installing the service

In this example, we are using pm2 start to start a TCP proxy service (https://github.com/ericcwlaw/simple-proxy).
The simple-proxy routes TCP connections from the Windows host OS to a Multipass VM.


```
sc create pm2-starter binpath=D:\sandbox\windows-service-starter\bin\Release\pm2-starter.exe depend=Multipass
```

The above command assumes you have admin rights to your Windows laptop.

After this step, you can use Windows service to change the "manual" start up to "Automatic" mode.
