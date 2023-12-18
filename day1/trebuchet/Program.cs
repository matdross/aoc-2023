namespace trebuchet;

class Program
{
    static void Main(string[] args)
    {
        var lines = File.ReadAllLines("./trebuchet/input.txt");

        var total = 0;
        string? first = null!;
        int position = 0;
        string? last;

        for (var i = 0; i < lines.Length; i++) {
            var charArray = lines[i].ToCharArray();

            for (var y = 0; y < charArray.Length; y ++) {
                if (short.TryParse(charArray[y].ToString(), out var number)) {
                    first ??= number.ToString();
                    position = y;
                }
            }

            last = charArray[position].ToString();

            // both variables have to be a number
            if (short.TryParse(first + last, out var lineNumberTotal)) {
                total += lineNumberTotal;
            }

            first = null;
            position = 0;
        }

        Console.WriteLine(total);
    }
}