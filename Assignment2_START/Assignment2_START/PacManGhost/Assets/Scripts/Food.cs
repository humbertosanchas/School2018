//
//Food.cs
//This script is attached to each food object on the grid.
//It has access to world data. When player enters a space on the grid with food, this script is respsonsible for destroying the food object and updating the 
//number of food eaten count in the world data.
//
using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {

    WorldData worldState;
    GameObject mainCamera;
    // Use this for initialization
    void Start () {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        worldState = mainCamera.GetComponent<WorldData>();
    }

    //Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            worldState.NumFoodEaten++;
            worldState.TotalFoodAvailable--;           
            this.gameObject.SetActive(false);

        }
    }
    //void OnTriggerExit(Collider other)
    //{

    //}

}
