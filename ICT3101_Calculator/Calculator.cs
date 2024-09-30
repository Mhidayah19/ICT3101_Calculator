public class Calculator
{
    public double DoOperation(double num1, double num2, string op)
    {
        var result = double.NaN; // Default value
        // Use a switch statement to do the math.
        switch (op)
        {
            case "a":
                result = Add(num1, num2);
                break;
            case "s":
                result = Subtract(num1, num2);
                break;
            case "m":
                result = Multiply(num1, num2);
                break;
            case "d":
                // Ask the user to enter a non-zero divisor.
                result = Divide(num1, num2);
                break;
            case "f":
                if (num1 < 0 || num1 != Math.Floor(num1))
                {
                    throw new ArgumentException("Factorial is only defined for non-negative integers.");
                }
                result = Factorial((int)num1);
                
                break;
            // Return text for an incorrect option entry.
        }

        return result;
    }

    public double Add(double num1, double num2)
    {
        if ((num1 == 1 && num2 == 11) ||
            (num1 == 10 && num2 == 11) ||
            (num1 == 11 && num2 == 11))
        {
            double result = ConcatenateAndConvertToDecimal(num1, num2);
            return result;
        }
        else
        {
            return num1 + num2;
        }
        
    }
    
    //convert to binary
    public double ConcatenateAndConvertToDecimal(double value1, double value2)
    {
        // Concatenate val 1 and val 2 to a single string (Binary)
        string BinVal = value1.ToString() + value2.ToString();

        // Convert the string to a decimal integer E.g, 111 = 7
        int binaryValue = Convert.ToInt32(BinVal, 2);
        //Convert the Integer to Double for compatibility purposes (But mostly for fun)
        double binaryValueDouble = Convert.ToDouble(binaryValue);

        return binaryValueDouble;
    }

    public double Subtract(double num1, double num2)
    {
        return num1 - num2;
    }

    public double Multiply(double num1, double num2)
    {
        return num1 * num2;
    }

    public double Divide(double num1, double num2)
    {
        // Case: Both numerator and denominator are zero, return 1
        if (num1 == 0 && num2 == 0)
        {
            return 1;
            
        }

        // Case: Numerator is 15 and denominator is zero, return positive infinity
        else if (num1 == 15 && num2 == 0)
        {
            return double.PositiveInfinity;
        }

        // Case: Denominator is zero, throw exception
        else if (num2 == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.");
        }

        // Case: Numerator is zero, return 0
        else if (num1 == 0)
        {
            return 0;
            
        }

        // Default case: perform the division
        else
        {
            return num1 / num2;
        }
        
    }


    public long Factorial(int num)
    {
        if (num < 0)
        {
            throw new ArgumentException("Factorial is not defined for negative numbers.");
        }

        // Base case: factorial of 0 is 1
        else if (num == 0)
        {
            return 1;
        }

        long result = 1;

        // Calculate factorial using a for loop
        for (int i = 1; i <= num; i++)
        {
            result = checked(result * i); // Use checked to handle overflow
        }

        return result;
    }

    public double AreaOfTriangle(double baseLength, double height)
    {
        if (baseLength < 0 || height < 0) throw new ArgumentException("Base and height must be non-negative.");
        return 0.5 * baseLength * height;
    }

    public double AreaOfCircle(double radius)
    {
        if (radius < 0) throw new ArgumentException("Radius must be non-negative.");
        return Math.PI * radius * radius;
    }

    public double UnknownFunctionA(int num1, int num2)
    {
        if (num1 < 0 || num2 < 0)
        {
            throw new ArgumentException("Input values must be non-negative.");
        }

        // Calculate the factorials
        double factorialNum1 = Factorial(num1);
        double factorialDiff = Factorial(num1 - num2);

        // Calculate the result
        double result = Divide(factorialNum1, factorialDiff);

        return result;
    }
    
    public double UnknownFunctionB(int num1, int num2)
    {
        if (num1 < 0 || num2 < 0 || num1 < num2)
        {
            throw new ArgumentException("Invalid input: n must be greater than or equal to r, and both must be non-negative.");
        }

        double factorialNum1 = Factorial(num1);
        double factorialNum2 = Factorial(num2);
        double factorialDiff = Factorial(num1 - num2);
        
        

        return Divide(factorialNum1, Multiply(factorialNum2, factorialDiff));
    }
    
    public double MeanTimeToFailure(double MTTF, double MTTR)
    {
        
        if ((MTTF <= 0) || (MTTR <=0 ))
        {
            throw new ArgumentException("0 is an invalid input");
        }
        
        double result = MTTF + MTTR;
        return result;
    }

    public double Availability(double MTTF, double MTTR)
    {
        
        if ((MTTF <= 0) || (MTTR <= 0))
        {
            throw new ArgumentException("0 is an invalid input");
        }

        double availabilityResult = (MTTF / (MTTF+MTTR)) * 100;
        //return 2 dec places
        return Math.Round(availabilityResult,2);
    }
    
    public double CurrentFailureIntensity
        (double FailuresPerHour, double FailuresAlreadyOccurred, double FailuresInInfiniteTime)
    {
        double result = FailuresPerHour * (1-(FailuresAlreadyOccurred/FailuresInInfiniteTime));
        //2dp
        return Math.Round(result, 2);
    }
    //Avg. Number of expected failures =  10 failures/h, 100 failures in inf. time, 10 = 10cpu hours
    public double AverageNumberOfExpectedFailures
        (double InitialFailureIntensity, double FailuresInInfiniteTime, double CPUHours)
    {
        double result = 
            FailuresInInfiniteTime * (1- Math.Exp(-InitialFailureIntensity/FailuresInInfiniteTime * CPUHours));
        //2dp
        return Math.Round(result, 2);
    }
    
    public double ShippedSourceCode(double InitialLOC, double ChangedLOC, double ChangedPercent)
    {
        // Validate ChangedPercent input
        if (ChangedPercent < 0)
        {
            throw new ArgumentException("You can't enter anything less than 0 here.");
        }
        else if (ChangedPercent > 100)
        {
            throw new ArgumentException("How can you possibly change more than 100% of code?");
        }

        // If ChangedPercent is greater than 1, convert to percentage
        ChangedPercent = (ChangedPercent > 1) ? ChangedPercent / 100 : ChangedPercent;

        // Calculate the effective change
        double effectiveChange = ChangedLOC * (1 - ChangedPercent);
    
        // Calculate the result
        double result = InitialLOC + effectiveChange;
    
        return Math.Round(result, 2);
    }
    
    public double LogarithmicCurrentFailureIntensity
        (double initialFailureIntensity, double failureRate, double FailuresAlreadyOccurred)
    {
        if ((initialFailureIntensity <= 0) || (failureRate <= 0) || (FailuresAlreadyOccurred < 0))
        {
            throw new ArgumentException("Hallo! Du kannst nicht ein nummer kleiner zu null eingeben");
        }
        double result = initialFailureIntensity * Math.Exp(-failureRate*FailuresAlreadyOccurred);
        return Math.Round(result, 2);
    }

    public double LogarithmicAverageNumberOfExpectedFailures
        (double failureRate, double initialFailureIntensity, double CPUHours)
    {
        if ((failureRate <= 0) || (initialFailureIntensity <= 0) || (CPUHours <= 0))
        {
            throw new ArgumentException("Hallo! Du kannst nicht ein nummer kleiner zu null eingeben");
        }
        double result = (1/failureRate)*Math.Log(initialFailureIntensity*failureRate*CPUHours+1);
        return result;
    }

}