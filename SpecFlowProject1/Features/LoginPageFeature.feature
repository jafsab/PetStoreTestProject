Feature: LoginPageFeature

Login page feature tests as page object model patern.

@LoginPageFeature
Scenario: Sucessful Login steps
	When I enter username 'standard_user' and password 'secret_sauce'
	Then open inventory page

Scenario: Failed Login steps
	When I enter username 'standard_user' and password 'xxxx'
	Then an error message should be displayed