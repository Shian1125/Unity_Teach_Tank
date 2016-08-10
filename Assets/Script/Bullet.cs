using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision obj){
		if(obj.collider.tag == "Tank"){
			// -hp
			obj.gameObject.GetComponent<Tank>().GetHurt();
		}
		Destroy (gameObject);
	}
}
