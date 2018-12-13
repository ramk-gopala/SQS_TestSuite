####################################################################################################
#
# Created additional BDD scenarios for best test coverage for the given requirement. 
# Only feature file created. Step Definitions, POMs are NOT created due to time restriction
#
####################################################################################################

#Feature: Login
#	As an User, I should be able to login to the website
#
# @smoke @regression
#Scenario: Login to the website
#	Given I am on Home page 
#	And I am not logged in
#	When I click SignIn 
#	And I enter Email and password and click Login
#		| Email              | Password  | UserName |
#		| test2992@gmail.com | password1 | test2992 |
#	Then I am logged in
#	And my username is displayed
