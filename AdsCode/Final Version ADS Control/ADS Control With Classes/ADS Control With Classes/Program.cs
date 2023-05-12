using ADS_Control_With_Classes;

namespace TwinCAT.Ads
{
    class Program
    {
        public static void Main()
        {
            RobotArmController armcontroller = new RobotArmController("172.25.16.1.1.1");

            if(armcontroller.GetCurrentArmSpeed() == 0) 
            {
                armcontroller.ChangeArmSpeed(50);
            }
            else 
            {
                armcontroller.ChangeArmSpeed(0);
            }

            if(armcontroller.GetCurrentArmLocation() == 0)
            {
                armcontroller.MoveArmToPosition(50);
            }
            else
            {
                armcontroller.MoveArmToPosition(0);
            }

            armcontroller.Dispose();
        }
    }
}
