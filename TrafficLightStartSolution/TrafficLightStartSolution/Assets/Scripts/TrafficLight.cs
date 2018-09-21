using UnityEngine;
using System.Collections;

public class TrafficLight : MonoBehaviour {

	public enum TrafficLightStateType  {OFF, RED, AMBER, GREEN};
	public float RedTime = 3f;
	public float AmberTime = 3f;
	public float GreenTime = 3f;
	public float OffTime = 3f;
	
	
	public TrafficLightStateType LightState
	{
		get
		{
			return currentLightState;
		}
		private set
		{
			currentLightState = value;
		}
	}
	
	
	private GameObject RedLightChild;
	private GameObject AmberLightChild;
	private GameObject GreenLightChild;
	private GameObject PointLightChild;
	private Light PointLightComponent;
	
	
	private Color AmberOffColor;
	private Color AmberOnColor;
	
	private Color RedOffColor;
	private Color RedOnColor;
	
	private Color GreenOffColor;
	private Color GreenOnColor;
	
	
	private TrafficLightStateType currentLightState = TrafficLightStateType.OFF;
	private float timer = 0f; // time in secs
	
	
	
	// Use this for initialization
	void Start () {
		LightState = TrafficLightStateType.RED;
		
		AmberOffColor = new Color(.60f,0.60f,0.36f);
		AmberOnColor = new Color(1.0f,0.90f,0);
	
		RedOffColor = new Color(.30f,0.14f,0.14f);
		RedOnColor  = new Color(1f,0,0);
	
		//GreenOffColor = new Color(0.27f,0.40f,0.30f);
		GreenOffColor = new Color(0.140f,0.20f,0.14f);
		GreenOnColor  = new Color(0,1f,0);
	
		RedLightChild  = this.transform.Find("RedLight").gameObject;
		AmberLightChild = this.transform.Find("AmberLight").gameObject;
		GreenLightChild = this.transform.Find("GreenLight").gameObject;
		PointLightChild = this.transform.Find("Point light").gameObject;
		
		PointLightComponent = PointLightChild.GetComponent<Light>();
		
		UpdateLightObject();
	}
	
	void UpdateLightObject()
	{
		if(LightState == TrafficLightStateType.RED)
		{
			RedLightChild.GetComponent<Renderer>().material.color 	= RedOnColor;
			GreenLightChild.GetComponent<Renderer>().material.color = GreenOffColor;
			AmberLightChild.GetComponent<Renderer>().material.color = AmberOffColor;
			PointLightComponent.color = RedOnColor;
		}
		else if(LightState == TrafficLightStateType.GREEN)
		{
			RedLightChild.GetComponent<Renderer>().material.color 	=  RedOffColor;
			GreenLightChild.GetComponent<Renderer>().material.color =  GreenOnColor;
			AmberLightChild.GetComponent<Renderer>().material.color =  AmberOffColor;
			PointLightComponent.color = GreenOnColor;
			
		}
		else if(LightState == TrafficLightStateType.AMBER)
		{
			RedLightChild.GetComponent<Renderer>().material.color 	= RedOffColor;
			GreenLightChild.GetComponent<Renderer>().material.color = GreenOffColor;
			AmberLightChild.GetComponent<Renderer>().material.color = AmberOnColor;
			PointLightComponent.color = AmberOnColor;
		}
		else if(LightState == TrafficLightStateType.OFF)
		{
			RedLightChild.GetComponent<Renderer>().material.color 	= RedOffColor;
			GreenLightChild.GetComponent<Renderer>().material.color = GreenOffColor;
			AmberLightChild.GetComponent<Renderer>().material.color = AmberOffColor;
			PointLightComponent.color = new Color (0,0,0);
		}
		
			
	}
	// Update is called once per frame
	void Update () 
	{
		if( timer >= RedTime && LightState == TrafficLightStateType.RED )
		{
			timer = 0f;
			LightState = TrafficLightStateType.GREEN;
		}
		else if(timer >= AmberTime && LightState == TrafficLightStateType.AMBER )
		{
			timer = 0f;
			LightState = TrafficLightStateType.RED;
		}
		else if(timer >= GreenTime && LightState == TrafficLightStateType.GREEN )
		{
			timer = 0f;
			LightState = TrafficLightStateType.AMBER;
		}
		else if(timer >= OffTime && LightState == TrafficLightStateType.OFF )
		{
			timer = 0f;
			LightState = TrafficLightStateType.RED;
		}
		
		UpdateLightObject();
		
		timer += Time.deltaTime;
		
	}
}
