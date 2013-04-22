#DiffStack

A mixed MVC and ServiceStack reference project

I've been researching how to design an MVC4/ServiceStack application that is based on some of my common requirements and attempting to answer some questions along the way. 

Project uses the following, so far:
- MVC4 as the host app
- ServiceStackController instead of Mvc Controller. Provides json and ioc improvements
- ServiceInterfaces reused. Seems ok to share with controllers and api endpoints. Simply return ViewModels or DTOs as needed.
- NLog for logging. Need to look at autowiring ILog.
- Only exposes JSON service types
- Seperate self-hosted service API
- Async/await MVC actions
- IAppHostConfig for shared config app config settings
- ORMLite via Sql Server. 
- Seperation of DTOs, Entities and ViewModels. ServiceStack works nicely with POCOs that can be reused between ORM, services etc, but I wanted to see how easy it was to map between types. Basically expecting that concerns will creep on larger projects.

TODO
- Add testing project and patterns
- ORMLite via Postgres on Windows hosts