using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Railway_Reservation_System.Accessors;
using Railway_Reservation_System.Templates;
using Railway_Reservation_System.Data_Infrastructure;

namespace Railway_Reservation_System.Templates
{
    class admin_dashboard
    {
        Train_Class_Type_Access trainclass = new Train_Class_Type_Access();
        Train_Class_Type_Data trainclassdata = new Train_Class_Type_Data();
        public void AdminMenu()
        {
            bool run = true;
            while (run)
            {

                string headerText = "ADMIN DASHBOARD";
                string headerBorder = new string('=', 50);

                // Display the top border.
                Console.WriteLine($"\n{headerBorder}");
                // Center the header text within the border.
                Console.WriteLine($"{headerText.PadLeft((headerBorder.Length - headerText.Length) / 2 + headerText.Length)}");
                // Display the bottom border of the header.
                Console.WriteLine($"{headerBorder}\n");
                /*Console.WriteLine("\n==========================================================");*/
                Console.WriteLine("\n1. To Add Train.");
                Console.WriteLine("\n2. To Add Class Type.");
                Console.WriteLine("\n3. To Update the no of Seats.");
                Console.WriteLine("\n4. To View All the Trains.");
                Console.WriteLine("\n5. To Delete the Train.");
                Console.WriteLine("\n6. To Exit.");
                Console.Write("\nEnter choice: ");
                int getuser = Convert.ToInt32(Console.ReadLine());

                Train_Data traindata = new Train_Data();
                switch (getuser)
                {
                    case 1:
                        try
                        {
                            traindata.GetDataForAddTrain();
                            Console.WriteLine("The Train Added Successfully.....");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Something went wrong : {e.Message}");
                        }
                        break;

                    case 2:

                        Console.Write("Train ID: ");
                        trainclass.TrainId = int.Parse(Console.ReadLine());
                        Console.Write("Class Type: ");
                        trainclass.ClassType = Console.ReadLine();
                        Console.Write("Max Seats: ");
                        trainclass.MaxSeats = int.Parse(Console.ReadLine());
                        Console.Write("Available Seats: ");
                        trainclass.AvailableSeats = int.Parse(Console.ReadLine());
                        Console.Write("Cost Per Seat: ");
                        trainclass.CostPerSeat = decimal.Parse(Console.ReadLine());

                        bool add_status = trainclassdata.AddClassAvailability(trainclass);
                        if (add_status)
                        {
                            Console.WriteLine("Class Availability Successfully Added....");
                        }
                        else
                        {
                            Console.WriteLine("Failed! to add the Class Availability!!..");
                        }
                        break;

                    case 3:

                        Console.WriteLine("Enter Train Id To Update Seats: ");
                        int trainId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Class Type : ");
                        string classtype = Console.ReadLine();
                        Console.WriteLine("Enter No of Seats to Update : ");
                        int seatupdate = Convert.ToInt32(Console.ReadLine());
                        bool status = trainclassdata.RestoreSeats(trainId, classtype, seatupdate);
                        if (status)
                        {
                            Console.Write("Updated Successfully....");
                        }
                        else
                        {
                            Console.WriteLine("Failed! to Update or It is more than maximum Seats.");
                        }
                        break;

                    case 4:

                        Console.WriteLine("****************All Available Trains*************");
                        var trains = traindata.ViewAllTrains();
                        foreach (var t in trains)
                        {
                            Console.WriteLine("---------------------------------------------------------");
                            Console.WriteLine(
                                $"Train Id            : {t.TrainID},\n" +
                                $"Train No            : {t.TrainNumber}, \n" +
                                $"Train Name          : {t.TrainName},\n" +
                                $"Source Station      : {t.SourceStation}, \n" +
                                $"Destination Station : {t.DestinationStation}, \n" +
                                $"Departure Time      : {t.DepartureTime}, \n" +
                                $"Arrival Time        : {t.ArrivalTime}, \n" +
                                $"Duration            : {t.Duration}, \n" +
                                $"Total Seats         : {t.TotalSeats}, \n" +
                                $"Fare                : {t.Fare}, \n" +
                                $"Train Type          : {t.TrainType}, \n" +
                                $"Status              : {t.Status}\n");
                        }
                        break;

                    case 5:
                        Console.WriteLine("Enter Train id to delete : ");
                        int trainid = Convert.ToInt32(Console.ReadLine());
                        if (traindata.DeleteTrain(trainid))
                        {
                            Console.WriteLine("The Train Deleted Successfully....");
                        }
                        else
                        {
                            Console.WriteLine("Error while deleting the Train.");
                        }
                        break;
                    case 6:
                        Console.WriteLine("Exiting......");
                        run = false;
                        break;

                }
            }
        }
    }
}
