Feature: Components

Scenario: click component test
	When click on 'click test component'
	Then component 'click test component' should pass internal check

Scenario: set value in component test
	When set value '@100 + 23' in 'set value test component'
	Then component 'set value test component' should pass internal check

Scenario: equal to value test
	Then 'equal to test component' should contain '123'
	Then component 'equal to test component' should pass internal check

Scenario: not equal to value test
	Then 'not equal to test component' shouldn't contain '456'
	Then component 'not equal to test component' should pass internal check

Scenario: enabled component test
	Then 'enabled test component' should be enabled
	Then component 'enabled test component' should pass internal check

Scenario: disabled component test
	Then 'disabled test component' should be disabled
	Then component 'disabled test component' should pass internal check

Scenario: selected component test
	Then 'selected test component' should be selected
	Then component 'selected test component' should pass internal check

Scenario: not selected component test
	Then 'not selected test component' shouldn't be selected
	Then component 'not selected test component' should pass internal check

Scenario: visible component test
	Then 'visible test component' should be visible
	Then component 'visible test component' should pass internal check

Scenario: invisible component test
	Then 'invisible test component' should be invisible
	Then component 'invisible test component' should pass internal check

Scenario: match with test
	Then 'match with test component' should contain following values:
	| Name | Value |
	| AA   | 123   |
	| BB   | @456  | 
	Then component 'match with test component' should pass internal check

Scenario: mismatch test
	Then 'mismatch test component' shouldn't contain following values:
	| Name | Value |
	| AA   | 123   |
	| BB   | @456  |
	Then component 'mismatch test component' should pass internal check