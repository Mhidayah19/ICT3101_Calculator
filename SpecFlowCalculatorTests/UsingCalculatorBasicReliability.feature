Feature: UsingCalculatorBasicReliability

    In order to calculate the Basic Musa model's failures/intensities
    As a Software Quality Metric enthusiast
    I want to use my calculator to do this


    @MusaModel
    Scenario: Calculate Current failure intensity
        Given I have a calculator
        When I press 12 and 24 and 48 into the calculator and press Current Failure Intensity
        Then The Current failure intensity should be 6

    @MusaModel
    Scenario: Calculate Average Number of Expected failures
        Given I have a calculator
        When I press 4 and 100 and 20 into the calculator and press Average Number of Expected Failures
        Then The Average Number of Expected Failures should be 55