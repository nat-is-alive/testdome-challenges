// response for test https://staging.testdome.com/certificates/eed79707291b42f0a9106dea4089ab8f

using System;

class MalwareAnalysis
{
    public static int[] Simulate(int[] entries)
    {
        bool[] willBeReplaced = new bool[entries.Length];

        for (int i = 0; i < willBeReplaced.Length; i++) {

          willBeReplaced[i] = false;

        }

        for (int i = 0; i < entries.Length; i++) {
        int currentEntry = i;
        int entryBefore = (currentEntry - 3);
        int entryAfter = (currentEntry + 4);
        String typeOfComparison = "no-comparison";

    if (entryBefore < 0) {

        typeOfComparison = "only-after";

    } else if (entryAfter >= entries.Length) {

        typeOfComparison = "only-before";

    } else {

        typeOfComparison = "before-after";

    }

    switch (typeOfComparison) {
        case "only-after":
            if (entries[currentEntry] <= entries[entryAfter]) {
                willBeReplaced[currentEntry] = true;
            }
            break;

        case "only-before":
            if (entries[currentEntry] <= entries[entryBefore]) {
                willBeReplaced[currentEntry] = true;
            }
            break;

        case "before-after":
            if (entries[currentEntry] <= entries[entryBefore] || entries[currentEntry] <= entries[entryAfter]) {
                willBeReplaced[currentEntry] = true;
            }
            break;

        case "no-comparison":
            break;
    }
}

      for (int i = 0; i < willBeReplaced.Length; i++) {

        if (willBeReplaced[i]) {
          entries[i] = 0;
        }

      }

      return entries;

    }

    public static void Main(string[] args)
    {
        //int[] records = new int[] { 19, 2, 0, 87, 1, 40, 80, 77, 77, 77, 77 };
        int[] records = new int[] { 19, 2, 0, 87, 1, 40, 80, 77, 77, 77, 77 };
        var result = Simulate(records);
        Console.WriteLine(string.Join(", ", result));
    }
}
