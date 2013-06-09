using UnityEngine;
using System.Collections;

public class Camera_Planet : MonoBehaviour {
	//public Camera cam;
	public Transform t_cam, t_planet;
	public static float base_cam_speed = 10f;
	public static float max_cam_height = .95f;
	public static float break_cam_height = .8f;
	public bool mouseCameraControl = true;
	
	private static int CONTROL_BORDER = 100;
	private float act_cam_speed = 0f;
	
	private float cam_height = 0f;
	
	//private Vector3 vec_rot = Vector3.zero;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		/*
		Vector3 vec_mouse = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 50)) - cam.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height/2, 50));
		vec_rot = Vector3.Cross(vec_mouse, t_cam.position);
		Debug.DrawLine(vec_rot, Vector3.zero, Color.green);
		Debug.DrawLine(vec_mouse, Vector3.zero, Color.blue);
		
			if (Input.mousePosition.x < (0 + CONTROL_BORDER) || 
				Input.mousePosition.y < (0 + CONTROL_BORDER) ||
				Input.mousePosition.x > (Screen.width - CONTROL_BORDER) ||
				Input.mousePosition.y > (Screen.height - CONTROL_BORDER)){
				t_cam.transform.RotateAround(t_planet.transform.position, vec_rot, Time.deltaTime * -Vector3.Magnitude(vec_mouse));
				Debug.DrawLine(Input.mousePosition, Vector3.zero, Color.white);
			}
		*/
		if (mouseCameraControl && Input.mousePosition.x < (0 + CONTROL_BORDER) || Input.GetAxis("Horizontal") < 0) {
			t_cam.transform.RotateAround(t_planet.transform.position, Vector3.up, Time.deltaTime * base_cam_speed);
		}
		if (mouseCameraControl && Input.mousePosition.x > (Screen.width - CONTROL_BORDER) || Input.GetAxis("Horizontal") > 0) {
			t_cam.transform.RotateAround(t_planet.transform.position, Vector3.up, Time.deltaTime * -base_cam_speed);						
		}
		cam_height = Vector3.Dot(Vector3.up, t_cam.position.normalized);
		if (mouseCameraControl && Input.mousePosition.y < (0 + CONTROL_BORDER) || Input.GetAxis("Vertical") < 0) {
			if (cam_height < -break_cam_height) {
				act_cam_speed = base_cam_speed*(1f-(cam_height + break_cam_height)/(-max_cam_height + break_cam_height));
			} else {
				act_cam_speed = base_cam_speed;
			}
			if (cam_height > -max_cam_height) {
				t_cam.transform.RotateAround(t_planet.transform.position, Vector3.Cross(t_cam.position, Vector3.up), Time.deltaTime * -act_cam_speed);
			}
		}
		if	(mouseCameraControl && Input.mousePosition.y > (Screen.height - CONTROL_BORDER) || Input.GetAxis("Vertical") > 0) {
			if (cam_height > break_cam_height) {
				act_cam_speed = base_cam_speed*(1f-(cam_height - break_cam_height)/(max_cam_height - break_cam_height));
			} else {
				act_cam_speed = base_cam_speed;
			}
			if (cam_height < max_cam_height) {
				t_cam.transform.RotateAround(t_planet.transform.position, Vector3.Cross(t_cam.position, Vector3.up), Time.deltaTime * act_cam_speed);						
			}				
		}
		if (Input.GetAxis("Mouse ScrollWheel") != 0) {
			t_cam.position *= 1 + -Input.GetAxis("Mouse ScrollWheel")*.1f;
		}
			//
			//Debug.Log(t_cam.transform.position);
	}
}
