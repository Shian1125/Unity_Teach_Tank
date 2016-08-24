using UnityEngine;
using System.Collections;

public class Test01 : MonoBehaviour {
GameObject obj1;
	// Use this for initialization
	void Start () {
		CallTest02();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void CallTest02(){
		//GameObject t2 = GameObject.Find("Test02");
		Test02 t2 = GameObject.Find("Test02").GetComponent<Test02>();
		
		Debug.Log(t2.gameObject.name);
	}
}

