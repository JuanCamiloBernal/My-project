using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] GameObject Empty;
    [SerializeField] GameObject Emptyy;
    [SerializeField] GameObject Half;
    [SerializeField] GameObject Halff;
    [SerializeField] GameObject Full;
    [SerializeField] GameObject Fulll;
    Rigidbody2D myBody;
    float minX, maxX, minY, maxY, Direccion;
    public int vidas;
    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();

        Lives();
        Launch();

        Vector2 esqInfIzq = (Camera.main).ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 esqSupDer = (Camera.main).ViewportToWorldPoint(new Vector2(1, 1));
        minX = esqInfIzq.x;
        maxX = esqSupDer.x;
        minY = esqInfIzq.y;
        maxY = esqSupDer.y;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Launch()
    {
        Direccion = Random.Range(-1, 1);
        if (Direccion < 0)
        {
            Direccion = -1;
        }
        else
        {
            Direccion = 1;
        }
    }
    void Lives()
    {
        switch (vidas)
        {
            case 1:
                Empty = Instantiate(Empty, new Vector2(transform.position.x, transform.position.y + 0.8f), transform.rotation);
                break;
            case 2:
                Half = Instantiate(Half, new Vector2(transform.position.x, transform.position.y + 0.8f), transform.rotation);
                break;
            case 3:
                Full = Instantiate(Full, new Vector2(transform.position.x, transform.position.y + 0.8f), transform.rotation);
                break;
            case 4:
                Full = Instantiate(Full, new Vector2(transform.position.x - 0.2f, transform.position.y + 0.8f), transform.rotation);
                Emptyy = Instantiate(Emptyy, new Vector2(transform.position.x + 0.2f, transform.position.y + 0.8f), transform.rotation);
                break;
            case 5:
                Full = Instantiate(Full, new Vector2(transform.position.x - 0.2f, transform.position.y + 0.8f), transform.rotation);
                Halff = Instantiate(Halff, new Vector2(transform.position.x + 0.2f, transform.position.y + 0.8f), transform.rotation);
                break;
            case 6:
                Full = Instantiate(Full, new Vector2(transform.position.x - 0.2f, transform.position.y + 0.8f), transform.rotation);
                Fulll = Instantiate(Fulll, new Vector2(transform.position.x + 0.2f, transform.position.y + 0.8f), transform.rotation);
                break;
        }
    }
        void FixedUpdate()
    {
        if (transform.position.x <= minX)
        {
            Speed = Speed * -1.0f;
        }
        if (transform.position.x >= maxX)
        {
            Speed = Speed * -1.0f;
        }
        myBody.velocity = new Vector2(Speed * Direccion, myBody.velocity.y);
        switch (vidas)
        {
            case 1:
                Empty.transform.position = new Vector2(transform.position.x, transform.position.y + 0.8f);
                break;
            case 2:
                Half.transform.position = new Vector2(transform.position.x, transform.position.y + 0.8f);
                break;
            case 3:
                Full.transform.position = new Vector2(transform.position.x, transform.position.y + 0.8f);
                break;
            case 4:
                Full.transform.position = new Vector2(transform.position.x - 0.2f, transform.position.y + 0.8f);
                Emptyy.transform.position = new Vector2(transform.position.x + 0.2f, transform.position.y + 0.8f);
                break;
            case 5:
                Full.transform.position = new Vector2(transform.position.x - 0.2f, transform.position.y + 0.8f);
                Halff.transform.position = new Vector2(transform.position.x + 0.2f, transform.position.y + 0.8f);
                break;
            case 6:
                Full.transform.position = new Vector2(transform.position.x - 0.2f, transform.position.y + 0.8f);
                Fulll.transform.position = new Vector2(transform.position.x + 0.2f, transform.position.y + 0.8f);
                break;
        }
    }
     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            vidas -= 1;
           
            switch (vidas)
            {

                case 0:
                    Object.Destroy(Empty, 0.0f);
                    Object.Destroy(gameObject, 0.0f);
                    break;
                case 1:
                    Empty = Instantiate(Empty, new Vector2(transform.position.x, transform.position.y + 0.8f), transform.rotation);
                    Object.Destroy(Half, 0.0f);
                    break;

                case 2:
                    Half = Instantiate(Half, new Vector2(transform.position.x, transform.position.y + 0.8f), transform.rotation);
                    Object.Destroy(Full, 0.0f);
                    break;
                case 3:
                    //Full = Instantiate(Full, new Vector2(transform.position.x, transform.position.y + 0.8f), transform.rotation);
                    Object.Destroy(Emptyy, 0.0f);
                    break;

                case 4:
                    //Full = Instantiate(Full, new Vector2(transform.position.x - 0.2f, transform.position.y + 0.8f), transform.rotation);
                    Emptyy = Instantiate(Emptyy, new Vector2(transform.position.x + 0.2f, transform.position.y + 0.8f), transform.rotation);
                    Object.Destroy(Halff, 0.0f);
                    break;
                case 5:
                    //Full = Instantiate(Full, new Vector2(transform.position.x - 0.2f, transform.position.y + 0.8f), transform.rotation);
                    Halff = Instantiate(Halff, new Vector2(transform.position.x + 0.2f, transform.position.y + 0.8f), transform.rotation);
                    Object.Destroy(Fulll, 0.0f);
                    break;

            }
        }
        else if (collision.gameObject.tag == "SuperBullet")
        {
            Object.Destroy(Fulll, 0.0f);
            Object.Destroy(Emptyy, 0.0f);
            Object.Destroy(Halff, 0.0f);
            Object.Destroy(Full, 0.0f);
            Object.Destroy(Half, 0.0f);
            Object.Destroy(Empty, 0.0f);
            Object.Destroy(gameObject, 0.0f);
        }

    }
}
