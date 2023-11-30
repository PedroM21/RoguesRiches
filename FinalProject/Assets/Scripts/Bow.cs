using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    private Camera mainCam;
    public GameObject arrow;
    public Transform arrowTransform;

    public float timeBetweenShooting = 0.82f;
    public bool canShoot = true;
    public AudioClip bowSound;

    private void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && canShoot)
        {
            ShootArrow();
            Invoke("EnableShooting", timeBetweenShooting);
        }
    }

    private void ShootArrow()
    {
        canShoot = false;
        AudioSource.PlayClipAtPoint(bowSound, transform.position);
        Instantiate(arrow, arrowTransform.position, Quaternion.identity);
    }

    private void EnableShooting()
    {
        canShoot = true;
    }

}