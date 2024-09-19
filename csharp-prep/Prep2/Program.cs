using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string input = Console.ReadLine();
        int gradePercentage = int.Parse(input);
        string letterGrade = string.Empty;
        if (gradePercentage >= 90) {
            letterGrade = "A";
        }
        else if (gradePercentage >= 80) {
            letterGrade = "B";
        }
        else if (gradePercentage >= 70) {
            letterGrade = "C";
        }
        else if (gradePercentage >= 60) {
            letterGrade = "D";
        }
        else {
            letterGrade = "F";
        }
        int gradePrecision = gradePercentage % 10;
        if (gradePrecision >= 7 && !(letterGrade == "A" || letterGrade == "F")) {
            letterGrade += "+";
        }
        else if (gradePrecision <= 3 && letterGrade != "F") {
            letterGrade += "-";
        }
        Console.WriteLine($"You have a(n) {letterGrade}.");
        if (!(letterGrade == "F" || letterGrade == "D")) {
            Console.WriteLine("You are passing!");
        }
        else {
            Console.WriteLine("You are failing!");
        }
    }
}