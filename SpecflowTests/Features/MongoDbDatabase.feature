Feature: MongoDbDatabase
	In order to read and write data in a mongo db database
	As a mongo db user
	I want to be be able to execute queries and make inserts in a mongodb database

@MongoDb [Retry(Times = 3, RequiredPassCount = 2)]
Scenario: Add a new element to the collection
	Given I have a non existing client
	When I add the data of this client to the database
	Then this client should be found in the database

@MongoDb
Scenario: Get an existing element from the collection
	Given I have an existing client
	When I get the data of this client
	Then this client should be found in the database

@MongoDb
Scenario: Get a non existing element from the collection
	Given I have a non existing client
	When I get the data of this client
	Then  this client should not be found in the database

@MongoDb
Scenario: Remove an existing element from the collection
	Given I have added a non existing client
	When I remove this client
	Then this client should not be found in the database

@MongoDb
Scenario: Update an existing element from the collection
	Given I have an existing client
	When I modify the value of the last name to be "lastNamenew"
	Then this client should be found in the database