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

