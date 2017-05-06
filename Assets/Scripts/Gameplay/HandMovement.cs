using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour {

    private float _zOffset = 0f;
    private float _speed = 0.4f;

    private CapsuleCollider _tableRef;
    private Player _playerRef;

    private string _controlsVertical;
    private string _controlsHorizontal;

    private void Awake () 
    {
        SetupVariables();
    }

    private void SetupVariables ()
    {
        _tableRef = SessionManager.Instance.Table;
        _playerRef = this.GetComponent<Player>();
    }

	// Use this for initialization
	private void Start () 
    {
		
	}

    public void Init ()
    {
        _controlsVertical = Constants.CONTROLS_VERTICAL + _playerRef.PlayerNumber;
        _controlsHorizontal = Constants.CONTROLS_HORIZONTAL + _playerRef.PlayerNumber;
    }

    public void SetToPosition (Vector2 axis)
    {
        this.transform.position = new Vector3(Constants.PLAYER_SPAWN_OFFSET*axis.x ,0f, Constants.PLAYER_SPAWN_OFFSET*axis.y);
    }

    private IEnumerator RotateObject(Vector3 point, Vector3 axis, float rotateAmount, float rotateTime) 
    {
        float step = 0.0f; //non-smoothed
        float rate = 1.0f/rotateTime; //amount to increase non-smooth step by
        float smoothStep = 0.0f; //smooth step this time
        float lastStep = 0.0f; //smooth step last time
        while(step < 1.0f)
        { // until we're done
            step += Time.deltaTime * rate; //increase the step
            smoothStep = Mathf.SmoothStep(0.0f, 1.0f, step); //get the smooth step
            transform.RotateAround(point, axis, 
                rotateAmount * (smoothStep - lastStep));
            lastStep = smoothStep; //store the smooth step
            yield return null;
        }
        //finish any left-over
        if(step > 1.0f) transform.RotateAround(point, axis,
            rotateAmount * (1.0f - lastStep));
    }
	
	// Update is called once per frame
	void Update () 
    {
        if (GameManager.Instance.GameState == Constants.GameState.game)
        {
            float vertical = Input.GetAxis(_controlsVertical);
            float horizontal = Input.GetAxis(_controlsHorizontal);

            //look at center of table
            this.transform.LookAt(_tableRef.transform.position);

            //move around pizza
            //ABSOLUTE CONTROLS
//        Vector3 target = new Vector3(_tableRef.bounds.extents.x * horizontal, 
//            _tableRef.transform.position.y,
//            _tableRef.bounds.extents.z * vertical);
//
//        transform.position = Vector3.Lerp(this.transform.position, target, Time.deltaTime);

            //RELATIVE CONTROLS
            //transform.RotateAround(_tableRef.transform.position, Vector3.down, horizontal * 2f);
            StartCoroutine(RotateObject(_tableRef.transform.position, Vector3.down, horizontal, _speed));
        }
	}
}
