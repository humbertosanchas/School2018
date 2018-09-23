using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class RuleNorth : Rule
{
    override public bool Match(WorldData worldState)
    {
        if(worldState.TopFree && !worldState.TopVisited)
        {
            if (worldState.TopFood)
            {
                rulePriority = RuleFrameWork.RulePriorityType.PRIORITY2;
            }
            if (worldState.TopPowerUp)
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
        nextChoice.NextMove = NextMovementChoice.NextMoveType.MOVE_NORTH;        
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
