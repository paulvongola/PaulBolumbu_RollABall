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
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target") || (collision.gameObject.CompareTag("TargetGreen")))
        {
            Destroy(collision.gameObject);
            UpdateScore();
        }
    }
    private void UpdateScore()
    {
        ScoreValue++;
        _scoreText.text = "Score : " + ScoreValue;
    }

    private void UpdateScoreNegative()
    {
        ScoreValue--;
        _scoreTexte.text = "Score : " + ScoreValue;
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


    /*public Scene _scene;

    public static Player instance;*/
    //private void Awake()
    //{
    //    if (instance != null)
    //    {
    //        Destroy(gameObject);
    //        return;
    //    }

    //    instance = this;
    //    DontDestroyOnLoad(gameObject);
    //}
    /*
        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();

            _scene = SceneManager.GetActiveScene();

            Debug.Log("La scène active est '" + _scene.name + "'. index= " + _scene.buildIndex);



        }*/

}