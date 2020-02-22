Feature: CheckoutForm

Scenario: checkout form validation test
	Given navigate to '@Data.HomePageUrl'
	When set value '#first_name' in 'Checkout form > First name'
		And set value '#last_name' in 'Checkout form > Last name'
		And click on 'Checkout form > Continue to checkout'
	Then 'Checkout form > First name' should contain '#first_name'
		And 'Checkout form > Last name' should contain '#last_name'