//
//BoardSpace.cs
//This script is attached to every square on the maze whether it is red or green.  
//It is used to provide the program information about where you are on the maze
//

using UnityEngine;
using System.Collections;

public class BoardSpace : MonoBehaviour {
	
    //descriptions about the space set in the editor
	public bool isSpaceFree;
    public bool hasFood = false;
    public bool hasPowerUp = false;
    public int row;
	public int column;
	
	public void SetTopNeighbours(int inRow, int inColumn){ topRow = inRow; topColumn = inColumn;}
	public void SetBottomNeighbours(int inRow, int inColumn){ bottomRow = inRow; bottomColumn = inColumn;}
	
	public void SetLeftNeighbours(int inRow, int inColumn){ leftRow = inRow; leftColumn = inColumn;}
	public void SetRightNeighbours(int inRow, int inColumn){ rightRow = inRow; rightColumn = inColumn;}
	
	public bool Visited
	{
		get {return bVisited;}
	}
	
	public int Row
	{
		get {return row;}
	}
	
	public int Column 
	{
		get{return column;}
	}
	public int TopRow
	{
		get{return topRow;}
	}
	public int TopColumn
	{
		get{return topColumn;}
	}
	
	public int BottomRow
	{
		get{return bottomRow;}
	}
	public int BottomColumn
	{
		get{return bottomColumn;}
	}
	
	public int LeftRow
	{
		get{return leftRow;}
	}
	public int LeftColumn
	{
		get{return leftColumn;}
	}
	
	public int RightRow
	{
		get{return rightRow;}
	}
	public int RightColumn
	{
		get{return rightColumn;}
	}
	
    //defines the positions around the current board space
	private int topRow, topColumn;
	private int bottomRow, bottomColumn;
	private int leftRow, leftColumn;
	private int rightRow, rightColumn;
	
	private GameObject mainCamera;
	private WorldData worldStateScript;
	private bool bVisited, bPlayerInTrigger;

    private bool bFirstTime;
	void Awake(){
				
		topRow = 0;
		topColumn = 0;
		
		bottomRow = 0;
		bottomColumn = 0;
		
		rightRow = 0;
		rightColumn = 0;
		
		leftRow = 0;
		leftColumn = 0;
		bVisited = false;
		bPlayerInTrigger = false;
        bFirstTime = true;
	}
	
	// Use this for initialization
	void Start () {
        //find the world data ( 1 copy exists globally )
		mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
		worldStateScript = mainCamera.GetComponent<WorldData>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter( Collider Other )
	{
		if(Other.gameObject.tag == "Player")
		{
            //sets the world data: keeps track of space the character is in
			worldStateScript.PlayerCurrentSpace = this;
            bPlayerInTrigger = true;
        }
		bVisited = true;
		
	}
	
	void OnTriggerStay(Collider Other)
	{
		if(Other.gameObject.tag == "Player")
		{
			bPlayerInTrigger = true;
		}
	}
	
	void OnTriggerExit( Collider Other )
	{
		bPlayerInTrigger = false;
	}
	
	
	
}

