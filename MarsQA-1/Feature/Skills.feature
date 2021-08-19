Feature: Skills
	User Should be able to Add, Update and Delete Skill Details

@mytag
Scenario: Add Skills 
	Given the User Clicks on skills Tab
	When the user Adds the New skills details and clicks on Add button
	Then the User should see the new skills in his profile


@mytag
Scenario: Update skills
    Given the user is on Skills Tab
	When the user Edits the existing skills details and click on update button
	Then the user should see updated skills in his profile

	@mytag
	Scenario: Delete skills
	Given the User at skills Tab
	When the user deletes the skills
	Then the User skills details should be deleted

	