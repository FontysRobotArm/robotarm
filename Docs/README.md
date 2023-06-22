# User manual

## 1. Setting up the arm controller in TwinCAT 3

---

### 1.1 Connection

1. Go into MAIN
2. Make sure the communication mode is set to COM_MODE.Robot: 
    ``` MessageBase : COMMUNICATION(CommunicationMODE := COM_MODE.Robot); ```  
    
    - <i>Note: The ip and port in the client constructor are overwritten when the connectTrigger is triggered. (See: ```MAIN.HandleUI() ```)</i>

3. Upload, proceed with download

4. Go into the visualization: ```VISUs/VisualizationControlPanel```

5. Log in and run the program (Green login button, followed by the green play button)

6. Press the Connect button

7. Wait for the connection status to change to 'Connected'

---

### 1.2 Manual Control

<b>IMPORTANT:</b> Make sure the emergency stop button is nearby whenever the robot is moving

1. Connect to the robot arm (<i>see: [Connection](#11-connection)</i>)

2. Press 'Connect to robot' button

3. Press "Enable motors"
    - You should hear a clicking sound the <strong>first</strong> time that you press the button.

4. Control the robot with the buttons to the right:
    - 'Send' Provides a dummy target location
    - 'To Idle Position' Sets the robot to its idle position <b> if the robot was previous moved with the buttons in the current session (without resetting the program) </b> 
    - J0 = base
    - J1 = arm 1
    - J2 = arm 2
    - J3 = arm 3

5. 'Stop button' behaviour
    - Does <b> NOT </b> turn off the motors
    - Sets movement variables to 0

### 1.3 UI Description

1. Server message box
    - Displays the latest message received from the server/robot

2. Messages received message box
    - Displays the number of messages received since last cold restart of the program
    - <i>Note: cold restart = reset all variables and the program to its inital state</i>

3. Receive history table
    - Displays the 9 latest messages received from the server.
    
    
