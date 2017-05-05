using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

    public static ObjectPooler SharedInstance;

    void Awake()
    {
        SharedInstance = this;
    }

    public List<GameObject> PooledPepperoni;
    //make lists of toppings to pool and do that

    public GameObject objectToPool;
    public int amountToPool;

	// Use this for initialization
	void Start () {
        PooledPepperoni = new List<GameObject>();
        for(int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.SetActive(false);
            PooledPepperoni.Add(obj);
        }
		
	}
	
    public GameObject GetTopping(int toppingNumber)
    {
        if( toppingNumber == 0)
        {
            for (int i = 0; i < PooledPepperoni.Count; i++)
            {
                if (!PooledPepperoni[i].activeInHierarchy)
                {
                    return PooledPepperoni[i];
                }
            }
        }

        return null;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
