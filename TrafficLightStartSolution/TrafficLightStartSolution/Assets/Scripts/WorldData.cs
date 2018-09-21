using UnityEngine;
using System.Collections;

public class WorldData : MonoBehaviour
{
    //
    //This class will keep track of all game objects in the world that our AI needs
    //If this was a board game, the actual board would exist here
    //

    //Traffic Light we are going to track
    GameObject trafficLight;
    TrafficLight trafficLightScript;

    //Any Public Property should be read only in the World Data (we should never change world data from here)
    public TrafficLight.TrafficLightStateType TrafficState
    {
        get
        {
            return trafficLightScript.LightState;
        }
    }

    // Use this for initialization
    void Start()
    {
        trafficLight = GameObject.Find("TrafficLight");
        trafficLightScript = trafficLight.GetComponent<TrafficLight>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
