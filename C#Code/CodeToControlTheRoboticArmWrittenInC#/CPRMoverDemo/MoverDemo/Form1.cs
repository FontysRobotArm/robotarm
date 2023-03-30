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

// CPR Mover Demo
// Windows C# Source code to show how to connect and move the Commonplace Robotics Mover4 and Mover6 robot arms
// Requirements: Mover4/6 with PCAN-USB adapter, Windows 7 or higher, VisualStudio Express 2012 or another C# IDE
//
// Version 1.0: April 09th, 2015  -  Changes: First full release. Added DIO functionality, added comments, removed timing problems for Mover6
// Version 0.9: April 08th, 2015  -  Pre-Release
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoverDemo
{


    /// <summary>
    /// Main form with interaction elements
    /// ATTENTION: this code is meant to be a minimalistic demo how to move the Commonplace Robotics Mover4 and Mover6 robot arms
    /// Functionality that is not necessary, but that increases reliability or user friendliness, has not been implemented to keep the code simple
    /// Error handling, logging and user guidance has to be improved when using the software in real world applications, this is up to the user.
    /// </summary>
    public partial class Form1 : Form
    {
        RobotControlLoop robotLoop;
        int activeJoint = 0;
        double[] jogValues = new double[6];
        
        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < 6; i++)
                jogValues[i] = 0.0;

            // This is the robot main loop, decoupled from the GUI to provide a more stable communication
            robotLoop = new RobotControlLoop();
            labelOverride.Text = robotLoop.GetOverride().ToString() + "%";

            timer1.Interval = 100;      // this timer cares about the GUI
            timer1.Enabled = true;
        }


        //*************************************************************
        /// <summary>
        /// Updating of the GUI elements
        /// </summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            double[] jsp = new double[6];
            double[] jcurr = new double[6];
            int[] jerr = new int[6];
            robotLoop.GetJointValues(ref jsp, ref jcurr, ref jerr);

            string sSetPoint = "Joints Set Point: ";
            string sCurrent = "Joints Current: ";
            string sErr = "Joints Error States: ";
            for (int i = 0; i < 6; i++)
            {
                sSetPoint = sSetPoint +  jsp[i].ToString("0.0") + "  ";
                sCurrent = sCurrent + jcurr[i].ToString("0.0") + "  ";
                sErr = sErr + "0x" + jerr[i].ToString("X2") + "  ";
            }
            labelJointsSetPoint.Text = sSetPoint;
            labelJointsCurrent.Text = sCurrent;
            labelErrorCodes.Text = sErr;

            if (robotLoop.hwInterface.flagConnected)
                labelStatus.Text = "Status: connected";
            else
                labelStatus.Text = "Status: not connected";


            bool[] din = new bool[6];
            din = robotLoop.GetDigitalIn();
            checkBoxInBase1.Checked = din[0];
            checkBoxInBase2.Checked = din[1];
            checkBoxInBase3.Checked = din[2];
            checkBoxInBase4.Checked = din[3];

        }



        //***************** REGION HARDWARE ******************************************
        #region Hardware

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            robotLoop.hwInterface.Connect();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            robotLoop.ResetJoints();
        }

        private void buttonEnable_Click(object sender, EventArgs e)
        {
            robotLoop.hwInterface.EnableMotors();
        }

        private void buttonSetJointsToZero_Click(object sender, EventArgs e)
        {
            robotLoop.ResetJoints();            // also disables the motors to avoid unwanted motion
            System.Threading.Thread.Sleep(5);
            robotLoop.hwInterface.SetJointsToZero();        // set all joints to zero
            System.Threading.Thread.Sleep(5);
            robotLoop.ResetJoints();        
        }

        #endregion




        //***************** REGION JointMotion ******************************************
        #region JointMotion
                
        /// <summary>
        /// The Jog values are set from the time the mouse button is pressed until it is lifted again
        /// </summary>
        private void buttonJog_MouseDown(object sender, MouseEventArgs e)
        {
            string txt = ((Button)sender).Text;
            if(txt == "Jog Plus")
                jogValues[activeJoint] = 50.0;
            else if (txt == "Jog Minus")
                jogValues[activeJoint] = -50.0;
            robotLoop.SetJogValues(jogValues);
        }

        private void buttonJog_MouseUp(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < 6; i++)
                jogValues[i] = 0.0;
            robotLoop.SetJogValues(jogValues);
        }


        private void buttonOvrMinus_Click(object sender, EventArgs e)
        {
            double ovr = robotLoop.GetOverride();
            ovr -= 10.0;
            if (ovr < 0.0)
                ovr = 0.0;
            robotLoop.SetOverride(ovr);
            labelOverride.Text = ovr.ToString() + "%";
        }

        private void buttonOvrPlus_Click(object sender, EventArgs e)
        {
            double ovr = robotLoop.GetOverride();
            ovr += 10.0;
            if (ovr > 100.0)
                ovr = 100.0;
            robotLoop.SetOverride(ovr);
            labelOverride.Text = ovr.ToString() + "%";

        }

        private void comboBoxJoints_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBoxJoints.SelectedIndex;
            activeJoint = index;
        }

        #endregion




        //***************** REGION Digital IO ******************************************
        #region DigitalIO
        
        private void checkBoxOut_CheckedChanged(object sender, EventArgs e)
        {
            bool[] dOutState = new bool[6];
            dOutState[0] = checkBoxOutBase1.Checked;
            dOutState[1] = checkBoxOutBase2.Checked;
            dOutState[2] = checkBoxOutBase3.Checked;
            dOutState[3] = checkBoxOutBase4.Checked;
            dOutState[4] = checkBoxOutTCP1.Checked;
            dOutState[5] = checkBoxOutTCP2.Checked;

            robotLoop.SetDigitalOut(dOutState);
        }
        #endregion










    }
}
