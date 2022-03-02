using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject bullet_2;
    private bool typeOfShot;
    private float canFire, T, carga;
    [SerializeField] float nextFire;
    // Start is called before the first frame update
    void Start()
    {
        typeOfShot = false;  

    }

    // Update is called once per frame
    void Update()
    {
        fire();
    }
    void fire()
    {

        if (Input.GetKeyDown(KeyCode.Z))
        {
            typeOfShot = !typeOfShot;
        }

        if (!typeOfShot)
        {
            if (Input.GetKeyDown(KeyCode.Space) && Time.time >= canFire)
            {
                Instantiate(bullet, transform.position, transform.rotation);
                canFire = Time.time + nextFire;
            }
        }
        else
        {

            if (Input.GetKeyDown(KeyCode.Space) && Time.time >= canFire)
            {
                    Instantiate(bullet_2, transform.position, transform.rotation);
                    canFire = Time.time + nextFire;
            }
        }

    }
}
