Feature: CheckoutForm

Scenario: checkout form validation test
    Given navigate to '@Data.Common.HomePageUrl'
    When set following values:
    | Name                  | Value      |
    | checkout > first name | first_name |
    | checkout > last name  | last_name  |
    And click on 'checkout > continue to checkout'
    Then should have following values:
    | Name                              | Value                      |
    | checkout > username error message | Your username is required. |
