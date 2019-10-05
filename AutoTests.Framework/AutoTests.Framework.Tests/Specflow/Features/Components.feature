Feature: Components

Scenario: click component test
	When click on 'click test component' component
	Then component 'click test component' should pass internal check

Scenario: set value in component test
	When set value '@100 + 23' in 'set value test component' component
	Then component 'set value test component' should pass internal check

Scenario: equal to value test
	Then component 'equal to test component' should contain '123'
	Then component 'equal to test component' should pass internal check

Scenario: enabled component test
	Then component 'enabled test component' should be enabled
	Then component 'enabled test component' should pass internal check

Scenario: disabled component test
	Then component 'disabled test component' should be disabled
	Then component 'disabled test component' should pass internal check

Scenario: selected component test
	Then component 'selected test component' should be selected
	Then component 'selected test component' should pass internal check

Scenario: not selected component test
	Then component 'not selected test component' shouldn't be selected
	Then component 'not selected test component' should pass internal check

Scenario: visible component test
	Then component 'visible test component' should be visible
	Then component 'visible test component' should pass internal check

Scenario: invisible component test
	Then component 'invisible test component' should be invisible
	Then component 'invisible test component' should pass internal check