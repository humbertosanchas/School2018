using UnityEngine;
using System.Collections;

public class RuleSlow : Rule
{

    override public bool Match(WorldData worldState)
    {
        bool bfoundMatch = false;
        if (worldState.TrafficState == TrafficLight.TrafficLightStateType.AMBER)
        {
            bfoundMatch = true;
        }

        return bfoundMatch;       
    }

    override public NextChoiceType Execute()
    {
        NextChoiceType nextChoice = new NextChoiceType();
        nextChoice.NextMove = NextChoiceType.NextMoveType.SLOW_DOWN;
        return nextChoice;
    }

    public override void InitializeRule()
    {
        base.InitializeRule(); //call base class initialize in case there is anything in there to initialze
        rulePriority = RuleFrameWork.RulePriortyType.PRIORITY2;
    }

    public RuleSlow()
    {
        InitializeRule();
    }
}
