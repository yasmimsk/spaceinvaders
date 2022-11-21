using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptNPC : MonoBehaviour
{
    public float velocidade = 5;
    private Rigidbody2D rdb;
    private float altura;

    // Start is called before the first frame update
    void Start()
    {
        rdb = GetComponent<Rigidbody2D>();
        rdb.velocity = new Vector2(0, -velocidade);

        altura = Camera.main.orthographicSize;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        scriptPlacar.incrementarPlacar(10);

        Destroy(col.gameObject);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -altura)
            Destroy(gameObject);
    }
}
