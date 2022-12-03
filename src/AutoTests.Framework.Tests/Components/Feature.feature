Feature: Feature

Scenario: click component test
    When click on 'main page > login'
    Then check component test 1

Scenario: set value component test
    When set value 'Hello World!' in 'main page > first name' field
    Then check component test 2

Scenario: get value component test
    Given prepare component test 3
    Then field 'main page > first name' should have '123' value
    Then check component test 3

Scenario: component data test
    Then check component data 4

Scenario: component selector data test
    Then check component data 5