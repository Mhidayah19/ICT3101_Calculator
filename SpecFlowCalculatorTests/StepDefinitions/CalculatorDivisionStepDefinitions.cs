using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

using TechTalk.SpecFlow;
using NUnit.Framework;

using NUnit.Framework;
using SpecFlowCalculatorTests.Context;

namespace SpecFlowCalculatorTests.StepDefinitions
{



    [Binding]
    public class CalculatorDivisionStepDefinitions
    {
        // private Calculator _calculator;
        // private double _result;
        
        private readonly CalculatorContext _calculatorContext;

        public CalculatorDivisionStepDefinitions(CalculatorContext calculatorContext)
        {
            _calculatorContext = calculatorContext;
        }

        // [Given(@"I have a calculator")]
        // public void GivenIHaveACalculator()
        // {
        //     _calculatorContext.Calculator = new Calculator();
        // }

        [When(@"I have entered (.*) and (.*) into the calculator and press divide")] 
        public void WhenIHaveEnteredAndIntoTheCalculator(double p0, double p1)
        {
            _calculatorContext.Result = _calculatorContext.Calculator.Divide(p0, p1);
        }

        [Then(@"the division result should be (.*)")]
        public void ThenTheResultShouldBeOnTheScreen(double expectedResult)
        {
            Assert.That(_calculatorContext.Result, Is.EqualTo(expectedResult));
        }

        
        //Because diff wording, use another "Then" to assert
        [Then(@"the division result equals (.*)")]
        public void TheDivisionResultShouldBeSpecialValue(string specialValue)
        {
            switch (specialValue)
            {
                case "positive_infinity":
                    Assert.That(_calculatorContext.Result, Is.EqualTo(double.PositiveInfinity));
                    break;
                default:
                    throw new ArgumentException($"Unexpected special value: {specialValue}");
            }
        }
    }
}