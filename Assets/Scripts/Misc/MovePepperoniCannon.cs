using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePepperoniCannon : MonoBehaviour {

    public GameObject doughboy;

    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if( Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.RotateAround(Vector3.zero, Vector3.up, 10f * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.RotateAround(Vector3.zero, Vector3.up, -10f * Time.deltaTime);
        }
    }


}
