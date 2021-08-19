Feature: Languages
	User Should be able to Add, Update and Delete Language Details

@mytag
Scenario: Add Languages
	Given the User Clicks on Language Tab
	When the user Adds the New Language details and Clicks on Add button
	Then the User should see the new Language in his profile


	@mytag
Scenario: Update Languages
	Given the User Clicks on Language Tab
	When the user  Edits the Language details and click on update button
	Then the Language Details should be Updated and should be seen by User

	@mytag
Scenario: Delete Languages
	Given the User is on Language Tab
	When the user deletes the Language
	Then the User Language details should be deleted
