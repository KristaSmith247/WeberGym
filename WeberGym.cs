/* WeberGym.cs
 * Author: Krista Smith
 * Date: 10/13/23
 * Description: This program is used by Weber Gym to display revenue for
 *  their 2 classes. Two types of classes are offered, Zumba ($4.00/class)
 *  and spin ($5.00/class). The amount of attendees has been given per class.
 */

using static System.Console;

namespace WeberGym
{
    internal class WeberGym
    {
        static void Main()
        {
            //6x4 array for zumba attendees
            int[,] zumbaAttendees =
            { {12, 10, 17, 22},
              {11, 13, 17, 22},
              {12, 10, 22, 22},
              {9, 14, 17, 22},
              {12, 10, 21, 12},
              {12, 10, 5, 10}
            };
            // 6x4 array for spin attendees
            int[,] spinAttendees =
            {
                {7, 11, 15, 8},
                {9, 9, 9, 9},
                {3, 12, 13, 7},
                {2, 9, 9, 10},
                {8, 4, 9, 4},
                {4, 5, 9, 3}
            };

            decimal zumbaPrice = 4.00M; // revenue per customer, Zumba
            decimal spinPrice = 5.00M; // revenue per customer, Spin
            string activity1 = "Zumba"; // label for Zumba
            string activity2 = "Spin"; // label for Spin

            // display instructions
            DisplayInstructions();
            WriteLine();
            WriteLine("\t\t   Weber Gym Weekly Report");

            // create Zumba table heading
            PrintHeading(activity1, 1);
            WriteLine();

            // initialize values to loop through array
            int rowStart = 0;
            int colStart = 0;
            int rowEnd = 1;
            int colEnd = 4;
            int dayVal = 0;

            // print body of Zumba table
            for (int k = 0; k < 6; k++)
            {
                Write("{0,11}:", GetDay(dayVal));
                PrintRow(rowStart, rowEnd, colStart, colEnd, zumbaAttendees, zumbaPrice);
                rowStart++;
                rowEnd++;
                dayVal++;
            }
            WriteLine();
            // print total Zumba revenue
            PrintTotals(zumbaAttendees, zumbaPrice);


            // put space between the two class reports
            WriteLine();
            WriteLine();
            WriteLine();

            // create spin class heading
            PrintHeading(activity2, 2);
            WriteLine();

            // initialize values to loop through array
            int rowStart2 = 0;
            int colStart2 = 0;
            int rowEnd2 = 1;
            int colEnd2 = 4;
            int dayVal2 = 0;

            // print the main body of the spin table
            for (int k = 0; k < 6; k++)
            {
                Write("{0,11}:", GetDay(dayVal2));
                PrintRow(rowStart2, rowEnd2, colStart2, colEnd2, spinAttendees, spinPrice);
                rowStart2++;
                rowEnd2++;
                dayVal2++;
            }
            WriteLine();
            // print total Spin revenue
            PrintTotals(spinAttendees, spinPrice);

        }
        private static void DisplayInstructions()
        {
            // function to display explanation at beginning of program
            Write("This app displays the times and number of");
            Write(" attendees in two classes offered\n at the Weber");
            Write(" Gym, Zumba and Spinning. It also displays the revenue");
            Write(" per day\n and overall revenue for each class.\n\n");
        }
        private static int SumRows(int rowStart, int[,] attendees)
        {
            // find sum of all values in a single row
            int rowSum = 0;
            for (int i = rowStart; i < rowStart + 1; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    rowSum += attendees[i, j];
                }
            }
            return rowSum;
        }
        private static int SumColumns(int colStart, int[,] attendees)
        {
            // find the sum of all values in one array column
            int colSum = 0;
            for (int i = 0; i < attendees.GetLength(0); i++)
            {
                for (int j = colStart; j < colStart + 1; j++)
                {
                    colSum += attendees[i, j];
                }
            }
            return colSum;
        }
        private static void PrintHeading(string activity, int startTime)
        {
            // print the name and times of the class

            // header spacing
            WriteLine("\t\t\t{0} Attendees", activity);
            WriteLine();
            Write("\t    ");
            
            // print times
            for (int i = 0; i < 4; i++)
            {
                Write("{0,5}:00", startTime);
                startTime += 2; // increment class time by 2 hours
            }
            Write("\tTotal\tRevenue");
            WriteLine();
        }
        private static void PrintRow(int rowBegin, int rowEnd, int colBegin, int colEnd, int[,] attendees, decimal price)
        {
            // print body of report by printing each index of array,
            // with row total and revenue at the end of each row
            int rowSum = 0;
            for (int i = rowBegin; i < rowEnd; i++) // begins at 0, 1
            {
                for (int j = colBegin; j < colEnd; j++) // begins at 0, 4
                {
                    // write array index and keep total value of row indices
                    Write("{0,8}", attendees[i, j]);
                    rowSum = SumRows(i, attendees);
                }
                // write sum of all values in row, calculate total revenue for row
                Write("{0,8}", rowSum);
                Write("{0,11:c2}", rowSum * price);
                WriteLine();
            }
        }
        private static string GetDay(int day)
        {
            // determine weekday and return name of day
            string name = "";
            switch (day)
            {
                case 0:
                    name = "Monday";
                    break;
                case 1:
                    name = "Tuesday";
                    break;
                case 2:
                    name = "Wednesday";
                    break;
                case 3:
                    name = "Thursday";
                    break;
                case 4:
                    name = "Friday";
                    break;
                case 5:
                    name = "Saturday";
                    break;
            }
            return name;
        }

        private static void PrintTotals(int[,] attendees, decimal price)
        {
            // print the total revenue at the bottom of the table

            int weekAttendees = 0; // count of total attendees for entire week
            Write("     Totals:");
            for (int i = 0; i < 4; i++)
            {
                Write("{0,8}", SumColumns(i, attendees));
                weekAttendees += SumColumns(i, attendees);
            }
            Write("{0,8}", weekAttendees); // print number of attendees per week
            Write("{0,11:c2}", weekAttendees * price); // print total revenue
        }
    }
}