using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

using TechTalk.SpecFlow;
using NUnit.Framework;

using SpecFlowCalculatorTests.Context;

namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public class CalculatorSSIStepDefinitions
    {
        //For the context
        private readonly CalculatorContext _calculatorContext;
        public CalculatorSSIStepDefinitions(CalculatorContext calculatorContext)
        {
            _calculatorContext = calculatorContext;
        }

        [When(@"I enter (.*) and (.*) and (.*) and I press SSI")]
        public void CalculateSSI(double InitialLOC, double ChangedLOC, double ChangedPercent)
        {
            _calculatorContext.Result = _calculatorContext.Calculator.ShippedSourceCode
                (InitialLOC, ChangedLOC, ChangedPercent);
        }

        [Then(@"I should get (.*) as the total KLOC")]
        public void AssertSSI(double result)
        {
            double tolerance = 0.1;
            Assert.That(_calculatorContext.Result, Is.EqualTo(result).Within(tolerance));
        }

    }
}