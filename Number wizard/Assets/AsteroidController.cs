using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{

    [SerializeField] private Vector3 _rotation;
    [SerializeField] private Vector3 desiredRageAcc, desiredIdle,desiredIdleFast;
    [SerializeField] private float rageAccSpeed, RageDecSpeed, idleAccSlow, idleAccFast;
    [SerializeField] private bool isAccelerating;
    [SerializeField] private int AccelerationState;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(_rotation * Time.deltaTime, Space.Self);

        /*if (isAccelerating)
        {
            _rotation = Vector3.Lerp(_rotation, desiredAcceleration, accelerationSpeed * Time.deltaTime);
        }
        else
        {
            _rotation = Vector3.Lerp(_rotation, desiredDeceleration, decelerationSpeed * Time.deltaTime);
        }*/
        if(AccelerationState == 0)
        {
            _rotation = Vector3.Lerp(_rotation, desiredIdle, idleAccSlow * Time.deltaTime);
        }
        if(AccelerationState == 1)
        {
            _rotation = Vector3.Lerp(_rotation, desiredIdleFast, idleAccFast * Time.deltaTime);
        }
        if(AccelerationState == 2)
        {
            _rotation = Vector3.Lerp(_rotation, desiredRageAcc, rageAccSpeed * Time.deltaTime);
        }
        if(AccelerationState == 3)
        {
            _rotation = Vector3.Lerp(_rotation, desiredIdle, RageDecSpeed * Time.deltaTime);
        }
    }


    public void IdleSlow()
    {
        //isAccelerating = false;
        AccelerationState = 0;
    }

    public void IdleFast()
    {
        //isAccelerating = true;
        AccelerationState = 1;
    }
    public void RageAccelarate()
    {
        //isAccelerating = true;
        AccelerationState = 2;
    }
    public void RageDecelarate()
    {
        //isAccelerating = false;
        AccelerationState = 3;
    }
}
