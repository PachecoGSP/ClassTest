using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Parámetros de movimiento"), Space]
    [Tooltip("Velocidad de movimiento.")]
    public float speed;
    //Referencia al valor del axis horizontal.
    private float h;
    //Referencia al valor del axis vertical.
     private float v;
    //Vector de movimiento.
    private Vector2 movement;

    [Header("Límites de pantalla")]
    [Tooltip("Límite de movimiento en el eje x")]
    public float xLimit;
    [Tooltip("Límite de movimiento en el eje y")]
    public float yLimit;


    //Referencias
    //Referencia al rigidbody 2D
    private Rigidbody2D rb2;

    private void Awake() {
        rb2 = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        #region Axis
        //Recuperar los valores de los axis horizontales y verticales.
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        #endregion

        LimitsPositions();
    }

    private void FixedUpdate() {
        Movement();
    }

    /// <summary>
    /// Método que se encargará de realizar el movimiento del jugador.
    /// </summary>
    private void Movement() {
        //Generamos un vector de movimiento y lo normalizamos.
        movement = new Vector2(h, v).normalized;

        //Aplicamos el moviento sobre el jugador.
        rb2.MovePosition((Vector2)transform.position + movement * speed * Time.deltaTime);
    }

    private void LimitsPositions() {
        if (transform.position.x > xLimit) {
            transform.position = new Vector2(xLimit, transform.position.y);
        } else if (transform.position.x < -xLimit) {
            transform.position = new Vector2(-xLimit, transform.position.y);
        }

        if (transform.position.y > yLimit) {
            transform.position = new Vector2(transform.position.x, yLimit);
        }else if (transform.position.y < -yLimit) {
            transform.position = new Vector2(transform.position.x, -yLimit);
        }
    }
}
