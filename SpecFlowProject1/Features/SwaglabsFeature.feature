Feature: SwaglabsFeature

Swag labs Features test, writen tests in a natural language format.

@Swaglabs
Scenario: Swag Labs login
	Given open the browser
	And enter the url
	And enter the user name
	And enter user password
	When click login button
	Then login succeed and go to inventory page