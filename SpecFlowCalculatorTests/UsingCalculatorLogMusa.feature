Feature: UsingCalculatorLogMusa
In order to calculate failure metrics
As a Software Quality Metric enthusiast
I want to use my calculator to generate the current failure intensity using the Musa Logarithmic model

	@LogarithmicMusa
	Scenario: Calculate current failure intensity for 5
		Given I have a calculator
		When I enter 80, 0.04, 5 and press Calculate Current Failure Intensity
		Then I should get 65.5 as the current failure intensity
	
	@LogarithmicMusa
	Scenario: Calculate current failure intensity for 4
		Given I have a calculator
		When I enter 100, 0.05, 2 and press Calculate Current Failure Intensity
		Then I should get 90.48 as the current failure intensity