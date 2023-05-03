using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGenerator : MonoBehaviour
{
    public GameObject targetPrefab;
    float span = 0.75f;
    float delta = 0f;
    //float delta2 = 0f;
    float _time = 0f;
    GameObject director;
    // Start is called before the first frame update
    void Start()
    {
        director = GameObject.Find("GameDirector");
        this._time = director.GetComponent<GameDirector>().time;
        GameObject t1 = Instantiate(targetPrefab);
        GameObject t2 = Instantiate(targetPrefab);
        GameObject t3 = Instantiate(targetPrefab);
        GameObject t4 = Instantiate(targetPrefab);
        t1.transform.position = new Vector3(3, 6, -995);
        t2.transform.position = new Vector3(1, 6, -995);
        t3.transform.position = new Vector3(-1, 6, -995);
        t4.transform.position = new Vector3(-3, 6, -995);
    }

    // Update is called once per frame
    void Update()
    {
        this._time -= Time.deltaTime;
        if (this._time > 0f)
        {

            this.delta += Time.deltaTime;
            // this.delta2 += Time.deltaTime;
            if (this._time <= 70.0f && this._time > 55.0f)
            {

            }
            if (this._time <= 70.0f && this._time > 40.0f)
            {
                if (this.delta > this.span)
                {
                    this.delta = 0;
                    GameObject target = Instantiate(targetPrefab);
                    float x = Random.Range(-7, 8);
                    float y = Random.Range(6, 12);
                    float z = Random.Range(-995, -984);
                    target.transform.position = new Vector3(x, y, z);
                    
                    // target.transform.Rotate(90.0f, 0f, 0f);
                    //if (this.delta2 > this.span * 10)
                    //{
                    //    this.delta2 = 0;
                    // DestroyAll();
                    //}
                }

            }
            if (this._time <= 34.0f && this._time > 0f)
            {
                if (this.delta > (this.span - 0.4f))
                {
                    this.delta = 0;
                    GameObject target = Instantiate(targetPrefab);
                    float x = Random.Range(200, 230);
                    float y = Random.Range(10, 16);
                    float z = Random.Range(-780, -810);
                    target.transform.position = new Vector3(x, y, z);
                    
                }
            }


        }

    }

    void DestroyAll()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Target");

        foreach (GameObject gameObj in gameObjects)
        {
            Destroy(gameObj);
        }
    }
}
