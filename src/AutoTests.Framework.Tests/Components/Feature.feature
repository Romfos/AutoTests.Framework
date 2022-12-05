Feature: Feature

Scenario: click component test
    When click on 'main page > login'
    Then check component test 1

Scenario: set value component test
    When set following values:
    | Name                   | Value        |
    | main page > first name | Hello World! |
    Then check component test 2

Scenario: get value component test
    Given prepare component test 3
    Then should have following values:
    | Name                   | Value |
    | main page > first name | 123   |
    Then check component test 3

Scenario: component data test
    Then check component data 4

Scenario: component selector data test
    Then check component data 5

Scenario: visible component test
    Then should be visible:
    | Name                   |
    | main page > first name |

Scenario: invisible component test
    Then should be invisible:
    | Name              |
    | main page > login |