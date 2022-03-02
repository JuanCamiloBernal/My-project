using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov : MonoBehaviour
{
    [SerializeField] float speed;
    

    float minX, maxX, minY, maxY;
    // Start is called before the first frame update
    void Start()
    {
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
        float DirH = Input.GetAxis("Horizontal");           //Moviento en X
        float DirV = Input.GetAxis("Vertical");             //Mov en y
        transform.Translate(new Vector2(DirH * speed * Time.deltaTime, DirV * speed * Time.deltaTime));
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, (float)(minX + 0.7), (float)(maxX - 0.7))
            , Mathf.Clamp(transform.position.y, (float)(minY + 0.7), (float)(maxY - 0.7))
            );
    }
}
