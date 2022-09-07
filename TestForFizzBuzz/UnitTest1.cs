namespace TestForFizzBuzz;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void should_return_1_when_number_cannot_be_divided_by_3_or_5_or_15()
    {
        //Given<"1">
        int num = 1;
        
        //When<count>
        string result = Count(num);
        
        //Then<"1">
        Assert.That(result, Is.EqualTo("1"));
    }
    
    [Test]
    public void should_return_Fizz_when_number_is_3()
    {
        //Given<"3">
        int num = 3;
        
        //When<count>
        string result = Count(num);
        
        //Then<"Buzz">
        Assert.That(result, Is.EqualTo("Fizz"));
    }
    
    [Test]
    public void should_return_Fizz_when_number_is_5()
    {
        //Given<"5">
        int num = 5;
        
        //When<count>
        string result = Count(num);
        
        //Then<"Buzz">
        Assert.That(result, Is.EqualTo("Buzz"));
    }

    [Test]
    public void should_return_FizzBuzz_when_number_is_15()
    {
        //Given<"15">
        int num = 15;
        
        //When<count>
        string result = Count(num);
        
        //Then<"FizzBuzz">
        Assert.That(result, Is.EqualTo("FizzBuzz"));
    }

    
    public string Count(int num)
    {
        //if num is 0, will reuturn "FizzBuzz"
        if (num % 15 == 0)
        {
            return "FizzBuzz";
        }
        if (num % 5 == 0)
        {
            return "Buzz";
        }
        if (num % 3 == 0)
        {
            return "Fizz";
        }

        return num.ToString();
    }
}