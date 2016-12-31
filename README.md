# White Lotus
“White lotus” is a small yoga studio centre in London that offers mainly yoga classes and workshops.

The owner of the studio employed you to create a small on line computerised system that would aid the admin and the management of the “White Lotus” studio. 
The system requires the following main functionalities:

- Managing yoga sessions functionality
- On line reservation of yoga sessions

The owner would also desire, if possible, additional functionalities (listed under “Other Desired functionality” section).

### Managing yoga sessions functionality: ##
The system should allow the user to dynamically add information about types of classes/workshops sessions and their schedule. The system will allow the yoga studio owner / manager and the yoga instructors to:

1. Add a yoga teacher to the database.
2. Add a yoga session to the database. A session is taught by a certain yoga teacher and it can be a class or workshop.
	- A workshop is a one-off session

		- It has a date, time and usually lasts between 2 and 4 hours.
		- It has a description.	


	- A class is a weekly session
	
		- It is on a certain day of the week at a specific time.
		- It has a level (beginner, intermediate or advanced)
		- The class usually last 60 minutes or 90 minutes. 
		- The capacity of a class is between 6 and 20.
		- It has a short description.

	A straightforward (basic) way to add a class is to set every class session manually.  In this case the manager would have to create the instance sessions for the yoga classes one by one.
	
	A more desired (advanced) way is to set the class once in the system and the manager to make the classes available for a certain number of weeks in one go.




3. Remove a workshop or a class.
4. Cancel a certain instance of a class. This would be done as a “soft delete” The difference between removing a class and canceling it is that in the second case, the class will be still visible on the page, but flagged that it has been cancelled.
5. List all the classes available  in the system (from the current day on-wards)
6. List all workshops available (from the current day on-wards)

### Online reservation of yoga sessions: ##

The system should allow online reservation of a particular yoga session.

1. In order for somebody to be able to reserve a yoga class or workshop, she/he would have to be registered and provide the following details:

	- Name
	- Date of birth
	- Yoga experience 
	- Health issues
	- Contact details: telephone  and email

1. Then the client should be able to see all the yoga classes and/or workshops. The system should automatically check if there are any spaces left before making the reservation.The system should save in the DB who made the reservation and time stamp it.


1. A client should be able to cancel a reservation up to 24 hours prior to the class.

Thank you.
