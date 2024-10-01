namespace ICT3101_Calculator.UnitTests;

using Moq;
using NUnit.Framework;
using System;
using System.IO;

[TestFixture]
public class AdditionalCalculatorTests
{
    private Calculator _calculator;
    private Mock<IFileReader> _mockFileReader;

    [SetUp]
    public void Setup()
    {
        _mockFileReader = new Mock<IFileReader>();
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"..", "..", "..","..", "ICT3101_Calculator/MagicNumbers.txt");
        _mockFileReader.Setup(fr => fr.Read(filePath))
            .Returns(new string[] { "42", "42", "Invalid" }); // Mocked return values
        _calculator = new Calculator();
        
    }

    [Test]
        public void GenMagicNum_ValidIndex_ReturnsCorrectMagicNumber()
        {
            // Arrange: Mock valid magic numbers
            //_mockFileReader.Setup(fr => fr.Read("MagicNumbers.txt")).Returns(new string[] { "10", "20", "30", "40", "50" });

            // Act
            double result = _calculator.GenMagicNum(1, _mockFileReader.Object); // Should return 30 * 2 = 60

            // Assert
            Assert.AreEqual(84, result);
        }

        [Test]
        public void GenMagicNum_IndexOutOfRange_ReturnsNegativeMagicNumber()
        {

            // Act
            double result = _calculator.GenMagicNum(10, _mockFileReader.Object); // Index out of range

            // Assert
            Assert.AreEqual(-20, result); // Expected value for out-of-range input
        }

        [Test]
        public void GenMagicNum_InvalidIndex_ReturnsNegativeMagicNumber()
        {

            // Act
            double result = _calculator.GenMagicNum(-1, _mockFileReader.Object); // Invalid index

            // Assert
            Assert.AreEqual(-20, result); // Expected value for negative index
        }

        [Test]
        public void GenMagicNum_FileNotFound_ThrowsException()
        {
            // Arrange: Mock the IFileReader to throw FileNotFoundException
            _mockFileReader.Setup(fr => fr.Read(It.IsAny<string>())).Throws<FileNotFoundException>();

            // Act and Assert
            Assert.Throws<FileNotFoundException>(() => _calculator.GenMagicNum(2, _mockFileReader.Object));
        }

        [Test]
        public void GenMagicNum_FileHasInvalidContent_ThrowsFormatException()
        {

            // Act and Assert
            Assert.Throws<FormatException>(() => _calculator.GenMagicNum(2, _mockFileReader.Object));
        }
    
    
}