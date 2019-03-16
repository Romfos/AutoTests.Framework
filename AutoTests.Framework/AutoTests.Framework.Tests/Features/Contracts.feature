Feature: Contracts

Scenario: set value contract
	When set '@1 + 2' value in 'contract page 1 > element 1'
	Then value for contract element 1 should be '3'	

Scenario: get value contract
	When set '@1 + 2' value in 'contract page 1 > element 1'
	Then value in 'contract page 1 > element 1' should be equal '3'

Scenario: enabled contract
	Then 'contract page 1 > element 1' should be enabled

Scenario: visible contract
	Then 'contract page 1 > element 1' should be visible

Scenario: selected contract
	Then 'contract page 1 > element 1' should be selected

Scenario: click contract
	When click on 'contract page 1 > element 1'
	Then value for contract element 1 should be 'Click works'	