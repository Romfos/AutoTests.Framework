#test2
Feature: Playground
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
#test
Scenario Outline: scenario1
	Given test
	| Name2 | Value3 |
	| aaa   | bbb    |
	| 123   | 456    |
	Given test
	| Name | Value |
	| aaa  | bbb   |
	| 123  | 456   |

	Examples: 
	| c1 | c2  |
	| AA | ZZZ |
	| BB | GGG |
	
@mytag2
#test3
Scenario: scenario2
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen
