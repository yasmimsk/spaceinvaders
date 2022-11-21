using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptPC : MonoBehaviour
{
    private Rigidbody2D rdb;
    public float velocidade;
    private float largura;
    private float altura;
    public GameObject tiro;
    private AudioSource som;

    // Start is called before the first frame update
    void Start()
    {
        rdb = this.GetComponent<Rigidbody2D>();
        som = GetComponent<AudioSource>();
        velocidade = 15;
        altura = Camera.main.orthographicSize;
        largura = altura * Camera.main.aspect; //proporção da tela
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        rdb.velocity = new Vector2(x, y) * velocidade;

        VerificarBordas();
        VerificarTiro();
    }

    private void VerificarBordas()
    {
        if (transform.position.x < -largura)
            transform.position = new Vector2(largura, transform.position.y);
        else if (transform.position.x > largura)
            transform.position = new Vector2(-largura, transform.position.y);

        if (transform.position.y < -altura)
            transform.position = new Vector2(transform.position.x, -altura);
        else if (transform.position.y > 0)
            transform.position = new Vector2(transform.position.x, 0);
    }

    private void VerificarTiro()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            som.Play();
            Vector2 pos = new Vector2(transform.position.x, transform.position.y + 1);
            Instantiate(tiro, pos, Quaternion.identity);
        }
    }
}
