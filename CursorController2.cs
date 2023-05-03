using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
// using XInputDotNetPure;

public class CursorController2 : MonoBehaviour
{
    //bool playerIndexSet = false;
    //PlayerIndex playerIndex;
    //GamePadState state;
    //GamePadState prevState;
    float maxIconSpeed = Screen.width * 3f / 4f;
    float initIconSpeed = Screen.width * 3f / (4f * 2f);
    float iconSpeed;
    RectTransform rect;
    Vector2 offset;
    bool isTriggered;
    Canvas canvas;
    GameObject director;
    RaycastHit hit;
    bool prevHit = false;
    int comboValue = 1;
    float comboTimer = 1.25f;
    //float strongness;

    //void FixedUpdate()
    //{
       // if (state.Buttons.A == ButtonState.Pressed)
        //{
           // GamePad.SetVibration(playerIndex, 0f, 1.0f);

           // StartCoroutine(DelayMethod(0.3f, () =>
            //{
               // GamePad.SetVibration(playerIndex, 0f, 0f);
            //}));
        //}

        // SetVibration should be sent in a slower rate.
        // Set vibration according to triggers
        // GamePad.SetVibration(playerIndex, 1.0f, 1.0f);
    //}
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        director = GameObject.Find("GameDirector");
        rect = GetComponent<RectTransform>();
        offset = new Vector2(rect.sizeDelta.x / 2.0f, rect.sizeDelta.y / 2.0f);
        isTriggered = false;

        transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        //Debug.Log(transform.localScale);
    }

    // Update is called once per frame
    void Update()
    {
        if (comboTimer > 0f)
        {
            comboTimer -= Time.deltaTime;
        }
        if (comboTimer <= 0f)
        {
            comboValue = 0;
        }
        //if (!playerIndexSet || !prevState.IsConnected)
        //{
           // for (int i = 0; i < 4; ++i)
            //{
               // PlayerIndex testPlayerIndex = (PlayerIndex)i;
                //GamePadState testState = GamePad.GetState(testPlayerIndex);
                //if (testState.IsConnected)
                //{
                    // Debug.Log(string.Format("GamePad found {0}", testPlayerIndex));
                   // playerIndex = testPlayerIndex;
                   // playerIndexSet = true;
                //}
            //}
       // }
        //prevState = state;
        //state = GamePad.GetState(playerIndex);
        if (Input.GetAxis("RTrigger") == 0f)
        {
            isTriggered = false;
        }
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("joystick button 0") || (Input.GetAxis("RTrigger") > 0f && !isTriggered))
        {
            isTriggered = true;
            
            //Debug.Log(transform.localScale);
            GetComponent<AudioSource>().Play();
            
            //
            // isTriggered = true;
            // Debug.Log(isTriggered);
            // Debug.Log(Input.GetAxis("RTrigger"));
            // Debug.Log(Time.time);
            Ray ray = Camera.main.ScreenPointToRay(GetUIScreenPos(rect));
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                // Debug.Log(hit.collider.gameObject.CompareTag("Target"));
                if (hit.collider.gameObject.CompareTag("Target"))
                {

                    Destroy(hit.collider.gameObject); // 自分自身を消す→衝突したオブジェクトを消してるぽい
                    if (comboTimer > 0f)
                    {
                        // Debug.Log(comboValue);
                        comboValue++;
                        comboTimer = 1.25f;
                        if (comboValue == 2)
                        {
                            director.GetComponent<GameDirector>().ShootTarget2();
                        }
                        if (comboValue == 3)
                        {
                            director.GetComponent<GameDirector>().ShootTarget3();
                        }
                        if (comboValue == 4)
                        {
                            director.GetComponent<GameDirector>().ShootTarget4();
                        }
                        if (comboValue >= 5)
                        {
                            director.GetComponent<GameDirector>().ShootTarget5();
                        }
                    }
                    else
                    {
                        comboValue = 1;
                        comboTimer = 1.25f;
                        director.GetComponent<GameDirector>().ShootTarget1();
                    }
                    // prevHit = true;
                } else
                {
                    // prevHit = false;
                }
            } else
            {
                // prevHit = false;
            }
            //
        }
        if (Input.GetKey("joystick button 0"))
        {
            transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
        } else
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }

        if (Input.GetAxis("RTrigger") == 0f || Input.GetKeyUp("joystick button 0"))
        {
            isTriggered = false;
            //transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            //Debug.Log(transform.localScale);
        }
        if (Mathf.Approximately(Input.GetAxis("Horizontal"), 0f) && Mathf.Approximately(Input.GetAxis("Vertical"), 0f))
        {
            this.iconSpeed = this.initIconSpeed;
        } else
        {
            if (this.iconSpeed < this.maxIconSpeed)
            {
                this.iconSpeed = this.iconSpeed * 1.1f;
                Debug.Log(this.iconSpeed);
            } else
            {
                this.iconSpeed = this.maxIconSpeed;
            }
        }

        var pos = rect.anchoredPosition + new Vector2(Input.GetAxis("Horizontal") * iconSpeed, Input.GetAxis("Vertical") * iconSpeed) * Time.deltaTime;
        
        

        pos.x = Mathf.Clamp(pos.x, -Screen.width * 0.5f, Screen.width * 0.5f);
        pos.y = Mathf.Clamp(pos.y, -Screen.height * 0.5f, Screen.height * 0.5f);

        rect.anchoredPosition = pos;
    }

    Vector2 GetUIScreenPos(RectTransform rt)
    {
        return RectTransformUtility.WorldToScreenPoint(canvas.worldCamera, rt.position);
    }

    //public void PlayVibration()
    //{
       // float motorPower = 1.0f;
        //XInputDotNetPure.GamePad.SetVibration(0, motorPower, motorPower);
    //}

    //private IEnumerator DelayMethod(float waitTime, Action action)
    //{
       // yield return new WaitForSeconds(waitTime);
       // action();
    //}
}
