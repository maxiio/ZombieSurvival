using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyRing : MonoBehaviour
{
    // Start is called before the first frame update

    bool hasKey = false;
    public void StoreKey()
    {
        hasKey = true;
    }

    public bool HasKey()
    {
        return hasKey;
    }
}
