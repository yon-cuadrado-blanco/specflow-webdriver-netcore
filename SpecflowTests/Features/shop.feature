Feature: shop


@WebDriver
Scenario: Search for dress
	Given I navigate to the page shopUrl
	When When I type the text 'dress'
	Then The application shows the text 'SEARCH  DRESS'