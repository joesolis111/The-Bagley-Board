using System;
class Add
{
    
    static Random rnd = new Random();
    
    static void Main() {
        AddFunction();
    }
    
    public static void AddFunction()
    {
        int num1 = GenerateRandomNum();
        int num2 = GenerateRandomNum();
        
        string binary1 = ConvertToBinary(num1);
        string binary2 = ConvertToBinary(num2);
        
        string sumBinary = addBinary(binary1, binary2);
    }


    // Generates a random number between 1 and 128
    private static int GenerateRandomNum()
    {
        return rnd.Next(1, 128);
    }

    // Converts an integer to binary
    private static string ConvertToBinary(int num)
    {
        string binary = "";
        while (num > 0)
        {
            int bit = num % 2;
            binary += bit;
            num /= 2;
        }

        Char[] arr = binary.ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
    }

    // Adds two binary numbers
    private static string addBinary(string binary1, string binary2)
    {
        binary1 = TrimLeadingZeros(binary1);
        binary2 = TrimLeadingZeros(binary2);

        int n = binary1.size();
        int m = binary2.size();

        if (n < m) // Need to flip them around as larger number should be on top
        {
            return addBinary(binary2, binary1);
        }

        int j = m - 1;
        int carry = 0;
        char[] result = new char[n];

        for (int i = n - 1; i >= 0; i--)
        {
            int bit1 = binary1[i] - '0';
            int sum = bit1 + carry;

            if (j >= 0)
            {
                int bit2 = binary2[j] - '0';
                sum += bit2;
                j--;
            }

            int bit = sum % 2;
            carry = sum / 2;

            result[i] = (char)(bit + '0');
            
        }

        if (carry > 0)
        {
            return '1' + new string(result);
        }
        
        return new string(result);
    }

    // Need to find the first one, as 0 + 0 is just 0 
    private static TrimLeadingZeros(string binary)
    {
        int firstOne = binary.IndexOf('1');
        return (firstOne == -1) ? "0" : binary.Substring(firstOne);
    }
    
}