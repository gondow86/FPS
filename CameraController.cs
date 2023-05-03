using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    bool isB = false;
    bool isX = false;
    [SerializeField]
    private CinemachineVirtualCamera _virtualCamera;
    [SerializeField]
    private float _position = 0f;
    GameObject director;
    private float _time = 0f;


    private CinemachineTrackedDolly _dolly;
    // Start is called before the first frame update
    void Start()
    {
        _dolly = _virtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
        director = GameObject.Find("GameDirector");
        _time = director.GetComponent<GameDirector>().time;
    }

    // Update is called once per frame
    void Update()
    {
        this._time -= Time.deltaTime;
        
        if (this._time > 0f)
        {
            if (this._time <= 40.0f && this._time > 35.0f)
            {
                _position += Time.deltaTime;
                // Debug.Log("Execute");
                _virtualCamera.transform.rotation = Quaternion.RotateTowards(_virtualCamera.transform.rotation, Quaternion.Euler(0f, 45.0f, 0f), 45.0f * Time.deltaTime * 2.0f);
                _dolly.m_PathPosition = _position * 0.9f;
                
            }

            if (this._time <= 35.0f)
            {
                _dolly.m_PathPosition = 4.0f;
                if (Input.GetKeyDown("joystick button 1"))
                {
                    isB = true;
                    isX = false;
                }
                else if (Input.GetKeyDown("joystick button 2"))
                {
                    isX = true;
                    isB = false;
                }

                if (isB)
                {
                    _virtualCamera.transform.rotation = Quaternion.RotateTowards(_virtualCamera.transform.rotation, Quaternion.Euler(0f, 90.0f, 0f), 45.0f * Time.deltaTime);
                    // Debug.Log(isB);
                }

                if (isX)
                {
                    _virtualCamera.transform.rotation = Quaternion.RotateTowards(_virtualCamera.transform.rotation, Quaternion.Euler(0f, 45.0f, 0f), 45.0f * Time.deltaTime);
                }
            }
        }
    }
}
