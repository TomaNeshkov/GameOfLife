using GameOfLife;
using System;
using System.IO;

namespace GameOfLife
{
    public class GameOfLifeBuiltIn : GameOfLifeBase
    {
        public override void DrawMenuPanel(int windowWidth)
        {
            base.DrawMenuPanel(windowWidth);

            stringBuilder.AppendLine("[F1] Generate random cell state [F2] Pulsar field");
            stringBuilder.AppendLine("[Backspace] Start/stop the life [F2] Glider gun field");
            stringBuilder.AppendLine("[Escape] Start menu             [F4] Living forever field");

        }
        public GameOfLifeBuiltIn(int x, int y) : base(x, y)
        {

        }

        public void GenerateRandomField()
        {
            Random random = new Random();

            for (int row = 0; row < CurrentCellGeneration.GetLength(0); row++)
            {
                for (int col = 0; col < CurrentCellGeneration.GetLength(1); col++)
                {
                    CurrentCellGeneration[row, col] = random.Next(0, 2);
                }
            }
        }

        private int[,] GetFieldAsTextFile(string fileName)
        {
            string[] textFile = File.ReadAllText(fileName).Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            int[,] field = new int[CurrentCellGeneration.GetLength(0), CurrentCellGeneration.GetLength(1)];

            for (int row = 0; row < Math.Min(CurrentCellGeneration.GetLength(0), textFile.Length); row++)
            {
                string currentRow = textFile[row].Trim();

                for (int col = 0; col < Math.Min(CurrentCellGeneration.GetLength(1), currentRow.Length); col++)
                {
                    if (currentRow[col] == 'X')
                    {
                        field[row, col] = 1;
                    }
                }
            }

            return field;
        }

        public void GenerateField(string fileName)
        {
            int[,] field = GetFieldAsTextFile(fileName);

            for (int row = 0; row < CurrentCellGeneration.GetLength(0); row++)
            {
                for (int col = 0; col < CurrentCellGeneration.GetLength(1); col++)
                {
                    CurrentCellGeneration[row, col] = field[row, col];
                }
            }
        }
    }
}
