if (grade >= 90)
{
    Console.WriteLine("Grade: A");
    CongratulateStudent();
    UpdateRecords();
}
else if (grade >= 80)
{
    Console.WriteLine("Grade: B");
    CongratulateStudent();
    UpdateRecords();
}
else if (grade >= 70)
{
    Console.WriteLine("Grade: C");
    UpdateRecords();
}
else if (grade >= 60)
{
    Console.WriteLine("Grade: D");
    UpdateRecords();
}
else
{
    Console.WriteLine("Grade: F");
    UpdateRecords();
}
