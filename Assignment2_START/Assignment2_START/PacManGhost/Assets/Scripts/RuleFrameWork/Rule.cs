//
//Rule.cs
//Base class for the RuleBasedSystem
//
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

abstract public class Rule {

	public RuleFrameWork.RulePriorityType rulePriority;
	
	abstract public bool Match(WorldData worldState);
	
	abstract public NextMovementChoice Execute();
	
	public virtual void InitializeRule()
	{
		rulePriority = RuleFrameWork.RulePriorityType.NONE;
	}
	
	public virtual void CleanUpRule()
	{
	}
	
}
