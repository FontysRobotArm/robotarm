/*********************************************************************
 * Software License Agreement (BSD License)
 *
 *  Copyright (c) 2012-15, Commonplace Robotics GmbH
 *  http://www.commonplacerobotics.com
 *  All rights reserved.
 *
 *  Redistribution and use in source and binary forms, with or without
 *  modification, are permitted provided that the following conditions
 *  are met:
 *
 *   * Redistributions of source code must retain the above copyright
 *     notice, this list of conditions and the following disclaimer.
 *   * Redistributions in binary form must reproduce the above
 *     copyright notice, this list of conditions and the following
 *     disclaimer in the documentation and/or other materials provided
 *     with the distribution.
 *   * Neither the name Commonplace Robotics nor the names of its
 *     contributors may be used to endorse or promote products derived
 *     from this software without specific prior written permission.
 *
 *  THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
 *  "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
 *  LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
 *  FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE
 *  COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT,
 *  INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
 *  BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
 *  LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
 *  CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
 *  LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN
 *  ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
 *  POSSIBILITY OF SUCH DAMAGE.
 *********************************************************************/

using Multimedia;       // necessary for high precision timer

namespace MoverDemo
{
    class RobotControlLoop
    {
        private Multimedia.Timer robotMainLoop;
        private double cycleTime = 50;                          // the robot main loop runs with 20 Hz

        private double[] jogValues = new double[6];             // the commanded velocities from 0.0 to 100.0
        private double robOverride = 30.0;                      // from 0 to 100, scales the movion velocity
        private double[] jointsSetPoint = new double[6];        // The joint set point values in degree 
        private double[] jointsCurrent = new double[6];         // the current joint positions in degree, loaded from the robot arm
        private int[] errorCodes = new int[6];                  // the error state of each joint module
        private bool[] dout = new bool[6];                      // the wanted digital out channels
        private bool[] din = new bool[4];                       // the current digital in channels
        public HardwareInterface hwInterface;                   // the USB adapter interface


        //************* Constructor *********************************
        public RobotControlLoop()
        {
            for (int i = 0; i < 6; i++)
            {
                errorCodes[i] = 15;
                dout[i] = false;
            }

            for (int i = 0; i < 4; i++)
            {
                din[i] = false;
            }

            hwInterface = new HardwareInterface();

            // start the main loop
            TimerCaps caps = Multimedia.Timer.Capabilities;     //this step is not nessesary 
            this.robotMainLoop = new Multimedia.Timer();        //create a timer
            this.robotMainLoop.Tick += new System.EventHandler(this.LoopMain);      //assign a timer to LoopMain so the robotMainLoop runs on this timer
            this.robotMainLoop.Mode = TimerMode.Periodic;       //let the timer run indefinitely until it is explicitly stopt 
            this.robotMainLoop.Period = (int)cycleTime;         //sets the timer to 50 ticks (runs the code 20 times per second)
            this.robotMainLoop.Resolution = 1;                  //sets the accuracy of the timer to 1 millisecond

            this.robotMainLoop.Start();                        //starts the timer
        }



        //********************* Main Control Loop ***************************************************************************


        // This is the 20Hz robot main loop, called by the multimedia-timer.
        // In this loop we generate new joint set point values and forward them to the hardware interface
        public void LoopMain(object sender, System.EventArgs ev)
        {
            double jointMaxVelocity = 20.0;         // degree / sec         //sets the maximum velocity of the the joints in degrees to 20 per second
            int[] tmpDIn = new int[6];

            lock (this) //lock incapsulated the values to ensure that multiple threads do not try to access the same resources at the same time and cause a crash.
            {

                //jogValues: how much the joint schould move
                //robOverride: how much the user wants to scale the jog values
                //cycleTime: how much time has passed since the last update
                //jointMaxVelocity: how fast the joint can move

                // Generate new joint setpoints based on the old ones, the jog values and the override
                for (int i = 0; i < 6; i++)
                {
                    jointsSetPoint[i] += (jogValues[i] / 100.0) * (robOverride / 100.0) * (cycleTime / 1000.0) * jointMaxVelocity;       // vel ist in °/s
                }

                // Forward the set point values to the hardware interface. This writes the values to the CAN field bus
                hwInterface.WriteJointSetPoints(jointsSetPoint, ref jointsCurrent, ref errorCodes, ref tmpDIn);

                // The digital input values are coded in one int per joint. Each bit represents an input channel.
                // For the Mover4 and Mover6 robots only the first joint provides connected digital inputs
                //tmpDin recieves the digital inputs form the arm. These are then passed through an error value (0x01...0x08) and placed in the din array
                if((tmpDIn[0] & 0x01) == 0x01) din[0] = true; else din[0] = false;
                if ((tmpDIn[0] & 0x02) == 0x02) din[1] = true; else din[1] = false;
                if ((tmpDIn[0] & 0x04) == 0x04) din[2] = true; else din[2] = false;
                if ((tmpDIn[0] & 0x08) == 0x08) din[3] = true; else din[3] = false;
            }
        }


