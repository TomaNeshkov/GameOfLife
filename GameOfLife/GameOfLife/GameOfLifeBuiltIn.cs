using System;
using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Markup;

namespace GameOfLife
{
    public class GameOfLifeBuiltIn : GameOfLifeBase
    {
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

        public override void DrawMenuPanel(int windowWidth)
        {
            base.DrawMenuPanel(windowWidth);

            stringBuilder.AppendLine("[F1] Generate random cell state   [F2] Pulsar field");
            stringBuilder.AppendLine("[Backspace] Start/stop the life   [F3] Glider gun field");
            stringBuilder.AppendLine("[Escape] Start menu               [F4] Living forever field");
        }

        private int[,] GetFieldAsTextFile(string fileName)
        {
            string[] textFile = File.ReadAllText(fileName).Split(",").ToArray();

            int[,] field = new int[CurrentCellGeneration.GetLength(0), CurrentCellGeneration.GetLength(1)];

            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1) - 1; col++)
                {
                    char[] currentRow = textFile[row].ToCharArray();

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
