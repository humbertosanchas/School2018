using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class RuleStuck : Rule
{

    List<NextMovementChoice.NextMoveType> backTrackMoves = new List<NextMovementChoice.NextMoveType>();    


    override public bool Match(WorldData worldState)
    {
        //if nowhere to move that is unvisited add all visited but open space to a list
        if ((!worldState.TopFree || worldState.TopVisited) && (!worldState.RightFree || worldState.RightVisited) && (!worldState.BottomFree || worldState.BottomVisited) && (!worldState.LeftFree || worldState.LeftVisited))
        {
            if(worldState.TopFree && worldState.TopVisited)
            {
                backTrackMoves.Add(NextMovementChoice.NextMoveType.MOVE_NORTH);
            }
            if(worldState.RightFree && worldState.RightVisited)
            {
                backTrackMoves.Add(NextMovementChoice.NextMoveType.MOVE_EAST);
            }
            if (worldState.BottomFree && worldState.BottomVisited)
            {
                backTrackMoves.Add(NextMovementChoice.NextMoveType.MOVE_SOUTH);
            }
            if (worldState.LeftFree && worldState.LeftVisited)
            {
                backTrackMoves.Add(NextMovementChoice.NextMoveType.MOVE_WEST);
            }
            return true;
        }
        return false;
    }

    override public NextMovementChoice Execute()
    {   
        //randomy choose a open but visited direction
        NextMovementChoice nextChoice = new NextMovementChoice();
        Random rand = new Random();
        int r = rand.Next(0, backTrackMoves.Count);
        nextChoice.NextMove = backTrackMoves[r];
        backTrackMoves.Clear();
        
        return nextChoice;
    }

    public override void InitializeRule()
    {
        rulePriority = RuleFrameWork.RulePriorityType.PRIORITY1;
    }

    public override void CleanUpRule()
    {
        backTrackMoves = new List<NextMovementChoice.NextMoveType>();
        rulePriority = RuleFrameWork.RulePriorityType.NONE;

    }
}
