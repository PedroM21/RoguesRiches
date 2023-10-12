using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{

    //[SerializeField] AnimationStateChanger animationStateChanger;

    private Camera mainCam;
    public GameObject arrow;
    public Transform arrowTransform;

    public float timeBetweenShooting = 0.82f;
    private float timer = 0;
    public bool canShoot = true;

    private Vector3 mousePos;

    private void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    private void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        /*
        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);*/

        if (!canShoot)
        {
            timer += Time.deltaTime;
            if(timer > timeBetweenShooting)
            {
                canShoot = true;
                timer = 0;
            }
        }

        if(Input.GetMouseButtonDown(0) && canShoot)
        {
            canShoot = false;
            timer = timeBetweenShooting;
            Instantiate(arrow, arrowTransform.position, Quaternion.identity);
            //animationStateChanger.ChangeAnimationState("Attack");
        }

        if (canShoot)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                canShoot = true;
                
            }
        }
    }

}
