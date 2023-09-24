internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Rows: ");
        int rows = int.Parse(Console.ReadLine());
        Console.Write("Columns: ");
        int columns = int.Parse(Console.ReadLine());
        int[][] matrix_galaxy = new int[rows][];
        for (int i = 0; i < rows; i++)
        {
            matrix_galaxy[i] = new int[columns];
        }
        FillGalaxy(matrix_galaxy, columns);

        int Ivo_x = 0, Ivo_y = 0, Evil_force_x = 0, Evil_force_y = 0;

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "Let the Force be with you") {
                break;
            }
            else
            {
                string[] input_1 = input.Split();
                Ivo_x = int.Parse(input_1[0]);
                Ivo_y = int.Parse(input_1[1]);
                string[] input_2 = Console.ReadLine().Split();
                Evil_force_x = int.Parse(input_2[0]);
                Evil_force_y = int.Parse(input_2[1]);
            }
        }
        Console.WriteLine(SumStars(matrix_galaxy, Ivo_x, Ivo_y, Evil_force_x, Evil_force_y)) ;
    }
    public static void FillGalaxy(int[][] matrix_galaxy, int columns)
    {
        int index = 0;
        for(int i = 0; i < matrix_galaxy.Length; i++){
            matrix_galaxy[i] = new int[columns];
           for(int j = 0; j < columns; j++){
                matrix_galaxy[i][j] = index;
                index++;
           }
        }
    }
    public static int SumStars(int[][] matrix_galaxy, int Ivo_x, int Ivo_y, int Evil_force_x, int Evil_force_y) {
        int sum = 0;
        for (int i = Ivo_x - 1, j = Ivo_y + 1, a = Evil_force_x - 1, b = Evil_force_y - 1; 
            i < matrix_galaxy.Length && j < matrix_galaxy.Length && a < matrix_galaxy.Length && b < matrix_galaxy.Length; 
            i--, j++, a--, b--) {
            if (matrix_galaxy[i][j] != matrix_galaxy[a][b]) {
                sum += matrix_galaxy[i][j];
            }
        }
        return sum;
    }
}