using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace ConsoleUI
{
    internal static class Runner
    {
        private static GarageManager s_GarageManager = new GarageManager();

        public static void InitProgram()
        {
            mainMenu();
        }

        private static void mainMenu()
        {
            bool isQuitOptionPressed = false;

            while (!isQuitOptionPressed)
            {
                ConsoleRenderer.RenderHeadline(MenuOptions.k_GarageHeadline);
                ConsoleRenderer.RenderMenu(MenuOptions.k_MainMenuDescription, MenuOptions.MainMenuOption);
                MenuOptions.eMainMenuOption selectedOption = (MenuOptions.eMainMenuOption)int.Parse(UiValidator.InputValidatorGeneric<int>((i_MaxValue, i_UserInput) => UiValidator.IsNumberTypeAndInRange(i_MaxValue, i_UserInput, int.TryParse), MenuOptions.MainMenuOption.Length));

                switch (selectedOption)
                {
                    case MenuOptions.eMainMenuOption.AddNewVehicle:
                        addNewVehicle();
                        break;

                    case MenuOptions.eMainMenuOption.ShowVehiclesByStatus:
                        showVehiclesByStatus();
                        break;

                    case MenuOptions.eMainMenuOption.ChangeVehicleStatus:
                        changeVehicleStatus();
                        break;

                    case MenuOptions.eMainMenuOption.InflateVehicleWheels:
                        inflateVehicleWheelsToMax();
                        break;

                    case MenuOptions.eMainMenuOption.FuelVehicle:
                        fuelVehicle();
                        break;

                    case MenuOptions.eMainMenuOption.ChargeVehicle:
                        chargeVehicle();
                        break;

                    case MenuOptions.eMainMenuOption.ShowVehicleProperties:
                        getVehicleProperties();
                        break;

                    case MenuOptions.eMainMenuOption.ExitApplication:
                        isQuitOptionPressed = true;
                        break;

                }
            }
        }

        private static void getVehicleProperties()
        {
            ConsoleRenderer.RenderHeadline(MenuOptions.k_ShowVehiclePropertiesHeadline);
            string licensePlateFromUserString = ConsoleRenderer.RenderRequestForANonEmptyString(MenuOptions.k_AskForLicensePlateMsg);

            try
            {
                if (s_GarageManager.Contains(licensePlateFromUserString))
                {
                    ConsoleRenderer.RenderMessage(s_GarageManager.GetVehicleByLicensePlate(licensePlateFromUserString).ToString());
                    ConsoleRenderer.RenderMessageAndWaitForUserEnterKey(MenuOptions.k_PressEnterToNavBackToMainMenuMsg);
                }
                else
                {
                    ConsoleRenderer.RenderMessageAndWaitForUserEnterKey(string.Format("{0} ,{1} ", MenuOptions.k_VehicleWasntFindByLicensePlateMsg,MenuOptions.k_PressEnterToNavBackToMainMenuMsg ));
                }
            } catch (Exception) 
            {
                ConsoleRenderer.RenderMessageAndWaitForUserEnterKey(string.Format("{0} ,{1} ", MenuOptions.k_VehicleWasntFindByLicensePlateMsg, MenuOptions.k_PressEnterToNavBackToMainMenuMsg));
            }

        }

        private static void fuelVehicle()
        {
            ConsoleRenderer.RenderHeadline(MenuOptions.k_FuelVehicleEngineHeadline);
            string licensePlateFromUserString = ConsoleRenderer.RenderRequestForANonEmptyString(MenuOptions.k_AskForLicensePlateMsg);
            FuelEngine.eFuelType fuelTypeFromUser = getFuelTypeFromUser();
            ConsoleRenderer.RenderMessage(MenuOptions.k_FuelEngineDescription);
            string amountToFillFromUser = UiValidator.InputValidatorGeneric<float>((i_MaxValue, i_UserInput) => UiValidator.IsNumberTypeAndInRange(i_MaxValue, i_UserInput, float.TryParse), float.MaxValue);

            if (s_GarageManager.Contains(licensePlateFromUserString))
            {
                try
                {
                    s_GarageManager.FuelEngine(licensePlateFromUserString, amountToFillFromUser, fuelTypeFromUser);
                    ConsoleRenderer.RenderMessageAndWaitForUserEnterKey(string.Format("{0} ,{1}", MenuOptions.k_FuelEngineSuccessfulyMsg, MenuOptions.k_PressEnterToNavBackToMainMenuMsg));
                } 
                catch (Exception e)
                {
                    ConsoleRenderer.RenderMessageAndWaitForUserEnterKey(string.Format("{0} ,{1}", e.Message , MenuOptions.k_PressEnterToNavBackToMainMenuMsg));
                }
            }
            else
            {
                ConsoleRenderer.RenderMessageAndWaitForUserEnterKey(string.Format("{0} ,{1}", MenuOptions.k_VehicleWasntFindByLicensePlateMsg, MenuOptions.k_PressEnterToNavBackToMainMenuMsg));
            }
        }

        private static void chargeVehicle()
        {
            ConsoleRenderer.RenderHeadline(MenuOptions.k_FuelVehicleEngineHeadline);
            string licensePlateFromUserString = ConsoleRenderer.RenderRequestForANonEmptyString(MenuOptions.k_AskForLicensePlateMsg);

            if (s_GarageManager.Contains(licensePlateFromUserString))
            {
                ConsoleRenderer.RenderMessage(MenuOptions.k_ChargeBatteryDescription);
                string timeToChargeFromUser = UiValidator.InputValidatorGeneric<float>((i_MaxValue, i_UserInput) => UiValidator.IsNumberTypeAndInRange(i_MaxValue, i_UserInput, float.TryParse), float.MaxValue);

                try
                {
                    s_GarageManager.ChargeBattery(licensePlateFromUserString, timeToChargeFromUser);
                    ConsoleRenderer.RenderMessageAndWaitForUserEnterKey(string.Format("{0} ,{1}", MenuOptions.k_ChargeEngineSuccessfulyMsg, MenuOptions.k_PressEnterToNavBackToMainMenuMsg));
                }
                catch (Exception e)
                {
                    ConsoleRenderer.RenderMessageAndWaitForUserEnterKey(string.Format("{0} ,{1}", e.Message, MenuOptions.k_PressEnterToNavBackToMainMenuMsg));
                }
            }
            else
            {
                ConsoleRenderer.RenderMessageAndWaitForUserEnterKey(string.Format("{0} ,{1}", MenuOptions.k_VehicleWasntFindByLicensePlateMsg, MenuOptions.k_PressEnterToNavBackToMainMenuMsg));
            }
        }

        private static FuelEngine.eFuelType getFuelTypeFromUser()
        {
            ConsoleRenderer.RenderMenu("Please choose the fuel type :", MenuOptions.FuelMenuOption);

            return (FuelEngine.eFuelType)int.Parse(UiValidator.InputValidatorGeneric<int>((i_MaxValue, i_UserInput) => UiValidator.IsNumberTypeAndInRange(i_MaxValue, i_UserInput, int.TryParse), MenuOptions.FuelMenuOption.Length));
        }

        private static void changeVehicleStatus()
        {
            ConsoleRenderer.RenderHeadline(MenuOptions.k_ChangeVehicleStatusHeadline);
            string licensePlateFromUserString = ConsoleRenderer.RenderRequestForANonEmptyString(MenuOptions.k_AskForLicensePlateMsg);
            if (s_GarageManager.Contains(licensePlateFromUserString))
            {
                ConsoleRenderer.RenderMenu("Select status to modify to : ", MenuOptions.VehicleStatusMenuOptions);
                GarageCard.eVehicleStatus statusToChange = (GarageCard.eVehicleStatus)int.Parse(UiValidator.InputValidatorGeneric<int>((i_MaxValue, i_UserInput) => UiValidator.IsNumberTypeAndInRange(i_MaxValue, i_UserInput, int.TryParse), MenuOptions.VehicleStatusMenuOptions.Length));
                s_GarageManager.ChangeStatus(licensePlateFromUserString, statusToChange);
                ConsoleRenderer.RenderMessageAndWaitForUserEnterKey(string.Format("{0} , {1}", MenuOptions.k_VehcileStatusChangedSuccessfulyMsg, MenuOptions.k_PressEnterToNavBackToMainMenuMsg));
            }
            else
            {
                ConsoleRenderer.RenderMessageAndWaitForUserEnterKey(string.Format("{0} ,{1}", MenuOptions.k_VehicleWasntFindByLicensePlateMsg, MenuOptions.k_PressEnterToNavBackToMainMenuMsg));
            }
        }

        private static void inflateVehicleWheelsToMax()
        {
            ConsoleRenderer.RenderHeadline(MenuOptions.k_InflateWheelsToMaxHeadline);
            string licensePlateFromUserString = ConsoleRenderer.RenderRequestForANonEmptyString(MenuOptions.k_AskForLicensePlateMsg);
            
            if (s_GarageManager.Contains(licensePlateFromUserString))
            {
                s_GarageManager.InflateVehicleWheelsToMax(licensePlateFromUserString);
                ConsoleRenderer.RenderMessageAndWaitForUserEnterKey(string.Format("{0} ,{1}",MenuOptions.k_WheelsInflatedSuccessfulyMsg, MenuOptions.k_PressEnterToNavBackToMainMenuMsg));
            }
            else
            {
                ConsoleRenderer.RenderMessageAndWaitForUserEnterKey(string.Format("{0} ,{1} ", MenuOptions.k_VehicleWasntFindByLicensePlateMsg, MenuOptions.k_PressEnterToNavBackToMainMenuMsg));
            }
        }

        private static void showVehiclesByStatus()
        {
            string selectedStatus = getVehicleStatusToFilterFromUser();

            showVehiclesFilteredByStatus(selectedStatus);
        }

        private static string getVehicleStatusToFilterFromUser()
        {
            ConsoleRenderer.RenderHeadline(MenuOptions.k_ShowVehiclesFilteredByHeadline);
            ConsoleRenderer.RenderMenu(MenuOptions.k_ShowVehiclesFilteredByMsg, MenuOptions.StatusToFilterByMenuOptions);

            return UiValidator.InputValidatorGeneric<int>((i_MaxValue, i_UserInput) => UiValidator.IsNumberTypeAndInRange(i_MaxValue, i_UserInput, int.TryParse), MenuOptions.StatusToFilterByMenuOptions.Length);
        }

        private static void showVehiclesFilteredByStatus(string i_VehicleStatus)
        {
            Dictionary<string, RegisteredVehicle> vehiclesFilteredByStatusDict;
            int vehicleStatusAsInt = int.Parse(i_VehicleStatus);    

            if (vehicleStatusAsInt == 4)
            {
                vehiclesFilteredByStatusDict = s_GarageManager.Vehicles;
            }
            else
            {
                vehiclesFilteredByStatusDict = s_GarageManager.GetVehiclesByStatus((GarageCard.eVehicleStatus)vehicleStatusAsInt);
            }

            ConsoleRenderer.RenderHeadline(MenuOptions.k_ShowVehiclesFilteredByHeadline);
            ConsoleRenderer.RenderVehiclesLicensePlateByStatus(vehiclesFilteredByStatusDict, MenuOptions.StatusToFilterByMenuOptions[vehicleStatusAsInt - 1]);
        }

        private static void addNewVehicle()
        {
            string userInputForLicensePlate;

            ConsoleRenderer.RenderHeadline(MenuOptions.k_AddNewVehicleHeadline);
            userInputForLicensePlate = ConsoleRenderer.RenderRequestForANonEmptyString(MenuOptions.k_AskForLicensePlateMsg);
            if (s_GarageManager.Contains(userInputForLicensePlate))
            {
                ConsoleRenderer.RenderMessageAndWaitForUserEnterKey(MenuOptions.k_VehicleIsAlreadyInTheGarageMsg);
                s_GarageManager.ChangeStatus(userInputForLicensePlate, GarageCard.eVehicleStatus.Inrepair);
            }
            else
            {
                    Vehicle vehicleFromUser = generateVehicle(userInputForLicensePlate);
                    GarageCard garageCard = generateGarageCard();

                    ConsoleRenderer.RenderHeadline(MenuOptions.k_AddNewVehicleHeadline);
                    s_GarageManager.RegisterVehicle(vehicleFromUser, garageCard);
                    ConsoleRenderer.RenderMessageAndWaitForUserEnterKey(MenuOptions.k_VehicleRegisteredMsg);
            }
            
        }

        private static Vehicle generateVehicle(string i_UserInputForLicensePlate)
        {
            ConsoleRenderer.RenderMenu(MenuOptions.k_ModelMenuDescription, MenuOptions.ModelMenuOptions);
            eVehicleType vehicleTypeOption = (eVehicleType)int.Parse(UiValidator.InputValidatorGeneric<int>((i_MaxValue, i_UserInput) => UiValidator.IsNumberTypeAndInRange(i_MaxValue, i_UserInput, int.TryParse), MenuOptions.ModelMenuOptions.Length));
            Vehicle vehicle = s_GarageManager.InitVehicle(i_UserInputForLicensePlate, vehicleTypeOption);
            getAndSetProperties(vehicle, MenuOptions.k_AddNewVehicleHeadline);

            return vehicle;
        }

        private static GarageCard generateGarageCard()
        {
            GarageCard garageCard = new GarageCard();

            ConsoleRenderer.RenderHeadline(MenuOptions.k_OwnerCreationHeadline);
            getAndSetProperties(garageCard, MenuOptions.k_OwnerCreationHeadline);

            return garageCard;
        }
 
        private static void getAndSetProperties<T>(T i_ObjectThatSupportsProperties, string i_HeadlineString) where T : IPropertyHolder
        {
            Dictionary<string, string[]> propertiesToGetFromUserDict = i_ObjectThatSupportsProperties.GetProperties();

            while (true)
            {
                try
                {
                    i_ObjectThatSupportsProperties.SetProperties(getAllPropertiesFromUser(propertiesToGetFromUserDict));
                    break;
                }
                catch (Exception ex)
                {
                    ConsoleRenderer.RenderHeadline(i_HeadlineString);
                    ConsoleRenderer.RenderMessage(ex.Message);
                }
            }
        }

        private static Dictionary<string, string> getAllPropertiesFromUser(Dictionary<string, string[]> i_PropertiesDict)
        {
            Dictionary<string, string> chosenPropertiesDict = new Dictionary<string, string>();
            string propertyNameDescription;

            foreach (string propertyName in i_PropertiesDict.Keys)
            {
                if (i_PropertiesDict[propertyName] == null)
                {
                    propertyNameDescription = string.Format("Please enter the {0}:", propertyName);
                    chosenPropertiesDict.Add(propertyName, ConsoleRenderer.RenderRequestForANonEmptyString(propertyNameDescription));
                }
                else
                {
                    ConsoleRenderer.RenderPropertiesMenu(propertyName, i_PropertiesDict[propertyName]);
                    chosenPropertiesDict.Add(propertyName, UiValidator.InputValidatorGeneric<int>((i_MaxValue, i_UserInput) => UiValidator.IsNumberTypeAndInRange(i_MaxValue, i_UserInput, int.TryParse), i_PropertiesDict[propertyName].Length));
                }
            }

            return chosenPropertiesDict;
        }
    }
}
