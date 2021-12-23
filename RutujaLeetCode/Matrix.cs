using System;
namespace RutujaLeetCode
{
    public static class Matrix
    {
        //Nick White Very good explanation
        public static int IslandPerimeter (int [] [] grid)
        {
            //Given grid if we find 1 then add 4 to result.
            //Now if there is land on PREV GRID OR TOP GRID <-VVIMP
            //if there is land on top or behind subtract 2 each time.
            //no need to check for next grid or below grid as it will be covered in the loop.

            //rows: grid.Length
            //col: grid[i].Length
            int result = 0;
            for (int i = 0; i < grid.Length; i++) {
                for (int j = 0; j < grid [i].Length; j++) {
                    if (grid [i] [j] == 1) {
                        result = result + 4;
                    }

                    if (i > 0 && grid [i - 1] [j] == 1)
                        result = result - 2;

                    if (j > 0 && grid [i] [j - 1] == 1)
                        result = result - 2;

                }
            }

            return result; //thats it!!!
        }

        //https://leetcode.com/problems/number-of-islands/        
      //  public static int NumIslands (char [] [] grid)
      //  {
            //Nick White
            //BFS
            //Convert each adjacent 1s with 0s and make them as 1 island so count++.


       // }
    }
}
