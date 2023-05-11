# Important notes and points from the documentation and source code from the previous group

By Dimitar Dyulgerov

---

## Notes from docs:

Research Simulation ver1
- Robot arm uses ADS communication protocol (PLC <-> Arm)
- Previous group decided to use Unity for simulation in order to use one communication line
    - Implements ADS
    - Has models
    - Twinning support
    - Documentation

---

## Notes from CPR C# App

Jog position = Target position
PCAN = CANopen API
Robot used: Mover6

Position data is sent in intervals of 20Hz (every 50ms)

<br>

- CANopen message (sending)
    - Length
    - Type (of predefined enum, see c# code, standard == 0x00)
    - Id
    - Data (byte array with 8 elements)
    - Data[0] - determine the command
    - Data[1] - velocity
    - Data[2] - set position HIGH byte
    - Data[3] - set position LOW byte
    - Data[4] - timestamp (remember, 8 bits)
    
<br>

- CANopen message (answer)
    - Id
    - Data[0] - error code
    - Data[2] - current position HIGH byte
    - Data[3] - current position LOW byte
    - Data[7] - digitalIn (?)

<br>

- Joint data sending
    - Data is sent every 20Hz (50ms), aka every LoopMain call inside RobotControlLoop.
    - On mouse DOWN on the JOG Plus/Minus button, the jog value for the currently selected joint is set to a hardcoded value of 50.00/-50.00 respectively anda  setpoint is calculated based on it. That moves the joint in the desired direction.
    - On mouse UP on the JOG Plus/Minus button, the jog value for the currently selected joint is set to 0.00. The setpoint is calculated (results in 0). That stops the joint from moving (0 setpoint) 

### Fixes
- Fixed pressing the connect button after already being connected resulting in an error

## PCAN-USB UserMan

- [PCAN Driver and PCAN Viewer](http://www.peak-system.com/quick/DL-Driver-E)

- [Libraries and example code for PCAN API](www.peak-system.com/quick/DL-Develop-E)


## CANopen

[CANopen Introduction](https://www.ni.com/nl-nl/innovations/white-papers/13/the-basics-of-canopen.html)

CANopen is a communication protocol, interface, a standard

It uses CAN in the datalink and physical layers. The rest is CANopen.

Object dictionary - the way devices can be communicated with. It stores information about the object. Some indexes are required and need to be present, such as device name.

Each object has a server that allows r/w operations to the object dictionary.

SDO (Service Data Object) - the thing that provides direct access to the server's  object dictionary

SDO server - the object whose data is accessed<br>
SDO client - the object that grabs the data<br>
Transfer is started by client

PDO (Process Data Object) - the data object, the data that is actually transmitted

The arm uses Event driven CAN, therefore if a message does not arrive in time, a watchdog is triggered and an error state is engaged.
- Maybe Synchronized CANopen communication can be used, so as to send the SYNC telegram and avoid the error state?


You receive the response from the previous message when you send a new message.

[Bosch CANopen article](https://infosys.beckhoff.com/english.php?content=../content/1033/tcsystemmanager/1092789003.html&id=7873477876248720016)

[CANopen/EL6751 documentation](https://infosys.beckhoff.com/english.php?content=../content/1033/el6751/2519193099.html&id=6820221820248492542)

[CANopen messages over ADS](https://infosys.beckhoff.com/english.php?content=../content/1033/el6751/5222346763.html&id=)

## 08.05.2023

- Decided that CANopen cannot be used with the robot in the current project
- Research on CRI
    - CRI commands exploration
    - Using C# CRI interface provided by CPR (manufacturers of the robot arm)
    - Using the C# CRI interface in combination with the Digital twin to simulate the commands
    - Possibly use Monarco as a bridge between the robot and the Beckhoff PLC