﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem11
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] grid = { { 8, 2, 22, 97, 38, 15, 0, 40, 0, 75, 4, 5, 7, 78, 52, 12, 50, 77, 91, 8, },
                            { 49, 49, 99, 40, 17, 81, 18, 57, 60, 87, 17, 40, 98, 43, 69, 48, 4, 56, 62, 0, },
                            { 81, 49, 31, 73, 55, 79, 14, 29, 93, 71, 40, 67, 53, 88, 30, 3, 49, 13, 36, 65, },
                            { 52, 70, 95, 23, 4, 60, 11, 42, 69, 24, 68, 56, 1, 32, 56, 71, 37, 2, 36, 91, },
                            { 22, 31, 16, 71, 51, 67, 63, 89, 41, 92, 36, 54, 22, 40, 40, 28, 66, 33, 13, 80, },
                            { 24, 47, 32, 60, 99, 3, 45, 2, 44, 75, 33, 53, 78, 36, 84, 20, 35, 17, 12, 50, },
                            { 32, 98, 81, 28, 64, 23, 67, 10, 26, 38, 40, 67, 59, 54, 70, 66, 18, 38, 64, 70, },
                            { 67, 26, 20, 68, 2, 62, 12, 20, 95, 63, 94, 39, 63, 8, 40, 91, 66, 49, 94, 21, },
                            { 24, 55, 58, 5, 66, 73, 99, 26, 97, 17, 78, 78, 96, 83, 14, 88, 34, 89, 63, 72, },
                            { 21, 36, 23, 9, 75, 0, 76, 44, 20, 45, 35, 14, 0, 61, 33, 97, 34, 31, 33, 95, },
                            { 78, 17, 53, 28, 22, 75, 31, 67, 15, 94, 3, 80, 4, 62, 16, 14, 9, 53, 56, 92, },
                            { 16, 39, 5, 42, 96, 35, 31, 47, 55, 58, 88, 24, 0, 17, 54, 24, 36, 29, 85, 57, },
                            { 86, 56, 0, 48, 35, 71, 89, 7, 5, 44, 44, 37, 44, 60, 21, 58, 51, 54, 17, 58, },
                            { 19, 80, 81, 68, 5, 94, 47, 69, 28, 73, 92, 13, 86, 52, 17, 77, 4, 89, 55, 40, },
                            { 4, 52, 8, 83, 97, 35, 99, 16, 7, 97, 57, 32, 16, 26, 26, 79, 33, 27, 98, 66, },
                            { 88, 36, 68, 87, 57, 62, 20, 72, 3, 46, 33, 67, 46, 55, 12, 32, 63, 93, 53, 69, },
                            { 4, 42, 16, 73, 38, 25, 39, 11, 24, 94, 72, 18, 8, 46, 29, 32, 40, 62, 76, 36, },
                            { 20, 69, 36, 41, 72, 30, 23, 88, 34, 62, 99, 69, 82, 67, 59, 85, 74, 4, 36, 16, },
                            { 20, 73, 35, 29, 78, 31, 90, 1, 74, 31, 49, 71, 48, 86, 81, 16, 23, 57, 5, 54, },
                            { 1, 70, 54, 71, 83, 51, 54, 69, 16, 92, 33, 48, 61, 43, 52, 1, 89, 19, 67, 48, } 
                          };

            GridExplorer gridExplorer = new GridExplorer(grid, 4);
            Console.WriteLine(gridExplorer.GetHighestSequenceForGrid());
            Console.ReadKey();
        }
    }

    class GridExplorer
    {
        public class Vector
        {
            public int x;
            public int y;

            public Vector(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public Vector Add(Vector b)
            {
                return new Vector(this.x + b.x, this.y + b.y);
            }

            public Vector Add(Vector b, int k)
            {
                return new Vector(this.x + k * b.x, this.y + k * b.y);
            }

            public override string ToString()
            {
                return "[" + this.y.ToString() + "," + this.x.ToString() + "]";
            }
        }

        public class Direction
        {
            public List<Vector> Positions = new List<Vector>();
            public int Value = 1;

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                foreach (Vector position in Positions)
                    sb.Append(position.ToString() + ", ");

                return Value.ToString() + ": " + sb.ToString();
            }

            public static bool operator >(Direction d1, Direction d2)
            {
                return d1.Value > d2.Value;
            }

            public static bool operator <(Direction d1, Direction d2)
            {
                return d1.Value < d2.Value;
            }
        }

        int[,] grid;
        int sequenceLength;
        List<Vector> possibleDirections;

        public GridExplorer(int[,] grid, int sequenceLength)
        {
            this.grid = grid;
            this.sequenceLength = sequenceLength;

            this.possibleDirections = new List<Vector>() { new Vector(0, 1),
                new Vector(1, 1),
                new Vector(1, 0),
                new Vector(1, -1),
                new Vector(0, -1),
                new Vector(-1, -1),
                new Vector(-1, 0),
                new Vector(-1, 1)
            };
            
        }

        public Direction GetHighestSequenceForGrid()
        {
            Direction currentHighestSequence = new Direction();
            for (int y = 0; y < grid.GetLength(0); y++)
            {
                for (int x = 0; x < grid.GetLength(1); x++)
                {
                    Direction currentSequence = this.GetHighestSequenceForPosition(new Vector(x, y));
                    if (currentSequence > currentHighestSequence)
                        currentHighestSequence = currentSequence;
                }
            }
            return currentHighestSequence;
        }

        private Direction GetHighestSequenceForPosition(Vector position)
        {
            Direction currentHighestDirection = new Direction();
            foreach (Vector directionVector in this.possibleDirections)
            {
                Direction direction = this.GetDirectionForPosition(position, directionVector);
                if (direction > currentHighestDirection)
                    currentHighestDirection = direction;
            }
            return currentHighestDirection;
        }

        private int GetPositionValue(Vector position)
        {
            if ((position.x < 0)||(position.x > grid.GetLength(0) - 1)||(position.y < 0)||(position.y > grid.GetLength(1) - 1))
                return 0;
            else
                return grid[position.x, position.y];
        }

        private Direction GetDirectionForPosition(Vector position, Vector direction)
        {
            Direction resultant = new Direction();
            resultant.Value = GetPositionValue(position);
            resultant.Positions.Add(position);

            for (int i = 1; i < this.sequenceLength; i++)
            {
                Vector newPosition = position.Add(direction, i);
                resultant.Value *= GetPositionValue(newPosition);
                resultant.Positions.Add(newPosition);
            }

            return resultant;
        }
    }
}