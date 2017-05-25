Feature: Playground

Scenario: Example1
	Given save 'User1' as 'Username'
		And save 'Pass1' as 'Password'
	When navigate to 'https://semantic-ui.com/examples/login.html'
		And login as
		| Name     | Value       |
		| Username | @[Username] |
		| Password | @[Password] |