using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class RuleEast : Rule
{
    override public bool Match(WorldData worldState)
    {
        rulePriority = RuleFrameWork.RulePriorityType.PRIORITY1;
        if (worldState.RightFree  & !worldState.RightVisited)
        {
            if (worldState.RightFood)
            {
                rulePriority = RuleFrameWork.RulePriorityType.PRIORITY2;
            }
            if (worldState.RightPowerUp)
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
        nextChoice.NextMove = NextMovementChoice.NextMoveType.MOVE_EAST;
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
