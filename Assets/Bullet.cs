using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject bullet;



    float VelX = 0;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(VelX,rb.velocity.y);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Object.Destroy(bullet, 0.0f);
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Bullet")) Destroy(this.gameObject);
    }
}
