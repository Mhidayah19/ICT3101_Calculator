Feature: UsingCalculatorAvailability
In order to calculate MTBF and Availability
As someone who struggles with math
I want to be able to use my calculator to do this

    @Availability
    Scenario: Calculate MTBF
        Given I have a calculator
        When I enter 150 and 10 into the calculator and press MTBF
        Then the MTBF should be 160

    @Availability
    Scenario: Calculate Large MTBF
        Given I have a calculator
        When I enter 1200 and 15 into the calculator and press MTBF
        Then the MTBF should be 1215

    @Availability
    Scenario: Calculate availability
        Given I have a calculator
        When I enter 300 and 20 into the calculator and press availability
        Then the availability should be 93.75

    @Availability
    Scenario: Calculate Large availability
        Given I have a calculator
        When I enter 1500 and 25 into the calculator and press availability
        Then the availability should be 98.36