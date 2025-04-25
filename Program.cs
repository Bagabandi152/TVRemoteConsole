using System;
using System.IO.Ports;

namespace TVRemoteConsole
{
    class Program
    {
        static SerialPort port;

        static void Main(string[] args)
        {
            try
            {
                port = new SerialPort("COM3", 9600); // Change COM3 to your Arduino port
                port.Open();
                Console.WriteLine("Connected to Arduino on " + port.PortName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return;
            }

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nTV Remote Console");
                Console.WriteLine("1. Power");
                Console.WriteLine("2. Volume Up");
                Console.WriteLine("3. Volume Down");
                Console.WriteLine("4. Exit");
                Console.Write("Choose option: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        SendCommand("power");
                        break;
                    case "2":
                        SendCommand("volumeup");
                        break;
                    case "3":
                        SendCommand("volumedown");
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input.");
                        break;
                }
            }

            if (port.IsOpen)
                port.Close();

            Console.WriteLine("Disconnected. Press any key to exit.");
            Console.ReadKey();
        }

        static void SendCommand(string command)
        {
            if (port != null && port.IsOpen)
            {
                port.WriteLine(command);
                Console.WriteLine($"Sent: {command}");
            }
            else
            {
                Console.WriteLine("Serial port is not open.");
            }
        }
    }
}
