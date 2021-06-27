using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public static bool Active = true;
    [SerializeField] private float _movementSpeed;

    void Update()
    {
        if (Active)
            transform.position += new Vector3(0, 0, _movementSpeed * Time.deltaTime);
    }
}
