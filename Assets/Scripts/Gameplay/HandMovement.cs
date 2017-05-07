using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour {

    private float _zOffset = 0f;
    private float _speed = 1f;

    private float _speedMod = 2f;
    private float _dashMod = 50f;
    private float _dashCoolDown = 1f;

    private float minForce = -13f;
    private float maxForce = -7f;

    private bool _dashUsed = false;
    public bool _dashAvailable = true;

    private CapsuleCollider _tableRef;
    private Player _playerRef;

    private string _controlsVertical;
    private string _controlsHorizontal;
    private string _controlsDash;
    private string _controlsAction;

    //_ME
    private DoughPulling pullDoughScript;

    private void Awake () 
    {
        SetupVariables();
        pullDoughScript = gameObject.GetComponentInChildren<DoughPulling>();
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
        _controlsDash = Constants.CONTROLS_DASH + _playerRef.PlayerNumber;
        _controlsAction = Constants.CONTROLS_ACTION + _playerRef.PlayerNumber;
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

    private IEnumerator UseDash ()
    {
        _dashUsed = true;
        _dashAvailable = false;

        yield return new WaitForSeconds(_dashCoolDown);

        _dashUsed = false;
    }
	
	// Update is called once per frame
	void Update () 
    {
        if (GameManager.Instance.GameState == Constants.GameState.game)
        {
            //speed mod

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

            //BOOSTING
            float dashMod = 1f;

            //reset dash if trigger not down
            if ((Input.GetAxis(_controlsDash) <= Constants.CONTROLLER_TRIGGER_DEAD_ZONE &&
                Input.GetAxis(_controlsDash) >= -Constants.CONTROLLER_TRIGGER_DEAD_ZONE) && 
                _dashUsed == false && _dashAvailable == false)
            {
                _dashAvailable = true;
            }


            if ((Input.GetAxis(_controlsDash) >= Constants.CONTROLLER_TRIGGER_DEAD_ZONE ||
                Input.GetAxis(_controlsDash) <= -Constants.CONTROLLER_TRIGGER_DEAD_ZONE) && 
                _dashUsed == false && _dashAvailable == true)
            {
                StartCoroutine(UseDash());
                dashMod = _dashMod*Mathf.Abs(Input.GetAxis(_controlsDash));
            }

            float rotAmount = horizontal * _speedMod * dashMod;

            //RELATIVE CONTROLS
            //transform.RotateAround(_tableRef.transform.position, Vector3.down, horizontal * 2f);
            StartCoroutine(RotateObject(_tableRef.transform.position, Vector3.down, rotAmount, _speed));

            //ACTION
            if (Input.GetButtonDown(_controlsAction))
            {
                //animation
                if (_playerRef.ActiveTopping == Constants.Toppings.dough)
                {
                    _playerRef.PlayAnimation(Constants.ANIMATION_PLAYER_GRIP);
                    Debug.Log("PULL");
                    pullDoughScript.PULLDOUGH();
                    PizzaManager.SharedInstance.doughMeshScript.FixMyMeshCollider();
                }
                else
                {
                    _playerRef.PlayAnimation(Constants.ANIMATION_PLAYER_THROW);

                    //action
                    //firetoppings
                    PizzaToppingUnifier NewTopping = ObjectPooler.SharedInstance.GetTopping(_playerRef.ActiveTopping);
                    if (NewTopping != null)
                    {
                        {
                            Vector3 target = _playerRef.transform.position + _tableRef.transform.position;
                            Vector3 spawnPos = gameObject.transform.position + Random.onUnitSphere * 0.6f;
                            NewTopping.transform.position = spawnPos;
                            NewTopping.gameObject.SetActive(true);
                            NewTopping.Rigidbody.AddForce(target.normalized * Random.Range(minForce, maxForce), ForceMode.VelocityChange);
                        }

                    }
                }
            }
 
        }
	}
}
