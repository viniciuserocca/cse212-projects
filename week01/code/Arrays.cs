using System.Security.Cryptography.X509Certificates;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Plan: 
        // First, I will get the length entered by the user and then use it to create the array with the right size.
        // Second, I will do a for each loop, using the length as a parameter to determine how many loops will occur.
        // Third, I will use the index of the current execution of the loop to multiplicate the number passed by the user, for example, 
        //if the lenth is 5, the first loop will have the index = 1, so I will get this value * the number, the second loop
        //will have index = 2, then I will repeat the same logic over and over until all index are used and multiplied.

        double[] multiplesArray = new double[length];

        for (int i = 0; i < length; i++)
        {
            multiplesArray[i] = number * (i + 1);
        }
        return multiplesArray; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        //Plan:
        // I will use a C# function named Reverse, this function basically reverses the value within a list
        // So I will have to call it 3 times, doing the following:
        // 1 - Reverse the whole list
        // 2 - Reverse only the amount passed in the function starting on index 0
        // 3 - Reverse the rest of the list (ignoring the amount that was previously reversed), starting on the index of the amount

        data.Reverse();
        data.Reverse(0, amount);
        data.Reverse(amount, data.Count - amount);
    }
}
