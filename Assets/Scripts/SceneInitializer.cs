using UnityEngine;
using System.Collections;

//This is a script on a dummy object, just here to
//call init() methods on other objects.
public class SceneInitializer : MonoBehaviour{

	// Use this for initialization
	void Start () {
		PrebuiltFunctions.init();
		
	}
}
