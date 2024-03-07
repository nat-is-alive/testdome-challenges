// response for test https://staging.testdome.com/certificates/eed79707291b42f0a9106dea4089ab8f

using System;
using System.Collections.Generic;

public class MergeNames
{
    public static string[] UniqueNames(string[] names1, string[] names2)
    {
        List<string> duplicateNamesList = new List<string>();

        for (int i = 0; i < names1.Length; i++)
        {
            for (int j = 0; j < names2.Length; j++)
            {
                if (names1[i] == names2[j])
                {
                    if (!duplicateNamesList.Contains(names1[i]))
                    {
                        duplicateNamesList.Add(names1[i]);
                    }
                }
            }
        }

        return duplicateNamesList.ToArray();
    }

    public static void Main(string[] args)
    {
        string[] names1 = new string[] {"Ava", "Emma", "Olivia, Katie"};
        string[] names2 = new string[] {"Olivia", "Sophia", "Emma"};
        Console.WriteLine(string.Join(", ", MergeNames.UniqueNames(names1, names2))); // should print Ava, Emma, Olivia
    }
}
