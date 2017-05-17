Feature: Playground

Scenario: Model transformation test
	Then test model transformation:
	| Name    | Value |
	| Title   | ABC   |
	| Enabled | true  |
	| Value   | 123   |

Scenario: Compiler test
	Then test compiler '@1 + 2' equal '@3'

Scenario: Store test
	When save '@1 + 2' as 'key name'
	Then store 'key name' should contain '@3'

Scenario: Store link test
	When save '@1 + 2' as 'key name'
	Then store 'key name' should contain '@[key name]'