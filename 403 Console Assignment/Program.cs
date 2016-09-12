/* 
 * Author: Kate Cousineau
 * Section: 1
 * Description: Console Assignment
 * Console output matches sample output completely (see screenshot below)
 First letter of each teams's name is capitalized
 Program uses a List object to store the list of teams
 Teams are sorted by the team's points in descending order
 Result table has column headers and separators for Position, Name, and Points
 Result table displays each team's position, name, and points
 Properly implements Team and SoccerTeam classes but you do NOT need to implement the Game class
 Use exception handling to make sure that the number of teams they enter is a valid integer (try/catch within a while loop).
 Adds comments to make code easier to understand
 Upload the project here and also upload the zipped project to the Learning Suite assignment
 * (include the class diagram in your upload in the main root directory for your project so TAs can easily find it)
 * and then schedule a time with the TAs for them to grade this assignment
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _403_Console_Assignment
{
    class Program
    {
        class Team
        {
            public string name;
            public int wins;
            public int loss;
        }

        class SoccerTeam : Team
        {
            public int draw;
            public int goalsFor;
            public int goalsAgainst;
            public int differential;
            public int points;

            public SoccerTeam()
            {

            }

            public SoccerTeam(string sName, int iPoints)
            {
                this.name = sName;
                this.points = iPoints;
            }
        }

        class Game
        {
            public int numGames;

            public Game();


            //creates a list inside of a list 
            List<List<Game>> lgame = new List<List<Game>>();
        }

        static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        static void Main(string[] args)
        {
            //set variables
            int iNum=0;
            string sName;
            int iLoop;
            int iCount = 1;
            int iPoints;
            bool check = true;
            string sUserInput;
            //create a list object
            List<SoccerTeam> teams = new List<SoccerTeam>();
           
            //extra stuff added for more points :)
            Random rnd = new Random();
            int iWins;
            int iLosses;


            //tells user what to do
            Console.Write("How many teams? ");

            //exception handling in case user inputs string instead of int
            while (check)
            {
                try
                {
                    iNum = Convert.ToInt32(Console.ReadLine());
                    check = false;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("\nPlease enter a valid integer");
                }
            }

            //asks user for team name and points per number of teams 
            for (iLoop = 0; iLoop < iNum; iLoop++)
            {
                Console.Write("\n\nEnter team " + iCount++ + "'s name: ");
                sUserInput = Console.ReadLine();
                sName = UppercaseFirst(sUserInput); //ensures that the team names are capitalized 

                Console.Write("\nEnter " + sName + "'s points: ");
                iPoints = Convert.ToInt32(Console.ReadLine());

                //creates object and assigns name and points
                teams.Add(new SoccerTeam());
                teams.ElementAt(iLoop).name = sName;
                teams.ElementAt(iLoop).points = iPoints;
            }

           

            for (iLoop = 0; iLoop < iNum; iLoop++ )
            {
                //random number generator to create wins and losses
                iWins = rnd.Next(0, iNum);
                iLosses = iNum - iWins;

                teams.ElementAt(iLoop).wins = iWins;
                teams.ElementAt(iLoop).loss = iLosses;
            }


            //sorting list of objects
            List<SoccerTeam> sortedTeams = teams.OrderByDescending(team => team.points).ToList();

            //creates headings 
            Console.WriteLine("\n\nHere is the sorted list:\n\n");

            Console.WriteLine("Position" + "\t" + "Name".PadLeft(3) + "\t" + "Points".PadLeft(30));
            Console.WriteLine("--------" + "\t" + "----".PadLeft(3) + "\t" + "------".PadLeft(30));

            //outputs the data for each item 
            iCount = 1; //counter for the position

            foreach (SoccerTeam item in sortedTeams)
            {
                Console.Write(Convert.ToString(iCount++).PadRight(15) + "\t");
                Console.WriteLine(Convert.ToString(item.name).PadRight(25, ' ') + "\t" + 
                    Convert.ToString(item.points).PadRight(42));
            }

            {
                Console.WriteLine();
            }
        }
    }
}
