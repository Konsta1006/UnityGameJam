using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pila : MonoBehaviour
{
    // Point A (Starting point)
    public Transform pointA;

    // Point B (Target point)
    public Transform pointB;

    // Total time taken to move from point A to point B
    public float moveTime = 2.0f;

    private bool _isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveToNextPoint());
    }

    IEnumerator MoveToNextPoint()
    {
        while (true)
        {
            yield return StartCoroutine(MoveToPoint(pointB.position));
            yield return StartCoroutine(MoveToPoint(pointA.position));
        }
    }

    IEnumerator MoveToPoint(Vector3 targetPosition)
    {
        _isMoving = true;
        Vector3 startPosition = transform.position;
        float startTime = Time.time;

        while (Time.time - startTime < moveTime)
        {
            float t = (Time.time - startTime) / moveTime;
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            yield return null;
        }

        transform.position = targetPosition;
        _isMoving = false;
    }
}
