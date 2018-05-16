Feature: CheckoutForm

Scenario: Billing address form test
	Given navigate to '@Credentials.HomePage'
	When set following valus in Billing address from on Checkout form page:
	| Name       | Value  |
	| First name | Abcd   |
	| Last name  | Qwerty |
	Then following values should be present in Billing address from on Checkout form page:
	| Name       | Value  |
	| First name | Abcd   |
	| Last name  | Qwerty |