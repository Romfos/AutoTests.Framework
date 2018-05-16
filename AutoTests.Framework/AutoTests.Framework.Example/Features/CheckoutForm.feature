Feature: CheckoutForm

Scenario: Billing address form test
	Given navigate to 'https://getbootstrap.com/docs/4.0/examples/checkout/'
	When set following valus in Billing address from on Checkout form page:
	| Name       | Value  |
	| First name | Abcd   |
	| Last name  | Qwerty |
	Then following values should be present in Billing address from on Checkout form page:
	| Name       | Value  |
	| First name | Abcd   |
	| Last name  | Qwerty |