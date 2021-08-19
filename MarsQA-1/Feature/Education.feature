Feature: Education
User Should be able to Add, Update and Delete Education Details
	

@mytag
Scenario: Add Education
	Given the user is on Educationtab
	Given the user click on Addnew button
	When the User add education details
	Then the user can able to see message "Education has been added"

	@mytag
	Scenario: Edit Education
	Given the user is on Education tab
	When the User Update education details
	Then the user is able to see message "Education as been updated"

	@mytag
	Scenario: Delete Education
	Given the user click on EducationTab
	When  the user Delete the Education record
	Then the user get message as "Education entry successfully removed"

