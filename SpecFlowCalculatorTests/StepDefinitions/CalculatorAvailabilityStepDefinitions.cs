using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Intrinsics.X86;
using TechTalk.SpecFlow;
using NUnit.Framework;

using SpecFlowCalculatorTests.Context;

namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public class CalculatorAvailabilityStepDefinition
    {

        //For the context
        private readonly CalculatorContext _calculatorContext;
        public CalculatorAvailabilityStepDefinition(CalculatorContext calculatorContext)
        {
            _calculatorContext = calculatorContext;
        }

        [When(@"I enter (.*) and (.*) into the calculator and press MTBF")]
        public void whenIinvokeMTBF(double MTTF, double MTTR)
        {
            _calculatorContext.Result = _calculatorContext.Calculator.MeanTimeToFailure(MTTF, MTTR);
        }

        [When(@"I enter (.*) and (.*) into the calculator and press availability")]
        public void whenIinvokeAvailability(double MTTF, double MTTR)
        {
            _calculatorContext.Result = _calculatorContext.Calculator.Availability(MTTF, MTTR);
        }


        [Then(@"the MTBF should be (.*)")]
        public void MTBFResult(double result)
        {
            Assert.That(_calculatorContext.Result, Is.EqualTo(result));
        }

        [Then(@"the availability should be (.*)")]
        public void AvailabilityResult(double result)
        {
            //to allow the test to pass within the range
            double tolerance = 0.01;

            Assert.That(_calculatorContext.Result, Is.EqualTo(result).Within(tolerance));
        }

    }
}