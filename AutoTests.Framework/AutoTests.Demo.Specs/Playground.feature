Feature: Playground

Scenario: Model transformation test
	Then test model transformation:
	| Name    | Value |
	| Title   | ABC   |
	| Enabled | true  |
	| Value   | 123   |

Scenario: Compiler test
	Then test compiler '@1 + 2' equal '@3'