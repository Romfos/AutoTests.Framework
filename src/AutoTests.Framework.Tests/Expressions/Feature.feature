Feature: Expressions

Scenario: Simple no context match expression test
    Then expression test step 1 '@1+2'

Scenario: Simple string expression test
    Then expression test step 2 '1+2'

Scenario: Test data expression test
    Then expression test step 3 '@Data.TestData.String'