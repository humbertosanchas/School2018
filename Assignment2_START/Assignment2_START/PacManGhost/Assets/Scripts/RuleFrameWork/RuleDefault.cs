//
//RuleDefault.cs
//This rule is the lowest in priority. It this rule is matched then the action for the AI is to do  nothing.
//
using UnityEngine;
using System.Collections;

public class RuleDefault : Rule {

	override public bool Match(WorldData worldState)
	{
		return true;
	}
	
	override public NextMovementChoice Execute()
	{
		NextMovementChoice nextChoice = new NextMovementChoice();
		nextChoice.NextMove = NextMovementChoice.NextMoveType.NONE;
		return nextChoice;
	}
	
	public override void InitializeRule()
	{
		
		rulePriority = RuleFrameWork.RulePriorityType.NONE;
	}
	
	public override void CleanUpRule()
	{
	}
}
