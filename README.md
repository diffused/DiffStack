#DiffStack

A mixed ASP.Net MVC 4 and ServiceStack reference project

My research project on the most appropriate design of an ASP.Net MVC4 with ServiceStack hybrid application. It's based on some of my common requirements and attempts to solidify answers on some questions I have regarding ServiceStack.


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
- ORMLite via Postgres on Windows hosts
- Mono compatibility
- Backbonejs Products browser
- Angular Products browser