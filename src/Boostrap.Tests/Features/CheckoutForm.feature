Feature: CheckoutForm

Scenario: checkout form validation test
    Given navigate to '@Data.Common.HomePageUrl'
    
    When set following values to fields:
    | Name                  | Value      |
    | checkout > first name | first_name |
    | checkout > last name  | last_name  |
    And click on 'checkout > continue to checkout'
    
    Then fields should have following values:
    | Name                  | Value      |
    | checkout > first name | first_name |
    | checkout > last name  | last_name  |