using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    float oldSpeed = 20f;
    float boostedAt;
    float boostLength = 1;

    [SerializeField] float steerSpeed = 300f;
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;

    private void Update()
    {
        if (boostedAt > 0 && (Time.time - boostedAt >= boostLength))
        {
            moveSpeed = oldSpeed;
            boostedAt = 0;
        }
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Boost")
        {
            oldSpeed = moveSpeed;
            moveSpeed = boostSpeed;
            boostedAt = Time.time;
        }
    }
}
