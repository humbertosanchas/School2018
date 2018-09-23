using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class RuleWest : Rule
{
    override public bool Match(WorldData worldState)
    {
        if (worldState.LeftFree && !worldState.LeftVisited)
        {
            if (worldState.LeftFood)
            {
                rulePriority = RuleFrameWork.RulePriorityType.PRIORITY2;
            }
            if (worldState.LeftPowerUp)
            {
                rulePriority = RuleFrameWork.RulePriorityType.PRIORITY3;
            }            
            return true;
        }
        return false;
    }

    override public NextMovementChoice Execute()
    {
        NextMovementChoice nextChoice = new NextMovementChoice();
        nextChoice.NextMove = NextMovementChoice.NextMoveType.MOVE_WEST;
        return nextChoice;
    }

    public override void InitializeRule()
    {
        rulePriority = RuleFrameWork.RulePriorityType.PRIORITY1;
    }

    public override void CleanUpRule()
    {
    }
}