using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretWall : MonoBehaviour
{
    public void DestroyWall()
    {
        this.gameObject.SetActive(false);
    }
}
