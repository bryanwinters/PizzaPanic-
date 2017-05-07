using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoughPulling : MonoBehaviour {

    List<Collider> bones = new List<Collider>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if( Input.GetKeyDown(KeyCode.T))
        {
            PULLDOUGH();
        }
	}

    public void PULLDOUGH()
    {
        /*
        for (int x = 0; x < bones.Count; x++)
        {
            Vector3 tempVec = gameObject.transform.position - bones[x].transform.position;
            tempVec = bones[x].transform.position + bones[x].transform.forward * 0.5f;
            bones[x].transform.position = tempVec;
            //bones[x].SendMessageUpwards("FixMyMeshCollider", SendMessageOptions.DontRequireReceiver);
        }*/
    }

    void OnTriggerEnter (Collider c)
    {
        bones.Add(c);
    }
    
    void OnTriggerExit (Collider c)
    {
        bones.Remove(c);
    }
}
