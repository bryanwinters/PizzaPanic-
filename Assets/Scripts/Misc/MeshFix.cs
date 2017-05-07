using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshFix : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.T))
        {
            MeshCollider mc = gameObject.GetComponent<MeshCollider>();
            //mc.sharedMesh = gameObject.GetComponent<SkinnedMeshRenderer>().sharedMesh;
            Debug.Log("fixing");
            //gameObject.GetComponent<MeshFilter>().mesh = gameObject.GetComponent<MeshFilter>().mesh;
            gameObject.GetComponent<MeshCollider>().sharedMesh = null;
            //gameObject.GetComponent<SkinnedMeshRenderer>().sharedMesh = null;
            gameObject.GetComponent<MeshCollider>().sharedMesh = gameObject.GetComponent<SkinnedMeshRenderer>().sharedMesh;
            mc.sharedMesh = gameObject.GetComponent<MeshCollider>().sharedMesh;
            mc.convex = true;
        }
    }
}
