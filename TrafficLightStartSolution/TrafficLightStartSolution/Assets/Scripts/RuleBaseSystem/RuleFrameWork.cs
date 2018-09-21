using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RuleFrameWork {
	
	public enum RulePriortyType {NONE = 0, PRIORITY1, PRIORITY2, PRIORITY3, PRIORITY4, PRIORITY_MAX};
	
	private List<Rule> Rules;
	
	public RuleFrameWork()
	{
		InitializeFrameWork();
	}
	
	// Use this for initialization
	private void InitializeFrameWork () 
	{
        Rules = new List<Rule>();

        Rule go = new RuleGo();               
        Rule yield = new RuleSlow();        
        Rule stop = new RuleStop();
             

        Rules.Add(go);
        Rules.Add(yield);
        Rules.Add(stop);      
	}
	
	// Called each ai's turn, runs all the rules and finds the best rule that matches and executes that rule which gives 
	// the best move for that rule
	public NextChoiceType RunAI_Evalute( WorldData worldState ) 
	{
		RulePriortyType highestRulePriority = RulePriortyType.NONE;
		Rule highestMatchingRule = null;
		NextChoiceType bestMove = null;

        //Find Maching rules, keep track of the one with the highest priority
        foreach(var r in Rules)
        {
            if(r.Match(worldState) && r.rulePriority > highestRulePriority)
            {
                highestRulePriority = r.rulePriority;
                highestMatchingRule = r;
            }
        }

        //Execute the rule with the highest priority         
        bestMove = highestMatchingRule.Execute();

		return bestMove;	
	}
	
	public void CleanFrameWork()
	{
		
	}
}
