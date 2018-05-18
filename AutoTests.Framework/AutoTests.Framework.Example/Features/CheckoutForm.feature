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

Scenario: Your cart item test
	Given navigate to '@Credentials.HomePage'
	Then following values should be present in Your cart list on Checkout form page:
	| Name  | Value          |
	| Title | Second product |
	| Price | $8             |

Scenario: Billing address form validation test
	Given navigate to '@Credentials.HomePage'
	When click Continue to checkout button on Checkout form page
	Then following validation messages should be present in Billing address from on Checkout form page:
	| Name       | Attributes                                          |
	| First name | @ValidationMessage('Valid first name is required.') |
	| Last name  | @ValidationMessage('Valid last name is required.')  |