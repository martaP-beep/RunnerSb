using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAnimation : MonoBehaviour
{
    public float amplitude = 0.5f; // Maksymalna wysokoœæ unoszenia
    public float speed = 1.0f;     // Prêdkoœæ unoszenia/opadania

    private Vector3 startPos;      // Pocz¹tkowa pozycja obiektu

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float yOffset = Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = new Vector3(startPos.x, startPos.y + yOffset, startPos.z);
    }
}
