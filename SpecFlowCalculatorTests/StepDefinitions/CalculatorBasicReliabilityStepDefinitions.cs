using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Intrinsics.X86;
using TechTalk.SpecFlow;
using NUnit.Framework;

//Use contexts to avoid test langar or smth
using SpecFlowCalculatorTests.Context;

using System.Diagnostics;
using TechTalk.SpecFlow.CommonModels;


namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    internal class CalculatorMusaStepDefinition
    {
        //For the context
        private readonly CalculatorContext _calculatorContext;
        public CalculatorMusaStepDefinition(CalculatorContext calculatorContext)
        {
            _calculatorContext = calculatorContext;
        }
        [When(@"I press (.*) and (.*) and (.*) into the calculator and press Current Failure Intensity")]
        public void CalculateCurrentFailureIntensity
            (double FailuresPerHour, double FailuresAlreadyOccurred, double FailuresInInfiniteTime)
        {
            _calculatorContext.Result = _calculatorContext.Calculator.CurrentFailureIntensity
                (FailuresPerHour, FailuresAlreadyOccurred, FailuresInInfiniteTime);
        }
        

        [When(@"I press (.*) and (.*) and (.*) into the calculator and press Average Number of Expected Failures")]
        public void CalculateAverageNumberOfExpectedFailures(double InitialFailureIntensity, double FailuresInInfiniteTime, double CPUHours)
        {
            _calculatorContext.Result = _calculatorContext.Calculator.AverageNumberOfExpectedFailures
                (InitialFailureIntensity, FailuresInInfiniteTime, CPUHours);
        }

        [Then(@"The Current failure intensity should be (.*)")]
        public void CurrentFailureIntensityResult(double result)
        {
            double tolerance = 0.01;
            Assert.That(_calculatorContext.Result, Is.EqualTo(result).Within(tolerance));
        }

        [Then(@"The Average Number of Expected Failures should be (.*)")]
        public void AverageNumberOfExpectedFailuresResult(double result)
        {
            //to catch within whole number
            double tolerance = 1;
            Assert.That(_calculatorContext.Result, Is.EqualTo(result).Within(tolerance));
        }


    }
}
