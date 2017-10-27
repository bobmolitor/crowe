I put a app.config variable "baseUrl" used to change the port when running localally in case your local machine uses a different port than my machon.
To run, start up 2 instances of Visual Studio and start the web controller project. In the second instance, start the console app project.I also have 2 different urls as variables.
"HelloStringURL" to run the "Hello World" api call and "HelloDBUrl" to switch if had a database table to store the message.
