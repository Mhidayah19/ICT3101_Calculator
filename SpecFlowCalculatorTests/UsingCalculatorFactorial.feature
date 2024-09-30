Feature: UsingCalculatorFactorial

	In order to attempt factorials
	As a factorial fanatic
	I want to understand more about factorials

	@Factorials
	Scenario: Factorial of 0
		Given I have a calculator
		When I have entered 0 into the calculator and press equals
		Then the factorial should be 1

	@Factorials
	Scenario: Factorial of 4
		Given I have a calculator
		When I have entered 4 into the calculator and press equals
		Then the factorial should be 24