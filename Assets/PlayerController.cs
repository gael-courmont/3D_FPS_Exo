using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform selfTransform;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Transform spheresHolderTransform;
    [SerializeField] private Transform spawnPointTransform;
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private float speed = 0.1f;
    [SerializeField] private float cameraSensibility = 0.1f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void Update()
    {
        MovePlayer();
        RotateCamera();
        Shoot();
    }

    private void MovePlayer()
    {
        Vector3 cameraRight = cameraTransform.right;
        Vector3 cameraForward = cameraTransform.forward;

        Vector3 deltaPosition =
            new Vector3(cameraRight.x, 0f, cameraRight.z) * Input.GetAxis("Horizontal")
            + new Vector3(cameraForward.x, 0f, cameraForward.z) * Input.GetAxis("Vertical");


        //deplacement du joueur
        playerRigidbody.MovePosition(playerRigidbody.position + deltaPosition * speed);

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
    }

    private void RotateCamera()
    {
        cameraTransform.eulerAngles += new Vector3(
            Input.GetAxis("Mouse X"),
            Input.GetAxis("Mouse Y"),
            0f) * cameraSensibility;
    }

    private void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {   Debug.Log("Fire1");
            GameObject sphere =  Instantiate(Resources.Load("Bullet"),
                spawnPointTransform.position,
                Quaternion.identity,
                spheresHolderTransform) as GameObject;
            sphere.GetComponent<Rigidbody>().AddForce(cameraTransform.forward * 2000f);
        }
    }
}
