// response for test https://staging.testdome.com/certificates/bf68173ee88745d986219342dbdce15c

boolean[] willBeReplaced = new boolean[entries.length];

        for (int i = 0; i < willBeReplaced.length; i++) {
            willBeReplaced[i] = false;
        }

        for (int i = 0; i < entries.length; i++) {
            int currentEntry = i;
            int entryBefore = (currentEntry - 3);
            int entryAfter = (currentEntry + 4);
            String typeOfComparison = "no-comparison";

            if (entryBefore < 0) {
                typeOfComparison = "only-after";
            } else if (entryAfter >= entries.length) {
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

        for (int i = 0; i < willBeReplaced.length; i++) {
            if (willBeReplaced[i]) {
                entries[i] = 0;
            }
        }

        return entries;
