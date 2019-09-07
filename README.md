# GreenSlate-App

This is an ASP.NET application using Entity Framework, MVC,KnockoutJS,Ajax, and jquery validation.

In order to create the seeds to see  the data for this app you have to run these commands on the package manager console. 
enable-migrations -enableautomaticmigrations (-Force =  if necessary)
update-database -verbose

In case the table CreateProjectItems doesn't reflect you could run this simple insert and you would be able to see the data:

INSERT INTO CreateProjectItems (StartDate, EndDate, Credits, ProjectId)
VALUES ('9/6/2019', '10/6/2019', 12,1);

Hope you love it!
