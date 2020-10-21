Feature: WebElementsChecks
	In order to avoid silly mistakes
	As a teser
	I want to be able to check webelements properties

@WebElementsChecks, @WebDriver
Scenario: Check Color of Webelement
	When I navigate to the page WebElementsColor
	Then The color of the element element should be BLUE
	
@WebElementsChecks, @WebDriver
Scenario: Check the element line number
	When I navigate to the page ElementsHeightUrl
	Then The element has '3' lines