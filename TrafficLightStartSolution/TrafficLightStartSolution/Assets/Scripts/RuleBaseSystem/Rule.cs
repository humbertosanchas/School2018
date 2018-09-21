using UnityEngine;
using System.Collections;
using System.Collections.Generic;

abstract public class Rule{
	
	public  RuleFrameWork.RulePriortyType rulePriority;
	//each rule will result in a move if there is a match for the rule ( there may be more than one move that matches the rule )
	
	//uses the moveboard to detect if the nextMove will match the rule
	abstract public  bool   Match(WorldData worldState);
	
	//finds the best move and returns it to the framwork a match might match more than one move
	//this execute will find the best one for the rule
	abstract public  NextChoiceType   Execute();
	
	// Use this for initialization
	public virtual void InitializeRule () 
	{
		rulePriority = RuleFrameWork.RulePriortyType.NONE;
	}
	
	public virtual void CleanRule() 
	{
		
	}
	
}
