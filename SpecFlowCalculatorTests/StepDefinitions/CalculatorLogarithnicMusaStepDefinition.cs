using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;

using SpecFlowCalculatorTests.Context;

namespace SpecFlowCalculatorTests.StepDefinitions;

[Binding]
public class CalculatorLogarithnicMusaStepDefinition
{
    //For the context
    private readonly CalculatorContext _calculatorContext;
    public CalculatorLogarithnicMusaStepDefinition(CalculatorContext calculatorContext)
    {
        _calculatorContext = calculatorContext;
    }
    
    [When(@"I enter (.*), (.*), (.*) and press Calculate Current Failure Intensity")]
    public void CalculateLogMusa(double initialFailureIntensity, double failureRate, double failuresAlreadyOccurred)
    {
        _calculatorContext.Result =
            _calculatorContext.Calculator.LogarithmicCurrentFailureIntensity(initialFailureIntensity, failureRate,
                failuresAlreadyOccurred);
    }

    [Then(@"I should get (.*) as the current failure intensity")]
    public void AssertLogMusa(double result)
    {
        
        Assert.That(_calculatorContext.Result, Is.EqualTo(result));
    }


}