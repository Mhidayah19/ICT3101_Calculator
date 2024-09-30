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

namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public class CalculatorFactorialStepDefinitions
    {
        //For the context
        private readonly CalculatorContext _calculatorContext;
        public CalculatorFactorialStepDefinitions(CalculatorContext calculatorContext)
        {
            _calculatorContext = calculatorContext;
        }

        [When(@"I have entered (.*) into the calculator and press equals")]
        public void whenIDoAFactorial(int num1)
        {
            _calculatorContext.Result = _calculatorContext.Calculator.Factorial(num1);
        }

        [Then(@"the factorial should be (.*)")]
        public void factorialResultShouldBeEqualTo(int result)
        {
            Assert.That(_calculatorContext.Result, Is.EqualTo(result));
        }

    }//step def
}//namespace