using UnityEngine;
using System.Collections.Generic;


//  A game object's core is a collection of it's low level interface commands.  This one is for a bot - it can accellarate, break, turn.
//  These are used by the bot's processor to control it's behavior.
public class Core_Bot_Basic : MonoBehaviour {
    private RaycastHit surface_ray;                //surface sampling ray - will have surface point and normal information
    private float dist_to_surface = 0f;
    private LayerMask ground = 1 << 8;      
	
    private Vector3 heading;// = transform.forward();
	private Vector3 force_engine = new Vector3(0.0f, 0.0f, 0.0f);   //the accelaration applied by the engine - 
    private Vector3 velocity = new Vector3(0.0f, 0.0f, 0.0f);       //bot velocity
    //-----------------------------------------------------------------------------------------------------
    //applies forward engine force to the velocity
    public void Accellerate()
    {
    }
	//-----------------------------------------------------------------------------------------------------
    //applies breaks resistance to the velocity	
	public void Break()
    {
	}
    //applies engine force radial velocity (rotation speed)
    public void Turn()
    {
    }
    //-----------------------------------------------------------------------------------------------------
    //Checks whether any conditions should be applied based on final velocity (flip, crash, etc)
    private void _ValidateVelocity()
    {
    }
    //-----------------------------------------------------------------------------------------------------
    //Transforms bot based on velocity
    private void _DoTransform()
    {
    }
    //-----------------------------------------------------------------------------------------------------
    //Must run after any transformation to keep the bot aligned to the ground.
    private void _AlignToSurface()
    {
        Physics.Raycast(transform.position, -transform.position, out surface_ray, transform.position.magnitude, ground);
        transform.position = surface_ray.point;
        transform.up = surface_ray.normal;
    }
}
