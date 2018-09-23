using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class RuleStuck : Rule
{

    List<NextMovementChoice.NextMoveType> backTrackMoves = new List<NextMovementChoice.NextMoveType>();

    override public bool Match(WorldData worldState)
    {
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
                backTrackMoves.Add(NextMovementChoice.NextMoveType.MOVE_EAST);
            }
            return true;
        }
        return false;
    }

    override public NextMovementChoice Execute()
    {
        NextMovementChoice nextChoice = new NextMovementChoice();
        Random rand = new Random();
        int r = rand.Next(0, backTrackMoves.Count - 1);
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
    }
}
