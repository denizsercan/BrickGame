using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour
{

    public float paddleSpeed = 1f;
    new AudioSource audio;

    private Vector3 playerPos = new Vector3(0, -9.5f, 0);

    void Update()
    {
        float xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);
        playerPos = new Vector3(Mathf.Clamp(xPos, -15f, 15f), 0f, 0f);
        transform.position = playerPos;

    }

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision col)
    {
        audio.Play();
    }
}