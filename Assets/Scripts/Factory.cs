using UnityEngine;
using System.Collections.Generic;

public class Factory : MonoBehaviour {
	private float timeToProduce;
	public int maxRobots = 10;
	public static List<Core_Bot_Basic> bots = new List<Core_Bot_Basic>();
	public GameObject instance;
	public float manufactureInitialCooldown = 1;
	
	// Use this for initialization
	void Start () {
		timeToProduce = manufactureInitialCooldown;
	}
	
	// Update is called once per frame
	void Update () {
		timeToProduce -= Time.deltaTime;
		
		if (timeToProduce <= 0){
			Core_Bot_Basic newBot;
			
			float angle = Random.Range (0,2 * Mathf.PI);
			Vector3 pos = transform.position + transform.forward * Mathf.Cos(angle) * 6 + transform.up * Mathf.Sin(angle) * 6;
			
			if(bots.Count < maxRobots){
				newBot = Instantiate(instance, pos, Quaternion.Euler(transform.position)) as Core_Bot_Basic;
				//newBot = (instance).GetComponent<Core_Bot_Basic>();
				bots.Add(newBot);
			} else {
				// recycle the oldest bot.
				newBot = bots[0];
				newBot.transform.position = pos;
				newBot.transform.rotation = Quaternion.Euler(transform.position);
			}
			timeToProduce = manufactureInitialCooldown + bots.Count;
		}
	}
}
