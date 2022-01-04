using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainRotation : MonoBehaviour
{
    public float rotateAmount;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * rotateAmount * Time.deltaTime);
    }
}
