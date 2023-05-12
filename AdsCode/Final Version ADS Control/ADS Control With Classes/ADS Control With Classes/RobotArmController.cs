using TwinCAT.Ads;
using TwinCAT.Ads.TypeSystem;

namespace ADS_Control_With_Classes
{
    internal class RobotArmController
    {
        readonly private AdsClient client;

        //positionVariables
        readonly private uint positionVeriableHandle;
        readonly private string stringPositionVeriableHandle = "MAIN.position";

        //speedVariables
        readonly private uint speedVeriableHandle;
        readonly private string stringspeedVeriableHandle = "MAIN.speed";

        //shoud be used when we connect to PLC
        public RobotArmController(string targetAmsNetId)
        {
            client = new AdsClient();

            try
            {
                client.Connect(targetAmsNetId, 851);
                Console.WriteLine($"connected to {targetAmsNetId}");
            }

            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
          
            positionVeriableHandle = client.CreateVariableHandle(stringPositionVeriableHandle);
            speedVeriableHandle = client.CreateVariableHandle(stringspeedVeriableHandle);
        }

        //is for testing on local device should be removed later (AmsNetId is easier to use if the PLC is local)
        public RobotArmController(AmsNetId targetAmsNetId)
        {
            client = new AdsClient();
            client.Connect(targetAmsNetId, 851);

            Console.WriteLine($"connected to {targetAmsNetId}");

            positionVeriableHandle = client.CreateVariableHandle(stringPositionVeriableHandle);
            speedVeriableHandle = client.CreateVariableHandle(stringspeedVeriableHandle);
        }

        //is used to move the robot arm to a location. calculation of the position is done by unity
        public void MoveArmToPosition(uint position)
        {
            if(GetCurrentArmLocation() ==  position) 
            {
                Console.WriteLine("Robot is already at desired location");
                return;
            }

            Console.WriteLine($"Robot was at position: {client.ReadAny(positionVeriableHandle, typeof(int))}");

            client.WriteValue(stringPositionVeriableHandle, position);

            Console.WriteLine($"Robot Moved to position: {position}");
        }

        //is used to control the speed of the robot arm
        public void ChangeArmSpeed(uint speed)
        {
            if(GetCurrentArmSpeed() == speed)
            {
                Console.WriteLine("Robot is already at desired speed");
                return;
            }

            Console.WriteLine($"Robot had speed: {client.ReadAny(speedVeriableHandle, typeof(int))}");

            client.WriteValue(stringspeedVeriableHandle, speed);

            Console.WriteLine($"Robot now has speed: {speed}");
        }

        //is used to disconnect the current ams client
        public void Disconnect()
        {
            client.Disconnect();
        }

        //is used to delete the current ams client
        public void Dispose()
        {
            client.Dispose();
        }

        //schould be changed to a private function in the final version. Is now public for testing
        private dynamic GetCurrentArmLocation()
        {
            return client.ReadAny(positionVeriableHandle, typeof(int));
        }

        //should be changed to a private function in the final version. Is now public for testing
        private dynamic GetCurrentArmSpeed()
        {
            return client.ReadAny(speedVeriableHandle, typeof(int));
        }
    }
}