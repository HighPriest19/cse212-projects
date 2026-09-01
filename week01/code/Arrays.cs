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
        // 1. Create a new array of doubles with a fixed size equal to the given 'length'.
        double[] result = new double[length];

        // 2. Loop from i = 0 up to length - 1 to populate every index of the array.
        for (int i = 0; i < length; i++)
        {
            // 3. Calculate each multiple by multiplying the starting number by (i + 1) 
            //    and store it at the current index.
            result[i] = number * (i + 1);
        }

        // 4. Return the completed array of multiples.
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
        // 1. Handle edge cases where the list is too short or rotation amount is invalid.
        if (amount <= 0 || data.Count <= 1) return;

        // 2. Calculate the slice index where the tail portion begins.
        int sliceIndex = data.Count - amount;

        // 3. Extract the tail elements that need to move to the front.
        List<int> tail = data.GetRange(sliceIndex, amount);

        // 4. Extract the head elements that need to shift to the back.
        List<int> head = data.GetRange(0, sliceIndex);

        // 5. Clear the original list and rebuild it with tail first, followed by head.
        data.Clear();
        data.AddRange(tail);
        data.AddRange(head);
    }
}