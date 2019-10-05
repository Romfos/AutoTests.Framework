Feature: CheckoutForm

Scenario: checkout form validation test
	Given navigate to 'https://getbootstrap.com/docs/4.3/examples/checkout/'
	When set value '#first_name' in 'Checkout form > First name' component
		And set value '#last_name' in 'Checkout form > Last name' component
		And click on 'Checkout form > Continue to checkout' component
	Then component 'Checkout form > First name' should contain '#first_name'
		And component 'Checkout form > Last name' should contain '#last_name'