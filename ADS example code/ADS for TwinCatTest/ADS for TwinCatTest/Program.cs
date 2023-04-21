using System;
using TwinCAT.Ads;

namespace TwinCatAdsTest
{
    class Program
    {
        public static void Main()
        {
            using (AdsClient myClient = new AdsClient())
            {
                myClient.Connect(AmsNetId.Local, 851);
                if (myClient.IsConnected)
                {
                    Console.WriteLine("ADS Client has been initialised!");
                }
                else
                {
                    Console.WriteLine("Failed to connect ADS client");
                }

                var testBool = myClient.CreateVariableHandle("MAIN.testBool");
                var testInt = myClient.CreateVariableHandle("MAIN.testInt");

                //read variable
                var responseBool = myClient.ReadAny(testBool, typeof(bool));
                var responseInt = myClient.ReadAny(testInt, typeof(int));
                var responseString = myClient.ReadValue("MAIN.testString", typeof(string));

                Console.WriteLine("The variables where:");
                Console.WriteLine(responseBool);
                Console.WriteLine(responseInt);
                Console.WriteLine(responseString);

                //write variable
                myClient.WriteAny(testBool, false);
                myClient.WriteValue("MAIN.testInt", 5);
                myClient.WriteValue("MAIN.testString", "Hello world");

                responseBool = myClient.ReadAny(testBool, typeof(bool));
                responseInt = myClient.ReadAny(testInt, typeof(int));
                responseString = myClient.ReadValue("MAIN.testString", typeof(string));

                Console.WriteLine("The variables are now changed to:");
                Console.WriteLine(responseBool);
                Console.WriteLine(responseInt);
                Console.WriteLine(responseString);

                myClient.Disconnect();
                Console.WriteLine("Disconnected!");
            }

        }
    }
}