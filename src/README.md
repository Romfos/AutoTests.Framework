# Overview

Reqnroll based autotest framework

Main features:
- C# expression support inside features
- Test data management framework
- Model transformation framework
- Component framework for UI testing

# Test example
```gherkin
Feature: CheckoutForm

Scenario: checkout form validation test
    Given navigate to '@Data.Common.HomePageUrl'
    When set following values:
    | Name                  | Value      |
    | checkout > first name | first_name |
    | checkout > last name  | last_name  |
    And click on 'checkout > continue to checkout'
    Then should be visible:
    | Name                              |
    | checkout > username error message |
    And should have following values:
    | Name                              | Value                      |
    | checkout > username error message | Your username is required. |
```

More info: https://github.com/Romfos/AutoTests.Framework
