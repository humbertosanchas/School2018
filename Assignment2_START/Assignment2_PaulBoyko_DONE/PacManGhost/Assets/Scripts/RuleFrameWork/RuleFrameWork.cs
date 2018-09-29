//
//RuleFrameWork
//Contains the rule base framework.
//
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class RuleFrameWork {


    public List<GameObject> ObjectsWithAI;
    //possible priorites:
	public enum RulePriorityType { 
									NO_INIT = -1,
									NONE = 0,
									PRIORITY1, 
									PRIORITY2,
									PRIORITY3, 
									PRIORITY4, 
									PRIORITY5,
									PRIORITY6,
                                    PRIORITY7,
                                    PRIORITY8,
                                    PRIORITY9,
                                    PRIORITY10,
                                    PRIORITY11,
                                    PRIORITY_MAX };
	
    //List to hold all possible rules 
	private List<Rule> Rules;
	
	public RuleFrameWork()
	{
		InitializeFrameWork();
	}
		
	
	private void InitializeFrameWork()
	{
		
		Rules = new List<Rule>();
		Rules.Add (new RuleDefault());
        //ADD YOUR NEW RULES HERE

        Rules.Add(new RuleNorth());
        Rules.Add(new RuleEast());
        Rules.Add(new RuleSouth());
        Rules.Add(new RuleWest());
        Rules.Add(new RuleStuck());
        Rules.Add(new RuleGameOver());

        foreach (Rule rule in Rules)
		{
			rule.InitializeRule();
		}
			
	}
	public NextMovementChoice RunAI_Evalute( WorldData worldState ) 
	{
		RulePriorityType highestRulePriority = RulePriorityType.NO_INIT;
		Rule highestMatchingRule = null;
		NextMovementChoice bestMove = null;
		
		worldState.DetermineOpenMoves( worldState.PlayerCurrentSpace  );
		
        //Check to see if any rules match the worldState, keep track of the one with highest priority
		foreach( Rule rule in Rules )
		{
			if(rule.Match(worldState))
			{
				if( rule.rulePriority > highestRulePriority )
				{
                    //highest priority aways take precident
					highestRulePriority = rule.rulePriority;
					highestMatchingRule = rule;
				}
                else if(rule.rulePriority == highestRulePriority)
                {
                    //if rule is equla priority randomly chose to keep it = 0 or skip it = 1)
                    var r = new System.Random();
                    int decider = r.Next(0, 2);
                    if(decider == 0)
                    {
                        highestRulePriority = rule.rulePriority;
                        highestMatchingRule = rule;
                    }                  
                }
			}
		}
				
		//Execute the rule with the highest priority
		if(highestMatchingRule != null)
		{
            //if there is async matching rule set best move to that
			bestMove = highestMatchingRule.Execute();
		}	
		//return the best rule
		return bestMove;	
	}
	
	public void CleanFrameWork()
	{
		Rules.Clear();
		foreach( Rule rule in Rules )
		{
			rule.CleanUpRule();
		}
	}	
}
