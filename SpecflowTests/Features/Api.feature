Feature: ApiTests
	In order to test the functionality
	As an Api user
	I want to be able to send requests
	And check the results

@API
Scenario: JSONPlaceholder can obtain an existing employee info
	Given a valid user id
	When the information of this user is requested
	Then the user data is returned

@API
Scenario: JSONPlaceholder cannot obtain info of an unexisting employee
	Given a non existing user id
	When the information of this user is requested
	Then no user data is returned

@API
Scenario: JSONPlaceholder returns an error with an incorrect request
	Given an incorrect user id
	When the information of this user is requested
	Then an error is returned
