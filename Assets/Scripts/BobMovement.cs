using System;
using TMPro;
using UnityEngine;

public class BobMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private float speed = 5;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Animator bobAnimator;


    private float score = 0;
    void Start() { }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime);
        bobAnimator.SetFloat("Speed", speed);
        Debug.Log("Bob is running");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            score = score + 1;
            scoreText.text = "Score: " + score;
            Destroy(other.gameObject);
        }
    }
}