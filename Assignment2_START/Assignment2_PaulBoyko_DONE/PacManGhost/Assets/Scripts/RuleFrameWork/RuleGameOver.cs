using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class RuleGameOver : Rule
{
    override public bool Match(WorldData worldState)
    {
        //retunr true is all food gone
        if(worldState.TotalFoodAvailable == 0)
        {
            return true;
        }    
        return false;
    }

    override public NextMovementChoice Execute()
    {
        NextMovementChoice nextChoice = new NextMovementChoice();
        nextChoice.NextMove = NextMovementChoice.NextMoveType.MOVE_TYPE_MAX;
        //return highes priority to tell game game over
        return nextChoice;
    }

    public override void InitializeRule()
    {
        rulePriority = RuleFrameWork.RulePriorityType.PRIORITY_MAX;
    }

    public override void CleanUpRule()
    {

    }
}