        //***************************************************************


        // Copies the current hardware position into the setpoint values and then resets the joint modules
        // Error code afterwards is 0x04 motor not enabled. To move the robot arm the motors have to be enabled.
        public void ResetJoints()
        {
            lock (this)
            {
                 // first copy the hardware positions to the setpoint positions for all 6 joints
                for (int i = 0; i < 6; i++)
                    jointsSetPoint[i] = jointsCurrent[i];

                // then reset the joints to state 0x04
                hwInterface.ResetErrors();
            }
        }


        //***************************************************************
        /// <summary>
        /// Override from 0 to 100
        /// </summary>
        
        //changes the override value
        public void SetOverride(double ovr)
        {
            lock (this)
            {
                robOverride = ovr;
            }
        }
        //***************************************************************

        //should have used {get}
        public double GetOverride()
        {
                return robOverride; 
        }

        //***************************************************************
        /// <summary>
        /// Six jog values from -100 to 100
        /// </summary>
        
        //sets the values of where the joint should move to
        public void SetJogValues(double[] jv)
        {
            lock (this)
            {
                for (int i = 0; i < 6; i++)
                    jogValues[i] = jv[i];
            }
        }

        //**************************************************************
        /// <summary>
        /// Provides the joint values in degree, each six values
        /// </summary>
        /// <param name="jSetPoint">Set point values</param>
        /// <param name="jCurrent">Current hardware values</param>
        /// <param name="errorCodes">Joint error codes</param>

        //returns the current setpoint, the current position and the current errorcode of the robotic arm
        //by using ref the values are returned as parameters therefore the object state does not need to be accesed directly this makes it faster
        public void GetJointValues(ref double[] jSetPoint, ref double[] jCurrent, ref int[] errorCodes)
        {
            for (int i = 0; i < 6; i++)
            {
                jSetPoint[i] = this.jointsSetPoint[i];
                jCurrent[i] = this.jointsCurrent[i];
                errorCodes[i] = this.errorCodes[i];
            }
        }

        //***************************************************************
        /// <summary>
        /// Get the digital input values
        /// Returns an array of four bool values 
        /// </summary>
        /// <returns></returns>
       

        //returns the din values
        public bool[] GetDigitalIn()
        {
            return din;
        }

        //***************************************************************
        /// <summary>
        /// Sets the digital outputs in the base joint, or the TCP module
        /// </summary>
        /// <param name="dOutParameter">Array of six bool values</param>
        
        //sends the values over the USB device (hwInterface) to the robotic arm
        public void SetDigitalOut(bool[] dOutParameter)
        {
            for(int i=0; i<6; i++){
                if(dout[i] != dOutParameter[i]){
                    dout[i] = dOutParameter[i];

                    switch(i){
                        case 0: hwInterface.SetDigitalOut(0, 0, dout[i]); break;     // The base D-Out are found in the first module
                        case 1: hwInterface.SetDigitalOut(0, 1, dout[i]); break;
                        case 2: hwInterface.SetDigitalOut(0, 2, dout[i]); break;
                        case 3: hwInterface.SetDigitalOut(0, 3, dout[i]); break;
                        case 4: hwInterface.SetDigitalOut(3, 0, dout[i]); break;     // The TCP D-Out are found in module 4
                        case 5: hwInterface.SetDigitalOut(3, 1, dout[i]); break;
                    }
                }  //endofif
            } //endoffor
        }



    }
}
