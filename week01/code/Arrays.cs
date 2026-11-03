public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static void Run() {
        double[] multiples = MultiplesOf(5, 6);
        List<int> numbers = new() {1, 2, 3, 4, 5, 6, 7, 8, 9};
        RotateListRight(numbers, 12);

        Console.WriteLine("<List>{" + string.Join(", ", multiples) + "}"); // <List>{5, 10, 15, 20, 25, 30}
        Console.WriteLine("<List>{" + string.Join(", ", numbers) + "}"); // <List>{7, 8, 9, 1, 2, 3, 4, 5, 6}
    }
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Step 1: Create a empty array
        double[] result = new double[length];
        // Step 2: Looping the number of times indicated by the length
        for (int i = 0; i < length; i++)
        {
            // At each position, we add 1 to the index (to avoid 0) 
            // and multiply by the number 
            result[i] = (i+1) * number;
        }
        // Finally returning the multiple of that number.
        return result;
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

        // Verify that there is data in the list.
        if (amount <= 0 || data.Count == 0)
        {
            return;
        }
        // We use the modulo operator to arrange items in a circular
        //  fashion and ensure the count stays within 
        // the expected range.
        amount = amount % data.Count;
        // get items to move
        var sortItems = data.Count - amount;
        //split the list into 2 to make it easier to sort
        var firstItem = data.GetRange(sortItems, amount); // [7,8,9]
        var lastItem = data.GetRange(0, sortItems); // [1,2,3,4,5,6]
        
        // join the 2 parts of the list
        firstItem.AddRange(lastItem);
        // clean the entered list
        data.RemoveRange(0, data.Count);
        // Add the combined lists, in the new order.
        data.AddRange(firstItem);
    }
}
