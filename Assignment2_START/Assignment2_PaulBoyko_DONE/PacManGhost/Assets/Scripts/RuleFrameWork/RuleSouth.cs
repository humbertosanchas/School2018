﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class RuleSouth : Rule
{
    override public bool Match(WorldData worldState)
    {
        rulePriority = RuleFrameWork.RulePriorityType.PRIORITY1;
        if (worldState.BottomFree  && !worldState.BottomVisited)
        {
            //food before empty space
            if (worldState.BottomFood)
            {
                rulePriority = RuleFrameWork.RulePriorityType.PRIORITY2;
            }
            if (worldState.BottomPowerUp)//power up first
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
        nextChoice.NextMove = NextMovementChoice.NextMoveType.MOVE_SOUTH;
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