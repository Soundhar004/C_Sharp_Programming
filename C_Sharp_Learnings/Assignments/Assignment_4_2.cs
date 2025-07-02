using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Learnings.Assignments
{
    // Step 1: Define the delegate
    public delegate void RingEventHandler();

    // Step 2: MobilePhone class
    class MobilePhone
    {
        public event RingEventHandler OnRing;

        public void ReceiveCall()
        {
            Console.WriteLine("📞Incoming call...");
            OnRing?.Invoke(); // Trigger the event
        }
    }

    // Step 3: Subscriber classes
    class RingtonePlayer
    {
        public void PlayRingtone()
        {
            Console.WriteLine("🔊 Playing ringtone...");
        }
    }

    class ScreenDisplay
    {
        public void ShowCallerInfo()
        {
            Console.WriteLine("📺 Displaying caller information...");
        }
    }

    class VibrationMotor
    {
        public void Vibrate()
        {
            Console.WriteLine("📳 Phone is vibrating...");
        }
    }

    // Step 4: Main method
    class Assignment_4_2
    {
        static void Main(string[] args)
        {
            // Create instances
            MobilePhone phone = new MobilePhone();
            RingtonePlayer ringtone = new RingtonePlayer();
            ScreenDisplay screen = new ScreenDisplay();
            VibrationMotor motor = new VibrationMotor();

            // Subscribe to the OnRing event
            phone.OnRing += ringtone.PlayRingtone;
            phone.OnRing += screen.ShowCallerInfo;
            phone.OnRing += motor.Vibrate;

            // Simulate an incoming call
            phone.ReceiveCall();
            Console.Read();
        }
    }
}
