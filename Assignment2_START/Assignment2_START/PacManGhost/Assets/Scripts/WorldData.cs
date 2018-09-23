//
//World.cs
//This script stores all the information the rulebased system needs to make a decision on the next move.
//DetermineOpenMoves needs to be completed to give the current state of availabe spaces with respect to the current player's position on the maze
//
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WorldData : MonoBehaviour {
	
	const int MAX_ROW = 11;
	const int MAX_COLUMN = 11;
	const int OUT_OF_BOUNDS = -1;
	
	GameObject[] boardSpaces;
	GameObject[,] gameBoard;
	BoardSpace[,] gameBoardSpaces;
	PlayerControl PC;
	
	bool topFree;
	bool bottomFree;
	bool leftFree;
	bool rightFree;

    bool topFood;
    bool bottomFood;
    bool leftFood;
    bool rightFood;

    bool topPowerUp;
    bool bottomPowerUp;
    bool leftPowerUp;
    bool rightPowerUp;

    BoardSpace playerCurrentSpace;
	
	bool preventBackReverseDirection;
	bool preventRightReverseDirection;
	bool preventLeftReverseDirection;
  	bool preventTopReverseDirection;
	
	bool topVisited;
	bool bottomVisited;
	bool leftVisited;
	bool rightVisited;

    public Text WorldInformationText;

    [HideInInspector]
    public int NumSquaresVisted;
    public int TotalFreeSpaces;
    public bool gameOver;
    public int NumFoodEaten;
    public int NumPowerEaten;

    public int TotalFoodAvailable;
    public int TotalPowerUps;
	
	
	public bool TraceMode;
	public bool PreventBackReverseDirection
	{
		set{ preventBackReverseDirection = value; }
		get{ return preventBackReverseDirection; }
	}
	
	public bool PreventRightReverseDirection
	{
		set{ preventRightReverseDirection = value; }
		get{ return preventRightReverseDirection; }
	}
	
	public bool PreventLeftReverseDirection
	{
		set{ preventLeftReverseDirection = value; }
		get{ return preventLeftReverseDirection;  }
	}
	
	public bool PreventTopReverseDirection
	{
		set{preventTopReverseDirection = value;}
		get{ return preventTopReverseDirection;}
	}
	
	public PlayerControl CharAI1
	{
		set{PC = value;}
		get{return PC;}
	}
	
	public bool TopFree
	{
		get {return topFree;}
	}
	public bool BottomFree
	 {
		get {return bottomFree;}
	}
	public bool LeftFree
	{
		get {return leftFree;}
	}
	public bool RightFree
	{
		get {return rightFree;}
	}


    public bool TopFood
    {
        get { return topFood; }
    }
    public bool BottomFood
    {
        get { return bottomFood; }
    }
    public bool LeftFood
    {
        get { return leftFood; }
    }
    public bool RightFood
    {
        get { return rightFood; }
    }
    public bool TopPowerUp
    {
        get { return topPowerUp; }
    }
    public bool BottomPowerUp
    {
        get { return bottomPowerUp; }
    }
    public bool LeftPowerUp
    {
        get { return leftPowerUp; }
    }
    public bool RightPowerUp
    {
        get { return rightPowerUp; }
    }

    public BoardSpace PlayerCurrentSpace
	{
		set
		{
			playerCurrentSpace = value;
		}
		get
		{
			return playerCurrentSpace;
		}
			
	}
	
	public bool TopVisited
	{
		get {return topVisited;}
	}
	
	public bool BottomVisited
	{
		get {return bottomVisited;}
	}
	
	public bool LeftVisited
	{
		get {return leftVisited;}
	}
	
	public bool RightVisited
	{
		get {return rightVisited;}
	}
	
	public void DetermineOpenMoves( BoardSpace charSpace  )
	{
		
		  NextMovementChoice charNextMove = CharAI1.NextMove;
          InitPossibleMoves();

        //TODO Check for free positions
        //Check for open moves on the board and set the appropriate flags
        topFree = isTopNeighbourOpen(playerCurrentSpace,ref topVisited, ref topFood, ref topPowerUp);
        bottomFree = isBottomNeighbourOpen(playerCurrentSpace, ref bottomVisited, ref bottomFood, ref bottomPowerUp);
        rightFree = isRightNeighbourOpen(playerCurrentSpace, ref rightVisited, ref rightFood, ref rightPowerUp);
        leftFree = isLeftNeighbourOpen(playerCurrentSpace, ref leftVisited, ref leftFood, ref leftPowerUp);
        
        //The world stores  all the open moves for the rule framework
        
    }

    //isTopNeighbourOpen takes in a boardSpace and determines if the spot above the boardspace is free or has food or powerups
    bool isTopNeighbourOpen(BoardSpace boardSpace, ref bool visited, ref bool isfood, ref bool isPowerUp )
	{
		bool bFreeToMove = false;
		
		
		if(boardSpace.TopRow == OUT_OF_BOUNDS )
		{
			bFreeToMove = false;
		}
		else 
		{
            //TODO: ADD YOUR CODE HERE
            if(gameBoardSpaces[boardSpace.TopRow, playerCurrentSpace.column].isSpaceFree)
            {
                visited = gameBoardSpaces[boardSpace.TopRow, playerCurrentSpace.column].Visited;
                isfood = gameBoardSpaces[boardSpace.TopRow, playerCurrentSpace.column].hasFood;
                isPowerUp = gameBoardSpaces[boardSpace.TopRow, playerCurrentSpace.column].hasPowerUp;                
                bFreeToMove = true;             
            }
        }
        return bFreeToMove;
	}
    //isBottomNeighbourOpen takes in a boardSpace and determines if the spot below the boardspace is free or has food or powerups
    bool isBottomNeighbourOpen( BoardSpace boardSpace, ref bool visited, ref bool isfood, ref bool isPowerUp)
	{
		bool bFreeToMove = false;
		
		if(boardSpace.BottomRow == MAX_ROW )
		{
			bFreeToMove = false;
		}
		else 
		{
            //TODO: ADD YOUR CODE HERE
            if (gameBoardSpaces[boardSpace.BottomRow, playerCurrentSpace.column].isSpaceFree)
            {
                visited = gameBoardSpaces[boardSpace.BottomRow, playerCurrentSpace.column].Visited;
                isfood = gameBoardSpaces[boardSpace.BottomRow, playerCurrentSpace.column].hasFood;
                isPowerUp = gameBoardSpaces[boardSpace.BottomRow, playerCurrentSpace.column].hasPowerUp;                
                bFreeToMove = true;                
            }
        }
		return bFreeToMove;
	}

    //isLeftNeighbourOpen takes in a boardSpace and determines if the spot left of the boardspace is free or has food or powerups
    bool isLeftNeighbourOpen( BoardSpace boardSpace, ref bool visited, ref bool isfood, ref bool isPowerUp)
	{
		bool bFreeToMove = false;
		
		if(boardSpace.LeftColumn == OUT_OF_BOUNDS )
		{
			bFreeToMove = false;
		}
		else 
		{
            //TODO: ADD YOUR CODE HERE
            if (gameBoardSpaces[playerCurrentSpace.row, boardSpace.LeftColumn].isSpaceFree)
            {
                visited = gameBoardSpaces[playerCurrentSpace.row, boardSpace.LeftColumn].Visited;
                isfood = gameBoardSpaces[playerCurrentSpace.row, boardSpace.LeftColumn].hasFood;
                isPowerUp = gameBoardSpaces[playerCurrentSpace.row, boardSpace.LeftColumn].hasPowerUp;                
                bFreeToMove = true;                
            }
        }
        return bFreeToMove;
	}

    //isRightNeighbourOpen takes in a boardSpace and determines if the spot right of the boardspace is free or has food or powerups
    bool isRightNeighbourOpen(  BoardSpace boardSpace, ref bool visited, ref bool isfood, ref bool isPowerUp)
	{
		bool bFreeToMove = false;
		
		if(boardSpace.RightColumn == MAX_COLUMN )
		{
			bFreeToMove = false;
		}
		else
		{
            //TODO: ADD YOUR CODE HERE
            if (gameBoardSpaces[playerCurrentSpace.row, boardSpace.RightColumn].isSpaceFree)
            {
                visited = gameBoardSpaces[playerCurrentSpace.row, boardSpace.RightColumn].Visited;
                isfood = gameBoardSpaces[playerCurrentSpace.row, boardSpace.RightColumn].hasFood;
                isPowerUp = gameBoardSpaces[playerCurrentSpace.row, boardSpace.RightColumn].hasPowerUp;                
                bFreeToMove = true;               
            }
        }
        return bFreeToMove;
	}

    void InitPossibleMoves()
    {
        topFree = false;
        bottomFree = false;
        leftFree = false;
        rightFree = false;

        topFood = false;
        bottomFood = false;
        leftFood = false;
        rightFood = false;

        topPowerUp = false;
        bottomPowerUp = false;
        leftPowerUp = false;
        rightPowerUp = false;
    }
	
	void Awake()
	{
        InitPossibleMoves();
       
        preventBackReverseDirection 	= false;
		preventRightReverseDirection	= false;
		preventLeftReverseDirection 	= false;
  		preventTopReverseDirection 		= false;
		
		topVisited = false;
		bottomVisited = false;
		leftVisited = false;
		rightVisited = false;
        NumSquaresVisted = 0;
        gameOver = false;
        NumFoodEaten = 0;
        NumPowerEaten = 0;
    }
	
	// Use this for initialization
	void Start () {
		
		boardSpaces = GameObject.FindGameObjectsWithTag ("BoardSpace");
		
		gameBoard  = new GameObject[MAX_ROW,MAX_COLUMN];
		gameBoardSpaces = new BoardSpace[MAX_ROW,MAX_COLUMN];
        TotalFreeSpaces = 0;
		foreach (GameObject  boardSpot in boardSpaces )
		{
			BoardSpace boardSpace = boardSpot.GetComponent<BoardSpace>();
			if( boardSpace.row < MAX_ROW &&  boardSpace.row  >=0 &&  boardSpace.column >= 0 &&  boardSpace.column < MAX_COLUMN)
			{
				int i = boardSpace.row;
				int j = boardSpace.column;
				
				//set neighbours
				boardSpace.SetTopNeighbours(i-1,j);
				boardSpace.SetBottomNeighbours(i+1,j);
				boardSpace.SetLeftNeighbours(i,j-1);
				boardSpace.SetRightNeighbours(i,j+1);
				
				gameBoardSpaces[i,j] = boardSpace;
				gameBoard[i,j] = boardSpot;
                if(boardSpace.hasFood)
                {
                    TotalFoodAvailable++;
                }
                if(boardSpace.hasPowerUp)
                {
                    TotalPowerUps++;
                }
                if(boardSpace.isSpaceFree)
                {
                    TotalFreeSpaces++;
                }         
            }
		}

        //set the initial current position of player on board
		playerCurrentSpace = gameBoard[10,10].GetComponent<BoardSpace>();	
	}
	
	// Update is called once per frame
	void Update () {

        if(TotalFoodAvailable == NumFoodEaten  )
        {
            gameOver = true;
        }

        else if (TotalFreeSpaces == NumSquaresVisted)
         {
             gameOver = true;
         }

        WorldInformationText.text = "Total Food " + TotalFoodAvailable + "  Num Food Eaten So Far: " + NumFoodEaten;
       
        if(gameOver)
        {
            WorldInformationText.text +=  " All Done!";
        }

	}
	
}
