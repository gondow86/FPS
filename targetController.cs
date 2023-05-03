using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetController : MonoBehaviour
{
    float lifeTime = 5.0f;
    public float speed = 0.1f;
    float xpos;
    float ypos;
    float zpos;
    float delta;
    // Canvas canvas;
    // GameObject cursor;
    // RectTransform _imageRect;
    bool isTriggered;
    //static float _time = 70.0f;
    // GameObject director;
    // RaycastHit hit;
    int r;

    // Start is called before the first frame update
    void Start()
    {
        // canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        // cursor = GameObject.Find("Cursor");
        // _imageRect = cursor.GetComponent<RectTransform>();
        this.xpos = transform.position.x;
        this.ypos = transform.position.y;
        this.zpos = transform.position.z;
        // isTriggered = false;
        this.tag = "Target";
        r = Random.Range(0, 2);
        // this.director = GameObject.Find("GameDirector");
    }

    // Update is called once per frame
    void Update()
    {
        //_time -= Time.deltaTime;
        delta += Time.deltaTime;
        
        // transform.Translate(this.speed * Mathf.Sin(Time.time), 0, 0);
        if (delta > lifeTime)
        {
            Destroy(gameObject);
        }

        if (this.xpos > 200 && this.zpos > -810 )
        {
            transform.position = new Vector3(xpos + 1.5f * Mathf.Cos(1.5f * delta), ypos + 2f * Mathf.Sin(1.5f * delta), zpos);
            this.transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(90.0f, 65.0f, 0f), 320.0f * Time.deltaTime);
        } else
        {
            // Debug.Log(this.r);
            if (r == 0 && (this.lifeTime > 4.9f && this.transform.position.y != 6 && this.transform.position.z != -995))
            {
                transform.position = new Vector3(xpos + 2f * Mathf.Sin(delta), ypos, zpos);
            } else if ((this.lifeTime > 4.9f && this.transform.position.y != 6 && this.transform.position.z != -995))
            {
                transform.position = new Vector3(xpos, ypos + 2f * Mathf.Sin(delta), zpos);
            }
            
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(90.0f, 0f, 0f), 320.0f * Time.deltaTime);
            //Debug.Log(transform.rotation);
        }

        
        
        
    }

    
}
