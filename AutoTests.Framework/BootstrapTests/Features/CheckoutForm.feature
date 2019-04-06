Feature: CheckoutForm

Scenario: Billing address
	Given navigate to 'https://getbootstrap.com/docs/4.0/examples/checkout/'
	When set '#name' value in 'checkout form > first name'
		And set '#last name' value in 'checkout form > last name'
	Then value in 'checkout form > first name' should be equal '#name'
		And value in 'checkout form > last name' should be equal '#last name'