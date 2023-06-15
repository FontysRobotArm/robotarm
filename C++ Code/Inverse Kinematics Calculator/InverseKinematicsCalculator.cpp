#include <iostream>
#include <math.h>
#include <tuple>

#define CM *10 MM
#define MM *1
#define PI 3.141592653589793238463
#define POW2(number) ((number) * (number)) 

//All values are in MM
const double PICKUP_AREA_DEPTH = 50.0 CM;  //x
const double PICKUP_AREA_WIDTH = 50.0 CM;  //z
const double PICKUP_AREA_HEIGHT = 30.0 CM;  //y //Not needed

//const double DISTANCE_TO_PICKUP_AREA = 90.0 MM;
const double DISTANCE_TO_PICKUP_AREA = 0.0 MM;
const double ARM_BASE_HEIGHT = 310 MM;
const double GRABBER_HEIGHT = 0.0 MM;
const double ARM_1_LENGTH = 340.0 MM;
const double ARM_2_LENGTH = 265.0 MM;
const double ARM_3_LENGTH = 170.0 MM;

//PlainOldData
struct Position
{
    double x = 0.0; //depth
    double z = 0.0; //width
    double y = 0.0; //height

    Position() = default;
    Position(double x, double z, double y)
    {
        this->x = x;
        this->z = z;
        this->y = y;
    }
};

double RadiansToDegrees(double radians)
{
    return radians * 180 / PI;
}

// Tested, works
/// @brief Calculates an angle in a right triangle based on the 2 non-hypotenuse sides
/// @param opposite the side opposite the angle
/// @param adjacent the side next to the angle (not hypotenuse)
/// @return The angle, in degrees
double GetAngleDegreesFromOppositeAndAdjacent(double opposite, double adjacent)
{
    double tangentFraction = opposite / adjacent;
    double targetAngleRadians = atan(tangentFraction);  //No need to worry about which quadrant we are in, as we are working with a right-angle triangle so we can only be in the first one
    double targetAngleDegrees = RadiansToDegrees(targetAngleRadians);

    return targetAngleDegrees;
}

//Tested, works
/// @brief Gets the angle to which the base has to rotate. Negative value to rotate left, positive value to rotate right
/// @param position The target position
/// @return The required angle of rotation
double GetBaseAngleDegrees(Position position)
{
    double xSide = DISTANCE_TO_PICKUP_AREA + position.x;
    
    double halfAreaWidth = PICKUP_AREA_WIDTH / 2;
    double zSide = 0.0;
    double angleOffset = 1.0;   //-1 for left, +1 for right
    if (position.z < halfAreaWidth)
    {
        //Point on the left side of the robot
        zSide = halfAreaWidth - position.z;
        angleOffset = -1.0;
    }
    else
    {
        //Point on the right side of the robot
        zSide = position.z - halfAreaWidth;
        angleOffset = 1.0;
    }
 
    double targetAngleDegrees = GetAngleDegreesFromOppositeAndAdjacent(zSide, xSide);

    return targetAngleDegrees * angleOffset;
}

double GetXSide(double xPos)
{
    return DISTANCE_TO_PICKUP_AREA + xPos;
}

double GetZSide(double zPos)
{
    double zSide = 0.0;
    double halfAreaWidth = PICKUP_AREA_WIDTH / 2;

    if (zPos < halfAreaWidth)
    {
        //Point on the left side of the robot
        zSide = halfAreaWidth - zPos;
    }
    else
    {
        //Point on the right side of the robot
        zSide = zPos - halfAreaWidth;
    }

    return zSide;
}

double GetHypotenuse(double a, double b)
{
    double resultSquared = POW2(a) + POW2(b);
    return sqrt(resultSquared);
}

double GetDistanceToPositionFromBase2D(Position position)
{
    double xSide = GetXSide(position.x);
    double zSide = GetZSide(position.z);

    //Not fast, too bad
    double result = GetHypotenuse(xSide, zSide);
    return result;
}

double GetAngleDegreesFrom3Sides(double adjacentLeft, double opposite, double adjacentRight)
{
    //Cosine formula
    double cosTargetAngle = (POW2(adjacentLeft) + POW2(adjacentRight) - POW2(opposite)) / (2 * adjacentLeft * adjacentRight);

    double targetAngleRadians = acos(cosTargetAngle);
    double targetAngleDegrees = RadiansToDegrees(targetAngleRadians);

    return targetAngleDegrees;
}

std::tuple<double, double> GetArm1AndArm2Degrees(Position position)
{
    //TODO: Double check actualY, robot does not go low enough
    //Take into account the elevation of the first arm and the lenght of the last one, where the grabber is attached, and the grabber
    double actualY = position.y - ARM_BASE_HEIGHT + ARM_3_LENGTH + GRABBER_HEIGHT;

    if (actualY < 0)
    {
        //Cannot go below 0 (for now)
        return {0.0, 0.0};
    }

    double oppositeSide = actualY;
    double adjacentSide = GetDistanceToPositionFromBase2D(position);

    double angleDegreesFromBaseToActualY = GetAngleDegreesFromOppositeAndAdjacent(oppositeSide, adjacentSide);

    double baseTriangleHypotenuse = GetHypotenuse(oppositeSide, adjacentSide);

    double armTriangleBase = baseTriangleHypotenuse;
    double armTriangleA = ARM_1_LENGTH;
    double armTriangleB = ARM_2_LENGTH;

    double arm1AngleDegreesRelativeToBaseTriangle = GetAngleDegreesFrom3Sides(armTriangleA, armTriangleB, armTriangleBase);

    double arm1AbsoluteDegrees = (angleDegreesFromBaseToActualY + arm1AngleDegreesRelativeToBaseTriangle) - 90.0;   //Shouldn't be less than 0

    //Arm 2 calculations
    double arm2DegreesRelativeArm1 = GetAngleDegreesFrom3Sides(armTriangleB, armTriangleBase, armTriangleA);

    double arm2AbsoluteDegrees = arm2DegreesRelativeArm1 - 90; //The arm is considered at 0 degrees absolute when perpendicular to arm 1. Negative values indicate movement TOWARDS the base, positive values indicate movement AWAY from the base
    
    return {arm1AbsoluteDegrees, arm2AbsoluteDegrees};
}

double GetArm3RotationPerpendicularToGround(double arm1AbsoluteRotationDegrees, double arm2AbsoluteRotationDegrees)
{
    return -1.0 * (arm1AbsoluteRotationDegrees + arm2AbsoluteRotationDegrees);
}

int main(int argc, char** argv)
{
    //TODO: Check position validity in functions/before passing them around
    Position targetPosition = Position(25 CM, 25 CM, 20 CM);
    
    auto [arm1Degrees, arm2Degrees] = GetArm1AndArm2Degrees(targetPosition);
    double arm3Degrees = GetArm3RotationPerpendicularToGround(arm1Degrees, arm2Degrees);

    std::cout << "Base: " << GetBaseAngleDegrees(targetPosition) << '\370' << std::endl;
    std::cout << "Arm 1: " << arm1Degrees << '\370' << std::endl;
    std::cout << "Arm 2: " << arm2Degrees << '\370' << std::endl;
    std::cout << "Arm 3: " << arm3Degrees << '\370' << std::endl;

    return 0;
}