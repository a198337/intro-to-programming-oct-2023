
namespace StringCalculator;

public class StringCalculator
{
    string[] strArrNumbers;

    public int Add(string numbers)
    {
        if (numbers == "")
        {
            return 0;
        }
        //if (numbers.Contains(','))
        //{
        return numbers.Split(',', '\n') //["1", "2", ...]
            .Select(int.Parse) //[1,2,3,...] (works like mapping)
            .Sum(); //sums up the array
                    //language integrated query
                    //}

        //return int.Parse(numbers);
    }
}
