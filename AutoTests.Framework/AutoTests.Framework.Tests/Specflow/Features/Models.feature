Feature: Models

Scenario: single model transformation
	Then check single model transformation:
	 | Name   | Value |
	 | Value1 | 1     |
	 | Value2 | @1+2  |


Scenario: list of models transformation
	Then check list of model transformation:
	 | Value1 | Value2 |
	 | 1      | @1+2   |
	 | 3      | 4      |
