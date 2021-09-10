using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public float RotationSpeed;
    private PlayerController Player;

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(new Vector3(0, 0, RotationSpeed * Time.deltaTime));
    }

}
