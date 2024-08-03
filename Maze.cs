using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devoir4
{
    public class Maze
    {
        private int height;
        private int width;
        private List<List<bool>> walls;
        private (int, int) start;
        private (int, int) goal;
        private (List<string>, List<(int, int)>)? solution;
        private HashSet<(int, int)> explored;
        private int numExplored;

        public Maze(string filename)
        {
            // Read file and set height and width of maze
            string[] lines = File.ReadAllLines(filename);
            height = lines.Length;
            width = lines.Max(line => line.Length);

            // Validate start and goal
            int startCount = lines.SelectMany(line => line.Where(c => c == 'A')).Count();
            if (startCount != 1)
            {
                throw new Exception("maze must have exactly one start point");
            }

            int goalCount = lines.SelectMany(line => line.Where(c => c == 'B')).Count();
            if (goalCount != 1)
            {
                throw new Exception("maze must have exactly one goal");
            }

            // Keep track of walls
            walls = new List<List<bool>>();
            for (int i = 0; i < height; i++)
            {
                List<bool> row = new List<bool>();
                for (int j = 0; j < width; j++)
                {
                    try
                    {
                        if (lines[i][j] == 'A')
                        {
                            start = (i, j);
                            row.Add(false);
                        }
                        else if (lines[i][j] == 'B')
                        {
                            goal = (i, j);
                            row.Add(false);
                        }
                        else if (lines[i][j] == ' ')
                        {
                            row.Add(false);
                        }
                        else
                        {
                            row.Add(true);
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        row.Add(false);
                    }
                }
                walls.Add(row);
            }

            solution = null;
        }

        public string Print()
        {
            string output = "";
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (walls[i][j])
                    {
                        output += "█";
                    }
                    else if ((i, j) == start)
                    {
                        output += "A";
                    }
                    else if ((i, j) == goal)
                    {
                        output += "B";
                    }
                    else if (solution != null && solution.Value.Item2.Contains((i, j)))
                    {
                        output += "*";
                    }
                    else
                    {
                        output += " ";
                    }
                }
                output += Environment.NewLine;
            }
            return output;
        }

        public List<(string, (int, int))> Neighbors((int, int) state)
        {
            int row = state.Item1;
            int col = state.Item2;
            List<(string, (int, int))> candidates = new List<(string, (int, int))>
            {
                ("up", (row - 1, col)),
                ("down", (row + 1, col)),
                ("left", (row, col - 1)),
                ("right", (row, col + 1))
            };

            List<(string, (int, int))> result = new List<(string, (int, int))>();
            foreach (var (action, (r, c)) in candidates)
            {
                if (0 <= r && r < height && 0 <= c && c < width && !walls[r][c])
                {
                    result.Add((action, (r, c)));
                }
            }
            return result;
        }

        public void Solve()
        {
            // Initialize frontier to just the starting position
            Node startNode = new Node(start, null, null);
            StackFrontier frontier = new StackFrontier();
            frontier.Add(startNode);

            // Initialize an empty explored set
            explored = new HashSet<(int, int)>();

            // Keep looping until solution found
            while (true)
            {
                // If nothing left in frontier, then no path
                if (frontier.Empty())
                {
                    throw new Exception("no solution");
                }

                // Choose a node from the frontier
                Node node = frontier.Remove();
                numExplored++;

                // If node is the goal, then we have a solution
                if (node.State == goal)
                {
                    List<string> actions = new List<string>();
                    List<(int, int)> cells = new List<(int, int)>();
                    while (node.Parent != null)
                    {
                        actions.Add(node.Action);
                        cells.Add(node.State);
                        node = node.Parent;
                    }
                    actions.Reverse();
                    cells.Reverse();
                    solution = (actions, cells);
                    return;
                }

                // Mark node as explored
                explored.Add(node.State);

                // Add neighbors to frontier
                foreach (var (action, state) in Neighbors(node.State))
                {
                    if (!frontier.ContainsState(state) && !explored.Contains(state))
                    {
                        Node child = new Node(state, node, action);
                        frontier.Add(child);
                    }
                }
            }
        }

        public void OutputImage(string filename, bool showSolution = true, bool showExplored = false)
        {
            int cellSize = 100;
            int cellBorder = 2;
            int lineWidth = 3; // épaisseur de la ligne noire

            Bitmap bmp = new Bitmap(width * cellSize, height * cellSize);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                // Remplir chaque cellule
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        Brush fill;
                        if (walls[i][j])
                        {
                            fill = Brushes.DarkGray;
                        }
                        else if ((i, j) == start)
                        {
                            fill = Brushes.Red;
                        }
                        else if ((i, j) == goal)
                        {
                            fill = Brushes.Green;
                        }
                        else if (solution != null && showSolution && solution.Value.Item2.Contains((i, j)))
                        {
                            fill = Brushes.Yellow;
                        }
                        else if (solution != null && showExplored && explored.Contains((i, j)))
                        {
                            fill = Brushes.OrangeRed;
                        }
                        else
                        {
                            fill = Brushes.White;
                        }
                        g.FillRectangle(fill, j * cellSize + cellBorder, i * cellSize + cellBorder,
                            cellSize - 2 * cellBorder, cellSize - 2 * cellBorder);

                        // Dessiner les lignes noires autour de chaque cellule
                        g.DrawRectangle(new Pen(Color.Black, lineWidth),
                            j * cellSize, i * cellSize, cellSize, cellSize);
                    }
                }

                // Dessiner les lignes noires pour le contour du labyrinthe
                g.DrawRectangle(new Pen(Color.Black, lineWidth), 0, 0, width * cellSize, height * cellSize);
            }

            bmp.Save(filename);
        }

        public int NumExplored
        {
            get { return numExplored; }
        }
    }

}
