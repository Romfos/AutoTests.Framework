Feature: CheckoutForm

Scenario: checkout form validation test
    Given navigate to '@Data.Common.HomePageUrl'
    When set value '#first_name' in 'checkout > first name' field
        And set value '#last_name' in 'checkout > last name' field
        And click on 'checkout > continue to checkout'
    Then field 'checkout > first name' should have '#first_name' value
        And field 'checkout > last name' should have '#last_name' value