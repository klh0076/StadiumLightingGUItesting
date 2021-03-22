using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S : MonoBehaviour
{
    public Canvas cv;
    public GameObject D;
    public Button blueBtn;
    public Button orangeBtn;
    public Button whiteBtn;
    public Button r0;
    public Button r1;
    public Button r2;
    public Button r3;
    public Button c0;
    public Button c1;
    public Button c2;
    public Button c3;
    public Button all;

    public static int n = 16;
    public Color onN;
    public Color offN;
    public Color blueN;
    public Color orangeN;
    
    public static Color on;
    public static Color off;
    public static Color blue;
    public static Color orange;
    
    public static GameObject[] g = new GameObject[n];
    public static int[] chosen = new int[n];
    public static int[] cValue = new int[n];

    void Start()
    {
        //set colors
        on = onN;
        off = offN;
        blue = blueN;
        orange = orangeN;
      
        // set postion
        float posX = D.GetComponent<RectTransform>().position.x;
        float posY = D.GetComponent<RectTransform>().position.y;
        posX -= 200;
        float initX = posX;
        posY -= 345;

        // dynamically create pixel objects
        for (int i = 0; i < n; i++ ) {
                g[i] = Instantiate(D);
                g[i].transform.SetParent(transform.Find("Panel1"));
                g[i].transform.localPosition = new Vector3(posX, posY);
                g[i].transform.name = "" + i; 
                posX += 50;                        
            if (i == 3 || i == 7 || i == 11)
            {
                posY -= 50;
                posX = initX;
            }
        }
        blueBtn.onClick.AddListener(() => colorChange(1));
        orangeBtn.onClick.AddListener(() => colorChange(2));
        whiteBtn.onClick.AddListener(() => colorChange(3));
        r0.onClick.AddListener(() => selectRow(0));
        r1.onClick.AddListener(() => selectRow(1));
        r2.onClick.AddListener(() => selectRow(2));
        r3.onClick.AddListener(() => selectRow(3));
        c0.onClick.AddListener(() => selectCol(0));
        c1.onClick.AddListener(() => selectCol(1));
        c2.onClick.AddListener(() => selectCol(2));
        c3.onClick.AddListener(() => selectCol(3));

        all.onClick.AddListener(() => selectAll());
    } 

    public static void clicked(string index)
    {
        int k = int.Parse(index);
        if (chosen[k] == 0)
        {
            chosen[k] = 1;
            g[k].GetComponent<Button>().image.color = on;
        }
        else 
        {
            chosen[k] = 0;
            Color x = off;
            if (cValue[k] == 1) { x = blue; }
            else if (cValue[k] == 2) { x = orange; }
            else { x = off; }
            g[k].GetComponent<Button>().image.color = x;
        }
    }
    


    public static void colorChange(int c)
    {
        for (int i = 0; i < n; i++)
        {
            if (chosen[i] == 1)
            {
                cValue[i] = c;
                Color x = off;

                if (c == 1) { x = blue; }
                else if (cValue[i] == 2) { x = orange; }
                else { x = off;  }
                g[i].GetComponent<Button>().image.color = x;
                chosen[i] = 0;
            }
            else
            {
                if (cValue[i] == 1)
                {
                    g[i].GetComponent<Button>().image.color = blue;
                }
                else if (cValue[i] == 2)
                {
                    g[i].GetComponent<Button>().image.color = orange;
                }
                else 
                {
                    g[i].GetComponent<Button>().image.color = off;
                }

            }
            
        }
    }

    public static void selectRow(int r)
    {
        if (r == 0)
        {
            for (int i = 12; i < 16; i++)
            {
                clicked(i.ToString());
            }
        }
        else if (r == 1)
        {
            for (int i = 8; i < 12; i++)
            {
                clicked(i.ToString());
            }
        }
        else if (r == 2)
        {
            for (int i = 4; i < 8; i++)
            {
                clicked(i.ToString());
            }
        }
        else if (r == 3)
        {
            for (int i = 0; i < 4; i++)
            {
                clicked(i.ToString());
            }
        }
    }

    public static void selectCol(int c)
    {
        if (c == 0)
        {
            for (int i = 0; i < 16; i += 4)
            {
                clicked(i.ToString());
            }
        }
        else if (c == 1)
        {
            for (int i = 1; i < 16; i += 4)
            {
                clicked(i.ToString());
            }
        }
        else if (c == 2)
        {
            for (int i = 2; i < 16; i += 4)
            {
                clicked(i.ToString());
            }
        }
        else if (c == 3)
        {
            for (int i = 3; i < 16; i += 4)
            {
                clicked(i.ToString());
            }
        }
    }

    public static void selectAll()
    {
        for (int i = 0; i < n; i++)
        {
            clicked(i.ToString());
        }
    }
}
