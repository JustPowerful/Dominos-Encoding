using System;


namespace dominus {

  class MainClass {
    // this is just a testing script .

    // Variables
    public static string encoded;
    public static string decoded;


    public static void Main (string[] args) {
      // Importing a Class
      func function = new func();

      // Example of using the encoding/decoding functions .
      encoded = func.Encode("Hello");
      decoded = func.Decode("B79A939390");

      // Output
      Console.WriteLine("Encoded : " + encoded);
      Console.WriteLine("Decoded : " + decoded);

    }


  }

}
