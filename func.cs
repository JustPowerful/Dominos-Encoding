using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace dominus {
  public class func {


  // Encode Vars
  public static string Etext;
  public static string Enumber;
  public static string TEnumber;
  public static string TEdominus;
  public static string ascii;
  public static string TEhex;

  // Decode Vars
  public static string TEdominus2;
  // -- to swtich between numbers
  public static string TEalpha;
  public static string TEbinary;
	  
  // decoded var
  public static string TEddominus;

  // ** encode function
  public static string Encode (string Etext) {
    // from string input to Binary
    Enumber = StringToBinary(Etext);

    TEnumber = Enumber.Replace("0", "a").Replace("1", "b");
    TEdominus = TEnumber.Replace("a", "1").Replace("b", "0");

    TEhex = BinaryToHex(TEdominus);

    // returns the value
    return TEhex;
  }

  // ** decode function
  public static string Decode (string TEdominus2) {

    var TEhex2bin = HexToBinary(TEdominus2);
    // from string input to Binary

    TEalpha = TEhex2bin.Replace("0", "a").Replace("1", "b");
    TEbinary = TEalpha.Replace("a", "1").Replace("b", "0");

    TEddominus = BinaryToString(TEbinary);
    // returns the value
    return TEddominus;


  }



  // ** Decoding | Encoding External Functions
  // String To Binary .
  public static string StringToBinary(string data)
  {
    StringBuilder sb = new StringBuilder();

    foreach (char c in data.ToCharArray())
    {
        sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
    }
    return sb.ToString();
  }

  // Binary To String
  public static string BinaryToString(string data)
  {
    List<Byte> byteList = new List<Byte>();

    for (int i = 0; i < data.Length; i += 8)
    {
        byteList.Add(Convert.ToByte(data.Substring(i, 8), 2));
    }
    return Encoding.ASCII.GetString(byteList.ToArray());
  }

  // Binary to decimal ascii
  public static string BinaryToASCII(string bin)
{
	string ascii = string.Empty;

	for (int i = 0; i < bin.Length; i += 8)
	{
		ascii += (char)BinaryToDecimal(bin.Substring(i, 8));
	}

	return ascii;
}

private static int BinaryToDecimal(string bin)
{
	int binLength = bin.Length;
	double dec = 0;

	for (int i = 0; i < binLength; ++i)
	{
		dec += ((byte)bin[i] - 48) * Math.Pow(2, ((binLength - i) - 1));
	}

	return (int)dec;
}

  // hex to binary
   public static string HexToBinary(string hexvalue)
        {
            // Convert.ToUInt32 this is an unsigned int
            // so no negative numbers but it gives you one more bit
            // it much of a muchness
            // Uint MAX is 4,294,967,295 and MIN is 0
            // this padds to 4 bits so 0x5 = "0101"
            return String.Join(String.Empty, hexvalue.Select(c => Convert.ToString(Convert.ToUInt32(c.ToString(), 16), 2).PadLeft(4, '0')));
        }

  // binary to hex
  public static string BinaryToHex(string binary)
  {
    StringBuilder result = new StringBuilder(binary.Length / 8 + 1);

    // TODO: check all 1's or 0's... Will throw otherwise

    int mod4Len = binary.Length % 8;
    if (mod4Len != 0)
    {
        // pad to length multiple of 8
        binary = binary.PadLeft(((binary.Length / 8) + 1) * 8, '0');
    }

    for (int i = 0; i < binary.Length; i += 8)
    {
        string eightBits = binary.Substring(i, 8);
        result.AppendFormat("{0:X2}", Convert.ToByte(eightBits, 2));
    }

    return result.ToString();
  }

}
}
