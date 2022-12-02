Feature: CheckoutForm

Scenario: checkout form validation test
    Given navigate to '@Data.Common.HomePageUrl'
    When set value '#first_name' in  'checkout > first name'
        And set value '#last_name' in  'checkout > last name'
        And click on 'checkout > continue to checkout'
    Then value '#first_name' should be in 'checkout > first name'
        And value '#last_name' should be in 'checkout > last name'