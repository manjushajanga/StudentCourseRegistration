# StudentCourseRegistration
This project has been developed in Visual Studio 2015 Community Edition, using ASP.Net MVC architecture. It has the following functionalities.
This is just a simple project and developed as part of the academic program.

Part-I
1. Student Registartion Form: This is basic form for collecting details from the user.
2. Login Form : pass email id and password in the login form.
3. After Student Login
    1. View Profile.
    2. AddCourses: List all the courses available in the system and also have add option to register for the courses which are currently not full and also not registered by the current user.
    3. RegisteredCourses: View the registered courses list and drop option for those courses.
    
Part-II 

This part 2 is for admin actions but the actions for admin are not developed. The admin page has different menu options and login and password are entered manually into database.
Login ID:admin.student@wayne.edu
Password:12345
FirstName: Admin (This is fixed as we are creating sessions named "user" for admin and student based on this firstname. See LoginController.cs page in the controller folder.) 

Part-I and Part-II are seperated by the page Menu based on its  Session["User"] value.

Part- II is under Development. The main aim of this part is to add courses into the system by admin and to update student grades.

Part- I Student Registration page can be improved.
