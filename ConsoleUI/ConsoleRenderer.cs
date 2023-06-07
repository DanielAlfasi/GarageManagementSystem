using Ex03.GarageLogic;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    internal static class ConsoleRenderer
    {
        public static void RenderMessage(string i_MessageToDisplay)
        {
            Console.WriteLine(i_MessageToDisplay);
        }

        public static string RenderRequestForANonEmptyString(string i_RequestToDisplay)
        {
            string userInput;

            while(true)
            {
                
                Console.WriteLine(i_RequestToDisplay);
                userInput = Console.ReadLine();
                if (userInput == null || userInput.Length == 0)
                {
                    Console.WriteLine("Invalid input (empty), try again");
                }
                else
                {
                    break;
                }
            }

            return userInput;
        }

        public static string RenderRequest(string i_MessageToDisplay)
        {
            Console.WriteLine(i_MessageToDisplay);

            return Console.ReadLine();
        }

        public static void RenderMessageAndWaitForUserEnterKey(string i_MessageToDisplay)
        {
            Console.WriteLine(i_MessageToDisplay);
            Console.ReadLine();
        }

        public static void RenderMenu(string i_MenuDescription, string[] i_MenuOptions)
        {
            Console.WriteLine(i_MenuDescription);
            for (int i = 0; i < i_MenuOptions.Length; i++) 
            {
                Console.WriteLine($"  {i + 1} - {i_MenuOptions[i]}");
            }
        }

        public static void RenderPropertiesMenu(string i_PropertyDescription, string[] i_PropertiesOptions) 
        {
            string propertiesMenuDescription = string.Format("Please enter the {0}:", i_PropertyDescription);

            Console.WriteLine(propertiesMenuDescription);
            for (int i = 0; i < i_PropertiesOptions.Length; i++)
            {
                Console.WriteLine($"  {i + 1} - {i_PropertiesOptions[i]}");
            }
        }

        public static void RenderHeadline(string i_FeatureHeadline)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(i_FeatureHeadline);
            Console.WriteLine();
        }

        public static void RenderVehiclesLicensePlateByStatus(Dictionary<string, RegisteredVehicle> i_Vehicles, string i_Status)
        {
            int lineCounter = 1;
            string headLine = string.Format("The following license plates are vehicles that are under the status {0} ",i_Status);

            Console.WriteLine(headLine);
            if(i_Vehicles.Count == 0)
            {
                RenderMessageAndWaitForUserEnterKey("There are no vehicles under this status, Press 'Enter' to navigate back to the main menu");
            }
            else
            {
                foreach (string vehicleLicensePlate in i_Vehicles.Keys)
                {
                    Console.WriteLine($"{lineCounter}. Model name : {i_Vehicles[vehicleLicensePlate].Vehicle.ModelName} , license plate : |{vehicleLicensePlate}|");
                    lineCounter++;  
                }
                RenderMessageAndWaitForUserEnterKey("Press 'Enter' to navigate back to the main menu");
            }
        }
    }
}
