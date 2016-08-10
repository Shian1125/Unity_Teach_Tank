using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tank : MonoBehaviour {

	//move
	float v;
	float h;
	public float m_speed;
	public float r_speed;

	//tube
	public GameObject tubeObj;
	public float tubeAngle_max;
	public float tubeAngle_min;
	public float tubeR_speed;

	//bullet
	public GameObject bullet;
	public Transform firePoint;
	public float bulletSpeed;
	public float bulletDamage;

	//variable
	public Slider hpbar;
	public float _hp;
	public float _curhp;

	void Start () {
		_curhp = _hp;
	}
	
	void Update () {
		Move ();
		Tube ();

		if(Input.GetMouseButtonDown(0)){
			Fire();
		}

		hpbar.value = _curhp / _hp;
	}
	void Move(){
		v = Input.GetAxis ("Vertical");
		h = Input.GetAxis ("Horizontal");

		this.transform.Translate(new Vector3(1, 0, 0) * v * m_speed * Time.deltaTime);
		this.transform.Rotate (new Vector3(0, 1, 0) * h * r_speed * Time.deltaTime);

	}
	void Tube(){
		float wheel = Input.GetAxis ("Mouse ScrollWheel");
		float angle = tubeObj.transform.localRotation.eulerAngles.x;
		//Debug.Log (wheel);	wheel > 0 => down 
		if (angle > (360 - tubeAngle_max) || angle < tubeAngle_min) {
			//Debug.Log("a");
		} else if (angle < 180 && wheel < 0) {
			//Debug.Log("b");
		} else if (angle > 180 && wheel > 0) {
			//Debug.Log("c");
		} else {
			wheel = 0;
		}
		tubeObj.transform.Rotate (new Vector3(1, 0, 0) * wheel * tubeR_speed * Time.deltaTime);
	}
	void Fire(){
		GameObject bt = Instantiate (bullet, firePoint.position, this.transform.localRotation ) as GameObject;
		//bt.GetComponent<Rigidbody> ().velocity = transform.TransformDirection (Vector3.right * bulletSpeed );
		bt.gameObject.GetComponent<Rigidbody>().AddForce (tubeObj.transform.forward * bulletSpeed);
	}
	public void GetHurt(){
		_curhp -= bulletDamage;
	}


}
