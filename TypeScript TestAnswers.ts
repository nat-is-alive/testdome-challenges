class GameObject {
    constructor(public x: number, public y: number){}
}

class Circle extends GameObject{
  public radius: number;

  constructor (x:number, y:number, radius:number) {
    super(x, y);
    this.radius = radius;
  }
}

let circle = new Circle(10, 50, 8);
console.log(circle.x, circle.y, circle.radius);  // should print "10 50 8"


// second question

function simulate(entries: number[]): number[] {

  const willBeReplaced: boolean[] = new Array(entries.length).fill(false); // initialise and fill array with false - that the numbers wont be replaced in later comparison

        for (let i = 0; i < entries.length; i++) { // loop through the numbers

            const currentEntry = i; // define current entry

            const entryBefore = (currentEntry - 3); // define T entry 3 indexes before to be compared

            const entryAfter = (currentEntry + 4); // define T entry 4 indexes after to be compared

            let typeOfComparison = "no-comparison"; // initialise variable to determine type of comparison

            if (entryBefore < 0) { // if it is in position 0 or one that cant look outside the lower bound of the array

                typeOfComparison = "only-after"; // it can check only after values

            } else if (entryAfter >= entries.length) { // if it is in an index that cant look outside the upper bound of the array

                typeOfComparison = "only-before"; // it is only able to check the

            } else {

                typeOfComparison = "before-after"; // otherwise it can check both values

            }

            switch (typeOfComparison) { // check values bases on the type the index position can compare to, add to array true value if this index will be replaced due to logic of being smaller than comparative numbers

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

                case "no-comparison": // if it cant be compared, then exit switch

                    break;
            }
        }

        // important to carry out the assignment of zero values here so not to intefere with the comparisons of this array carried out earlier


        for (let i = 0; i < willBeReplaced.length; i++) { // loop through the length of the array

            if (willBeReplaced[i]) { // if the number is to be replaced due to being smaller

              entries[i] = 0; // set the value to zero as does the malware

            }
        }

        return entries;
}

const records: number[] = [1, 2, 0, 5, 0, 3];
console.log(records);
console.log(simulate(records));
