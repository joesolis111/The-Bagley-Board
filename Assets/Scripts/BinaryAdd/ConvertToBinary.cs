using System.Linq;

namespace BinaryAdd {
  class ConvertToBinary {

    private readonly int maxBit = 7;
    
    /// <summary>
    /// Converts a number to binary.
    /// </summary>
    /// <returns>A string with the representation of the number in binary</returns>
    public string ConvertNumToBinary(int number) {
      string binaryNumber = "";

      while (number > 0) {
        int currentBit = number % 2;
        number /= 2;
        binaryNumber += currentBit;
      }

      char[] binaryNumberArr = binaryNumber.ToCharArray();
      binaryNumberArr.Reverse();
      
      binaryNumber = new string(binaryNumberArr);
      binaryNumber = AddLeadingZeros(binaryNumber);
        
      return binaryNumber;
    }

    public string AddLeadingZeros(string number) {
      
      int missingZeros = maxBit - number.Length;
      string missingZerosString = "";

      for (int i = missingZeros; i > 0; i--) {
        missingZerosString += "0";
      }
      
      return missingZerosString + number;
    }
  }
}