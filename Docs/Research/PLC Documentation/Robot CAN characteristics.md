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

## CAN message format (CPR-CAN-V2)

board-id - command - pos0 - pos1 - pos2 - pos3 - timeStamp - digitalout

### Messages regarding the joints

- Board Id (Joint id)
    - 0x10, 0x20, 0x30, 0x40, 0x50, 0x60
- Response Id (Command Id + 1)
    - 0x11, 0x21, 0x31, 0x41, 0x51, 0x61

### Useful commands
- Set position of joint - 0x14
- Set velocity of joint - 0x15

- Set Joint to 0        - 0x01 0x08
    - Has to have a length of 4
    - Has to be sent twice in the span of 50ms
    - PosH and PosL are 0x00 (bytes 3 and 4)

<strong>Length of the following messages has to be set to 2</strong>

- Reset error       - 0x01 0x06
- Enable motor      - 0x01 0x09
    - Also resets errors
- Disable motor     - 0x01 0x0A

## Important Error codes

Error codes are provided in the error byte in the CAN answer.
A bit is set per corresponding error. Multiple errors can occur, in which case multiple bits are set

- Motor not enabled - Bit 3 - 0000_0100
- Comm Watchdog     - Bit 4 - 0000_1000
    - No message received in the required timeframe
- Position lag      - Bit 5 - 0001_0000
    - Position too far away from current position
- CAN error -       - Bit 8 - 1000_0000

After a reset command, the error is 0x04 (motor not enabled). After enabling the motor, the error should be 0x00

## Drawbacks of using CAN instead of CRI (TCP/IP)
- CAN communication only supports joint-by-joint movement, which means that inverse kinematics have to be implemented to move the robot arm  in a cartesian way. CRI supports that natively.
