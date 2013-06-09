using UnityEngine;
using System.Collections;

public class SunScript : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.RotateAround(Vector3.zero, Vector3.up, 10 * Time.deltaTime);
		
	}
}
