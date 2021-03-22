using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Sel : MonoBehaviour
{
    public Button b;







    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    public void Pressed()
    {
        S.clicked(b.transform.name);

    
    }
}
