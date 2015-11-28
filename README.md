# cswBooks
csw test app

I have deployed the test app to a MS Azure server, also I made a clone of the database built with the script in a sql server
instance of Azure. You can find it in: http://bookscsw.azurewebsites.net/

Project:

The solution contains all the requirements of the assignment.

-I have made the app with a multi-tier arquitecture and repository pattern (Data, Transfer, logic, web-presentation)
-The data access layer use Entity Framework 6. (An implementation of my own Rep Pattern, that I call MasterRep)
-For transfer I used Automapper library.
-The Web app is in MVC 5.
-I used knockout for client-side.
-UI uses a modification of bootstrap that implements Material Design.

Instructions:

-There is only one thing you need to do for the solution to run, for some reason git is not saving the startup configuration.
1.-Right Click on Solution.
2-Properties.
3.-On the single startup projects dropdown, select "BookEd.Web.KO". and thats all, you can run the application.

The project is pointing to the azure database, if you want to use a local instance, you can create a copy of the database with 
the sqlScript I made, you can find it on the "Book.Data" project in the solution. After creating the database you just need to update the
connection string on the web.config file, with the server info of your local instance of sql.

App Description:

For time reasons I skipped some things, like authentication and exception handling, but the application is very stable.
The app shows you all the books collection with two option for filtering: author and categories, additionaly you can add books
but not authors or categories (time reasons :). Every time you update your filter a note is updated in real time showing
a description of your current view, e.g. "Showing Fantasy Books written by John Doe".

Thank You.




