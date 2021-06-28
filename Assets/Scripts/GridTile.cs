using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTile : MonoBehaviour
{
    [SerializeField] GameObject applePrefab;
    GameObject Apple;  
    bool hasApple = false;
    // Start is called before the first frame update
    public bool HasApple()
    {
        return hasApple;
    }
    public bool SetApple()
    {
        if(hasApple == true)
        {
            return false;
        }
        else
        {
            applePrefab = Instantiate(applePrefab, transform.position, Quaternion.identity);
            applePrefab.transform.parent = transform;
            hasApple = true;
            return true;
        }
    }
    public bool TakeApple()
    {
        if (!hasApple)
        {
            return false;
        }
        else
        {
            hasApple = false;
            Destroy(Apple.gameObject);
            Apple = null;
            return true;
        }
    }
}
