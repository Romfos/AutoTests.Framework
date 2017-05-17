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

Scenario: compiler in transformations
	When save 'ABC' as 'Title'
	Then test model transformation:
	| Name    | Value    |
	| Title   | @[Title] |
	| Enabled | true     |
	| Value   | 123      |

Scenario: test vertical table
	When save 'ABC' as 'Title'
	Then test vertical table:
	| Title    | Enabled | Value |
	| @[Title] | true    | 123   |

Scenario: test store expressions
	When save next values:
	| Name         | Value                             |
	| first value  | @1                                |
	| second value | @[first value] + 5                |
	| last value   | @[second value]  -  [first value] |
	Then store 'last value' should contain '@5'