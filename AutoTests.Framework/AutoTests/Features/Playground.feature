Feature: Playground

Scenario: Example1
	Given save 'User1' as 'Username'
		And save 'Pass1' as 'Password'
	When navigate to 'https://semantic-ui.com/examples/login.html'
		And login as
		| Name     | Value       |
		| Username | @[Username] |
		| Password | @[Password] |

Scenario: Example2
	Given save next values in store:
	| Name  | Value           |
	| date  | @CurrentDate    |
	| date2 | @[date] + 1 day |
	Then in store 'date2' should contain '@CurrentDate + 10 days - 9 day'

Scenario: Example3
	When navigate to 'https://semantic-ui.com/examples/login.html'
		And login as
		| Name     | Value                 |
		| Username | @Credentials.Username |
		| Password | @Credentials.Password |