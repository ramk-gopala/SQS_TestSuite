Feature: CreateAccount
	As an User, I will be able to create New Account 

@regression
Scenario: Create a new account
	Given I am on Home page 
	And I am not logged in
	When I click Sign Up
	And I complete the sign up form
		| UserName   | Email                | Password    |
		| oneTest001 | oneTest001@gmail.com | password123 |
	Then I am logged in
	And my username is displayed

####################################################################################################
#
# Below additional BDD scenarios are added for best test coverage for the given requirement. 
# Step Definitions, POMs are NOT created due to time limitations
#
####################################################################################################

#Scenario: Account should not be created for already existing account
#	Given I am on Home page
#	And I am not logged in
#	When I click Sign Up
#	Then I should be in Sign Up page 
#	When I enter already existing account details to Register account
#		| UserName | Email              | Password    |
#		| test2992 | test2992@gmail.com | password123 |
#	Then I should not be allowed to create Account
#	And I should see error messages "username has already been taken" and "email has already been taken"
#
#Scenario Outline:  Account should not be created with invalid username, emailID and password
#	Given I am on Home page
#	And I am not logged in
#	When I click Sign Up
#	Then I should be in Sign Up page 
#	When I enter invalid <username> <email> and <password> to Register
#	Then I should see an <errormessage> error and Account will not be created
#
#	Examples: 
#		| username | email             | password    | errormessage                                    |
#		| test90   | test90@gmail.com  | pas         | password is too short (minimum is 8 characters) |
#		|          | test90@gmail.com  | password123 | username can't be blank                         |
#		| test90   |                   | password321 | email can't be blank                            |
#		| t        | test100@gmail.com |             | username is too short (minimum is 1 character)  |


# Scenario: Account should not be created when given username has underscore in it
#	Given I am on Home page
#	And I am not logged in
#	When I click Sign Up
#	Then I should be in Sign Up page 
#	When I enter  account registration details with undersscore in username
#		| UserName   | Email                | Password    |
#		| test_test1 | test_test1@gmail.com | password123 |
#	Then I should see an "Please input username without underscore" error and Account will not be created


