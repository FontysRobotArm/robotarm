## TwinCAT 3 TCP/IP Client

- [ ] String splitting
- [ ] Send history
- [ ] History visibility

- Commands to send
 For joint control (only that one works)
 'CRISTART 1626 CMD MotionTypeJoint CRIEND'
 
 - [x] Alive messages denote the movement of the robot for joint-base
 0 means no movement, -100.0 to 100.0 means movement, the higher the value, the faster the movement ig, 9 numbers, space separated

 - [x] Send alive message every 100ms instead of every 1 sec

 - [ ] Get current robot position (somehow) (like in the igus ui) (forward kinematics)

 - [ ] Figure out how to calculate position