using UnityEngine;
using System.Collections;

public class NextChoiceType {
	//
	//This class is aware of all the possible moves
	//
	
	
	//Possible moves (This could be any type, even another class)
	public enum NextMoveType{STOP,GO,SLOW_DOWN, UNKNOWN}; 
	
	public NextMoveType NextMove
	{
		get
		{
			return nMove;
		}
		set
		{
			nMove = value;
		}
	}
	
	
	private NextMoveType nMove;
	
	
	public NextChoiceType()
	{
		nMove = NextMoveType.GO;
	}
	
}
