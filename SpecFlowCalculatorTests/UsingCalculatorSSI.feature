Feature: UsingCalculatorSSI
In order to calculate the shipped source code KLOC
As a Software Quality Metric enthusiast
I want to use my calculator to perform these calculations 

	@SSI
	Scenario: Calculate total KLOC for 30%
		Given I have a calculator
		When I enter 60 and 25 and 30 and I press SSI
		Then I should get 77.5 as the total KLOC
		
	@SSI
	Scenario: Calculate total KLOC for 0.3
		Given I have a calculator
		When I enter 60 and 25 and 0.3 and I press SSI
		Then I should get 77.5 as the total KLOC