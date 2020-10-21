Feature: File Operations
	In order to test a functionality
	As a product tester
	I want to be able to move files to a folder
	And check when they have been removed from that folder

@File_Moving
Scenario: Move a file to another folder
	Given I have a file with the name test.docx in the folder TestData
	And I copy it to the folder tempFolder
	When I move it to the folder destinationFolder
	Then the file is moved to the destination folder in less than 5 seconds

@File_Copying
Scenario: Copy a file to another folder
	Given I have a file with the name test.docx in the folder TestData
	When I copy it to the folder destinationFolder
	Then the file is copied to the destination folder in less than 5 seconds