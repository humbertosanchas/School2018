using UnityEngine;
using System.Collections;

public class CharacterAI : MonoBehaviour {
	
	private GameObject worldState;
	private WorldData worldStateScript;
	
	//TODO private RuleFrameWork ruleBasedAI;
	private NextChoiceType nextMove;
	private float applyForce;
	
	float GO_FORCE;
	const float SLOW_DOWN_FORCE = 0.5f;
	const float STOP_FORCE = 0f;
	const float STOP_DRAG = 1f;
	const float GO_DRAG = 0.001f;
	float SLOW_DRAG = 0.5f;
	
	bool initGo;
	private Color AmberColor;
	private Color RedColor;
	private Color GreenColor;

    public RuleFrameWork ruleBasedAI;

    // Use this for initialization
    void Start () 
	{
		//find the world data ( 1 copy exists globally )
		worldState = GameObject.Find("WorldDataManager");
		worldStateScript = worldState.GetComponent<WorldData>();


        //Create the framework, it gets initialized in constructor
        //TODO ruleBasedAI = new RuleFrameWork();
        ruleBasedAI = new RuleFrameWork();

        //We don't have a next move yet as we are just starting
        nextMove = null;
		
		AmberColor = new Color(1.0f,1.0f,0);
		RedColor  = new Color(1f,0,0);
		GreenColor  = new Color(0,1f,0);
		
		GO_FORCE = 1.5f + Random.Range(0.0f, 1.0f);
		SLOW_DRAG = 0.2f + Random.Range (0.2f, 0.5f);
		
		initGo = false;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
        nextMove = ruleBasedAI.RunAI_Evalute(worldStateScript);
        //Get our next move		
        //run the evaluate every frame, NOTE: does not have to be every frame,
        //in a turn based game this would run on a button press
        //TODO nextMove = ruleBasedAI.RunAI_Evalute(worldStateScript);

        if (nextMove != null)
		{
			if(nextMove.NextMove == NextChoiceType.NextMoveType.STOP)
			{
				GetComponent<Renderer>().material.color = RedColor;
			}
			else if(nextMove.NextMove == NextChoiceType.NextMoveType.GO)
			{
				GetComponent<Renderer>().material.color = GreenColor;				
			}
			else if(nextMove.NextMove == NextChoiceType.NextMoveType.SLOW_DOWN)
			{
				GetComponent<Renderer>().material.color = AmberColor;
				
			}
			
			
		}
	}
	//Called to apply force to the RigidBody
	void FixedUpdate()
	{
		//Apply the correct amount of force passed on the what the AI's nextMove tells us
		if(nextMove != null)
		{
			if(nextMove.NextMove == NextChoiceType.NextMoveType.STOP)
			{
				initGo = false;
				Stop();
			}
			else if(nextMove.NextMove == NextChoiceType.NextMoveType.GO)
			{
				if(!initGo)
				{
					initGo = true;
				}
				Go();
			}
			else if(nextMove.NextMove == NextChoiceType.NextMoveType.SLOW_DOWN)
			{
				initGo =false ;
				SlowDown();
			}
			
		}
	}
	
	void Stop()
	{
		applyForce = STOP_FORCE;
		GetComponent<Rigidbody>().drag = STOP_DRAG;
		GetComponent<Rigidbody>().AddForce(0,0,applyForce);
	}
	
	void SlowDown()
	{
		applyForce = SLOW_DOWN_FORCE;
		GetComponent<Rigidbody>().AddForce(0,0,applyForce);
		GetComponent<Rigidbody>().drag = SLOW_DRAG;
	}
	
	void Go()
	{
		applyForce = GO_FORCE;
		GetComponent<Rigidbody>().AddForce(0,0,applyForce);
		GetComponent<Rigidbody>().drag = GO_DRAG;
	}
	
}
