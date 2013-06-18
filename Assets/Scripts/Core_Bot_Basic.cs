using UnityEngine;
using System.Collections.Generic;


//  A game object's core is a collection of it's low level interface commands.  This one is for a bot - it can accellarate, break, turn.
//  These are used by the bot's processor to control it's behavior.
public class Core_Bot_Basic : MonoBehaviour {
	public string Bot_ID = "B001";
	public Processor_Bot_Basic processor;		// this bot's processor.
	public Function main_function;				// allows setting the processor's main function in Unity UI.
	    
	private Transform T_Planet;
	
    //private Vector3 heading = transform.forward();
    private Vector3 velocity = new Vector3(0.0f, 0.0f, 0.0f);       //bot velocity
    private float throttle = 0.0f;              //the accelaration applied by the engine - 
    private float engineforce = 0.0f;           //the current force of the engine in newtons
    private float engineforce_max = 100.0f;     //the max force of the engine in newtons (1 kg * 1s^2)
    private float unit_mass = 1000.0f;          //the mass of the unit in kilograms
    private float breakforce_max = 100.0f;      //the max force applied by breaks (should never be negative)
    private float rotation = 0.0f;       		//The angle of rotation to apply
	private float rotation_time = 0.0f;			//The amount of time left for rotation
	private Vector3 rotation_goal = new Vector3(0.0f, 0.0f, 0.0f); //The point to rotate towards
	private Vector3 halfHeight = new Vector3(0,5F,0);	//planet surface point + this = my center.
	
	void Start(){
		main_function = Function.DRIVE_TOWARDS_A;
		this.processor = new Processor_Bot_Basic(this, main_function);
		Debug.Log("new bot with processor " + processor + " and channels " + processor.channels);
	}
	
	void Update(){
		processor.Update();	
		
		_DoTransform();
		_ValidateVelocity();
		_AlignToSurface();
	}
    //-----------------------------------------------------------------------------------------------------
    //applies forward engine force to the velocity
    public void SetThrottle(float new_throttle)
    {
        throttle = new_throttle;
        engineforce = engineforce_max * throttle;
        velocity.z += (engineforce / unit_mass);
    }
	//-----------------------------------------------------------------------------------------------------
    //applies breaks resistance to the velocity	
	public void SetBreaks(float breakforce)
    {
        if (breakforce < 0f)
            _MechanicalFailure_Minor();
        if (velocity.z > 0)
        {
            velocity.z -= (breakforce / unit_mass);
            velocity.z = velocity.z > 0 ? velocity.z : 0f;
        }
	}
    //Turns the object toward a point in world over time.
    public void TurnToward(Vector3 worldpoint, float time)
    {
		rotation_goal = worldpoint;
		rotation_time = time;
    }
    //-----------------------------------------------------------------------------------------------------
    //Checks whether any conditions should be applied based on final velocity (bank, flip, crash, etc)
    private void _ValidateVelocity()
    {
		
    }
    //-----------------------------------------------------------------------------------------------------
    //Transforms bot based on velocity
    private void _DoTransform()
    {
		if(rotation_time > 0)
		{
			rotation = Vector3.Angle(GPS.getHeading(transform.position, rotation_goal), transform.forward);
			transform.Rotate(Vector3.up * rotation * Time.deltaTime / rotation_time);
			rotation_time -= Time.deltaTime;
		}
		transform.Translate(velocity * Time.deltaTime);
    }
    //-----------------------------------------------------------------------------------------------------
    //Must run after any transformation to keep the bot aligned to the ground.
    private void _AlignToSurface()
    {
		RaycastHit hit = GPS.getRaycastHit(transform.position);
        transform.position = hit.point;// + transform.up * Vector3.Dot(transform.up, halfHeight);	//add half height
        transform.up = hit.normal;
    }
    //-----------------------------------------------------------------------------------------------------
    //Do whatever it should when a minor mechanical failure occurs
    private void _MechanicalFailure_Minor()
    {
    }
}
