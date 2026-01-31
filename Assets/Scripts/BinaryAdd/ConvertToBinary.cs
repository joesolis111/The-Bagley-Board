using System;
using System.Collections.Generic;

namespace BinaryAdd {

  public enum BinaryKeys {
    DecNumber,
    BinNumber
  };
  
  class ConvertToBinary {
    private const int _maxBit = 7;

    /// <summary>
    /// Converts a number to binary.
    /// </summary>
    /// <returns>A string with the representation of the number in binary</returns>
    private string ConvertNumToBinary(int number) {
      string binaryNumber = "";

      while (number > 0) {
        int currentBit = number % 2;
        number /= 2;
        binaryNumber += currentBit;
      }

      char[] binaryNumberArr = binaryNumber.ToCharArray();
      Array.Reverse(binaryNumberArr);
      
      binaryNumber = new string(binaryNumberArr);
      binaryNumber = AddLeadingZeros(binaryNumber);
        
      return binaryNumber;
    }

    private string AddLeadingZeros(string number) {
      
      int missingZeros = _maxBit - number.Length;
      string missingZerosString = "";

      for (int i = missingZeros; i > 0; i--) {
        missingZerosString += "0";
      }
      
      return missingZerosString + number;
    }
    
    
    public Dictionary<BinaryKeys, string> GetBinaryNumber() {
      Dictionary<BinaryKeys, string> dictionary = new Dictionary<BinaryKeys, string>();

      int rng = GetRandomNumber();
    
      dictionary.Add(BinaryKeys.DecNumber, rng.ToString());
      dictionary.Add(BinaryKeys.BinNumber, ConvertNumToBinary(rng));
    
      return dictionary;
    }

    private int GetRandomNumber() {
      Random random = new Random();
      return random.Next(0, 127);
    }
  }
}
