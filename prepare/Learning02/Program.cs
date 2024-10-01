using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startYear = "1943";
        job1._endYear = "2364";

        Job job2 = new Job();
        job2._company = "Apple";
        job2._jobTitle = "Head Engineer";
        job2._startYear = "1362";
        job2._endYear = "1939";

        Resume resume1 = new Resume();
        resume1._name = "Agranak the Destroyer";
        resume1._jobs.Add(job1);
        resume1._jobs.Add(job2);

        resume1.DisplayResume();
    }
}