//
//NextMovementChoice.cs
//Stores all the possible moves for the rulebased framework/rules/AI
//
using UnityEngine;
using System.Collections;

public class NextMovementChoice  {

	public enum NextMoveType{NONE, MOVE_TYPE_MAX}; //Add your moves to this enum
	
	
	public NextMoveType NextMove
	{
		get{return nextMove;}
		set{ nextMove = value;}
	}
	
	
	public NextMovementChoice()
	{
		nextMove = NextMoveType.NONE;
	}
	
	
	private NextMoveType nextMove;
	
	
	
}
