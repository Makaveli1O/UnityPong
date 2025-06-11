using System;
using UnityEngine;

public class Block : MonoBehaviour
{
    private void OnCollisionExit2D()
    {
        Destroy(gameObject);
        Debug.Log("Block destroyed");
    }
}
