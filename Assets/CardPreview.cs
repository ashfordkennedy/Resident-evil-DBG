using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPreview : MonoBehaviour
{
    public static CardPreview instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void SetCardPreview(string cardIdentifier)
    {


    }
}
