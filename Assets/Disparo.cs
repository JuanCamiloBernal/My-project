using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    [SerializeField] GameObject Bullet;
    [SerializeField] GameObject Bullet_2;
    public float firerate = 0.5f;
    public float firerate2 = 1f;
    float nextfire = 0.0f;
    public float carga;
    public int etapa;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextfire)
        {
            nextfire = Time.time + firerate;
            fire();
        }
        if (Input.GetKey(KeyCode.F) && Time.time > nextfire)
        {
            nextfire = Time.time + firerate2;
            carga_skill();
        }
        void fire()
        {
            Instantiate(Bullet, transform.position, transform.rotation);
        }

        void carga_skill()
        {
            Instantiate(Bullet_2, transform.position, transform.rotation);
            //if (Input.GetKey(KeyCode.F))
            //{
            //    carga += 1 * Time.deltaTime;
            //}

            //if (carga >= 1)
            //{
            //    carga = 0;
            //    if (etapa <= 1)
            //    {
            //        etapa += 1;
            //    }
            //}
            //if (Input.GetKey(KeyCode.F))
            //{
            //    switch (etapa)
            //    {
            //        case 1:
            //            Instantiate(Bullet_2, transform.position, transform.rotation);
            //            break;

            //    }
            //    carga = 0;
            //    etapa = 0;
            //}
        }

    }
}

