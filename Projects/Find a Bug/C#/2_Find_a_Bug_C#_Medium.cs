// Fix the code to achieve the result
List<int> numberList = new List<int>(){1,2,3}; 
for (int i = numberList.Count - 1; i >= 0; i--) // Iterating through the entire array
{
    if (numberList[i] == 2) // The condition originally had only one = which is used for assignment, but for comparison we use == or === (== and === work similarly but are not the same! Both will work here)
    {
        numberList.RemoveAt(i); // Removing the element at index i
    }
}
Console.WriteLine(string.Join(", ", numberList)); // Desired output: 1, 3