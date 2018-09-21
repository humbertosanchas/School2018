//
//PlayerControl.cs
//This is the "AI" class for the player. It has access to world data.
//This uses the rule based framework to tell it what its next move should be.
//Once the AI gives the next move, this script performs the action

using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	
	float speed;
	float dx;
	float dy;
	float dz;
	RuleFrameWork ruleAI;
	WorldData worldState;
	GameObject mainCamera;
	NextMovementChoice lastMove;
	NextMovementChoice nextMove;
	
	public NextMovementChoice NextMove
	{
		get {return nextMove;}
	}
	
	void Awake()
	{
		speed = 10.0f;
		dx = 0f;
		dy = 0f;
		dz = 0f;
	}

	// Use this for initialization
	void Start () {
		
		ruleAI = new RuleFrameWork();
		mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
		worldState = mainCamera.GetComponent<WorldData>();
		lastMove = new NextMovementChoice();
		nextMove = new NextMovementChoice();
        nextMove.NextMove =  NextMovementChoice.NextMoveType.NONE ;
        //The world keeps track of the character's data
		worldState.CharAI1 = this;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{

        if (worldState.gameOver == true)
            return;
		
        if (worldState.PlayerCurrentSpace)
        {
            Vector3 destPosition = worldState.PlayerCurrentSpace.transform.position;
            destPosition.y = 0;

            Vector3 currentPosition = this.transform.position;
            currentPosition.y = 0;

            float dist = Vector3.Distance(currentPosition, destPosition);
            if (dist <= 0.25f)
            {
                Debug.Log("Reached position, get new position");
                lastMove.NextMove = nextMove.NextMove; //keep track of the last move
                
                //TODO: GET the decision from the AI on what to do next
               // nextMove = ruleAI.RunAI_Evalute(worldState);
                worldState.PlayerCurrentSpace = null;
            }
        }

	
			
		
		//Move direction determined by AI
		transform.Translate (new Vector3(dx, dy, dz) ); 
		
	}
		
	void Forward()
	{
		dx = 0f;
		dy = 0f;
		dz = speed * Time.deltaTime;
	}
	
	void Left()
	{
		
		dx = -speed * Time.deltaTime;
		dy = 0f;
		dz = 0f;
		
	}
	
	void Right()
	{
		dx = speed * Time.deltaTime;
		dy = 0f;
		dz = 0f;
	}
	
	void Backward()
	{
		dx = 0f;
		dy = 0f;
		dz = -speed * Time.deltaTime;
	}
	
	void Stop()
	{
		dx = 0f;
		dy = 0f;
		dz = 0f;
	}
	
}