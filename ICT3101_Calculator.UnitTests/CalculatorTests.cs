namespace ICT3101_Calculator.UnitTests;


public class CalculatorTests
{
    private Calculator _calculator;

    [SetUp]
    public void Setup()
    {
        // Arrange
        _calculator = new Calculator();
    }

    [Test]
    public void Add_WhenAddingTwoNumbers_ResultEqualToSum()
    {
        // Act
        double result = _calculator.Add(10, 20);
        // Assert
        Assert.That(result, Is.EqualTo(30));
    }


    [Test]
    public void Subtract_WhenSubtractingTwoNumbers_ReturnsCorrectDifference()
    {
        double result = _calculator.Subtract(10, 7);
        Assert.AreEqual(3, result);
    }

    [Test]
    public void Subtract_WhenSubtractingSameNumbers_ReturnsZero()
    {
        double result = _calculator.Subtract(5, 5);
        Assert.AreEqual(0, result);
    }

    [Test]
    public void Subtract_WhenSubtractingNegativeNumbers_ReturnsCorrectDifference()
    {
        double result = _calculator.Subtract(-5, -10);
        Assert.AreEqual(5, result);
    }


    [Test]
    public void Multiply_WhenMultiplyingTwoNumbers_ReturnsCorrectProduct()
    {
        double result = _calculator.Multiply(4, 2);
        Assert.AreEqual(8, result);
    }

    [Test]
    public void Multiply_WhenMultiplyingByZero_ReturnsZero()
    {
        double result = _calculator.Multiply(5, 0);
        Assert.AreEqual(0, result);
    }

    [Test]
    public void Multiply_WhenMultiplyingByOne_ReturnsSameNumber()
    {
        double result = _calculator.Multiply(5, 1);
        Assert.AreEqual(5, result);
    }


    [Test]
    public void Divide_WhenDividingTwoNumbers_ReturnsCorrectQuotient()
    {
        double result = _calculator.Divide(10, 2);
        Assert.AreEqual(5, result);
    }

    [Test]
    public void Divide_WhenDividingBySelf_ReturnsOne()
    {
        double result = _calculator.Divide(5, 5);
        Assert.AreEqual(1, result);
    }
    


    [Test]
    //[TestCase(0, 0)]
    //[TestCase(0, 10)]
    [TestCase(10, 0)]
    public void Divide_WithZerosAsInputs_ResultThrowArgumentException(double a, double b)
    {

        Assert.That(() => _calculator.Divide (a, b),Throws.ArgumentException);
    }
    
    [Test]
    [TestCase(10, 0)] // Denominator is zero, should throw ArgumentException
    //[TestCase(0, 0)]  // Both numerator and denominator are zero, should throw ArgumentException
    public void Divide_WithInvalidInputs_ShouldThrowArgumentException(double a, double b)
    {
        // Act & Assert
        Assert.That(() => _calculator.Divide(a, b), Throws.ArgumentException);
    }


    [Test]
    [TestCase(0, 10, ExpectedResult = 0)]  // Numerator is zero, should return 0
    [TestCase(20, 10, ExpectedResult = 2)] // Normal division, should return 2
    public double Divide_WithValidInputs_ShouldReturnExpectedResult(double a, double b)
    {
        return _calculator.Divide(a, b);
    }

    [Test]
    [TestCase(0, 1)]    // 0! = 1
    [TestCase(1, 1)]    // 1! = 1
    [TestCase(2, 2)]    // 2! = 2
    [TestCase(3, 6)]    // 3! = 6
    [TestCase(4, 24)]   // 4! = 24
    [TestCase(5, 120)]  // 5! = 120
    [TestCase(10, 3628800)] // 10! = 3628800
    public void Factorial_WithVariousInputs_ReturnsCorrectFactorial(int a, double expected)
    {
        double result = _calculator.Factorial(a);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Factorial_NegativeNumber_ThrowsArgumentException()
    {
        
        Assert.That(() => _calculator.Factorial(-1),Throws.ArgumentException);
    }

    [Test]
    [TestCase(10, 5, ExpectedResult = 25)]
    [TestCase(6, 3, ExpectedResult = 9)]
    [TestCase(0, 10, ExpectedResult = 0)]
    public double AreaOfTriangle_WhenCalculatingArea_ResultEqualToArea(double height, double baseLength)
    {
        // Act
        double result = _calculator.AreaOfTriangle(height, baseLength);
        // Assert 
        return result;
    }

    [Test]
    [TestCase(5, ExpectedResult = Math.PI * 25)]
    [TestCase(10, ExpectedResult = Math.PI * 100)]
    [TestCase(2.5, ExpectedResult = Math.PI * 6.25)]
    [TestCase(0, ExpectedResult = 0)]
    public double AreaOfCircle_WhenCalculatingArea_ResultEqualToArea(double radius)
    {
        //Act
        double result = _calculator.AreaOfCircle(radius);
        return result;
    }

    //Unknown A
    [Test]
    public void UnknownFunctionA_WhenGivenTest0_Result()
    {
        // Act
        double result = _calculator.UnknownFunctionA(5, 5);
        // Assert
        Assert.That(result, Is.EqualTo(120));
    }
    [Test]
    public void UnknownFunctionA_WhenGivenTest1_Result()
    {
        // Act
        double result = _calculator.UnknownFunctionA(5, 4);
        // Assert
        Assert.That(result, Is.EqualTo(120));
    }
    [Test]
    public void UnknownFunctionA_WhenGivenTest2_Result()
    {
        // Act
        double result = _calculator.UnknownFunctionA(5, 3);
        // Assert
        Assert.That(result, Is.EqualTo(60));
    }
    [Test]
    public void UnknownFunctionA_WhenGivenTest3_ResultThrowArgumnetException()
    {
        // Act
        // Assert
        Assert.That(() => _calculator.UnknownFunctionA(-4, 5), Throws.ArgumentException);
    }
    [Test]
    public void UnknownFunctionA_WhenGivenTest4_ResultThrowArgumnetException()
    {
        // Act
        // Assert
        Assert.That(() => _calculator.UnknownFunctionA(4, 5), Throws.ArgumentException);
    }

    //Unknown B
    [Test]
    public void UnknownFunctionB_WhenGivenTest0_Result()
    {
        // Act
        double result = _calculator.UnknownFunctionB(5, 5);
        // Assert
        Assert.That(result, Is.EqualTo(1));
    }
    [Test]
    public void UnknownFunctionB_WhenGivenTest1_Result()
    {
        // Act
        double result = _calculator.UnknownFunctionB(5, 4);
        // Assert
        Assert.That(result, Is.EqualTo(5));
    }
    [Test]
    public void UnknownFunctionB_WhenGivenTest2_Result()
    {
        // Act
        double result = _calculator.UnknownFunctionB(5, 3);
        // Assert
        Assert.That(result, Is.EqualTo(10));
    }
    [Test]
    public void UnknownFunctionB_WhenGivenTest3_ResultThrowArgumnetException()
    {
        // Act
        // Assert
        Assert.That(() => _calculator.UnknownFunctionB(-4, 5), Throws.ArgumentException);
    }
    [Test]
    public void UnknownFunctionB_WhenGivenTest4_ResultThrowArgumnetException()
    {
        // Act
        // Assert
        Assert.That(() => _calculator.UnknownFunctionB(4, 5), Throws.ArgumentException);
    }
    
    

}