# Web Client Generator [![Build Status](http://simpleprodtc.cloudapp.net/app/rest/builds/buildType:id:WebApps_WebClientGenerator/statusIcon)](http://simpleprodtc.cloudapp.net/viewType.html?buildTypeId=WebApps_WebClientGenerator&guest=1)
A library that lets you generate clients for WebApi/MVC solutions. Think of it like [WSDL](http://en.wikipedia.org/wiki/Web_Services_Description_Language) for WebApi/MVC.

#Setup
1. Add the Server Component to your WebAPI/MVC solution. 
2. Add the Client Component (T4 template) to your Client Solution
3. Update webApiBaseUrl in the WebApiClientGenerator.tt to point to your WebAPI/MVC base url
4. Save the T4 template. (triggers generation)
5. Take a break cause you just saved yourself a bunch of time. 
6. REPEAT Steps 4-5
