using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private int ScoreValue = 4;
    public float speed = 0;

    private Rigidbody rb;

    private float movementX;
    private float movementY;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _scoreTexte;
    [SerializeField] public GameObject flame;
    public delegate void MessageEvent();
    public static event MessageEvent ObjetToucher;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _scoreText.text = "Score : " + ScoreValue;
        _scoreTexte.text = "Score :" + ScoreValue;
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f)
        {
            _rigidbody.AddForce(Input.GetAxis("Horizontal") * 0.5f, 0f, Input.GetAxis("Vertical"));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Target_Trigger"))
        {
            Destroy(other.gameObject);
            ObjetToucher.Invoke();

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target") || (collision.gameObject.CompareTag("TargetGreen")))
        {
            Instantiate(flame, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            UpdateScore(collision);
            ObjetToucher.Invoke();
        }
    }
    private void UpdateScore(Collision col)

    {
        if (col.gameObject.tag == "TargetGreen") // Si on touche un objet vert , le score augmente de 1
        {

            ScoreValue++;
        }
        else
        {
            ScoreValue--;
        }
        _scoreText.text = "Score : " + ScoreValue;


    }




    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        _rigidbody.AddForce(movement * speed);
    }
}

