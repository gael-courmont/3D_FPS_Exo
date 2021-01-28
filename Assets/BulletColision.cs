using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletColision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        GameObject ScoreCount= GameObject.Find("Text") as GameObject;
        ScoreCount.SendMessageUpwards("IncrementScore");
        Destroy(other.gameObject);
        Destroy(this.gameObject);
    }
}
