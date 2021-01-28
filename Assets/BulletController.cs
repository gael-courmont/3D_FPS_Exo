using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private const float LifeSpan = 3f;

    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyIn3Second());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator DestroyIn3Second()
    {   yield return new WaitForSeconds(3f);
        Destroy(gameObject);

    }
}
