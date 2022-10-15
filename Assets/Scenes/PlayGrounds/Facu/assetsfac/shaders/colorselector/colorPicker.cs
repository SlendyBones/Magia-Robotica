using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using System;

[Serializable]
public class ColorEvent: UnityEvent<Color> { }

public class colorPicker : MonoBehaviour
{
    public float colornumer;
    public Material pjm;
    public Material outline;
    public Material eyes;
    public TextMeshProUGUI debugText;
    public ColorEvent OnColorPreview;
    public ColorEvent OnColorprimary;
    public ColorEvent OnColorSecundary;
    public ColorEvent OnColorEyes;
    RectTransform Rect;
    Image colorbox;
    Texture2D colortexture;
    
    // Start is called before the first frame update
    void Start()
    {
        Rect = GetComponent<RectTransform>();

        colortexture = GetComponent<Image>().mainTexture as Texture2D;
    }

    // Update is called once per frame
    void Update()
    {
        if(RectTransformUtility.RectangleContainsScreenPoint(Rect, Input.mousePosition))
        { 
        Vector2 delta;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(Rect, Input.mousePosition, null, out delta  );
        string debug = "mousePosition=" + Input.mousePosition;
        debug += "<br>delta="+ delta;

        float width = Rect.rect.width;
        float height = Rect.rect.width;
        delta += new Vector2(width * 0.5f, height*0.5f);
        debug += "<br>offset delta=" + delta;

        float x = Mathf.Clamp(delta.x / width, 0f, 1f);
        float y = Mathf.Clamp(delta.y / height, 0f, 1f);

        debug += "<br>x=" +x+"y="+y;

        int texX = Mathf.RoundToInt(x * colortexture.width);
        int texy = Mathf.RoundToInt(y * colortexture.height);
        debug += "<br>texX=" + texX + "texY=" + texy;
        
        
            
        Color color = colortexture.GetPixel(texX, texy);
        
       if(color.a!=0)
       {

            
        debugText.color = color;

        debugText.text = debug;

        OnColorPreview?.Invoke(color);

        if(Input.GetMouseButtonDown(0))
        {
                    switch (colornumer)
                    {
                        case 0:
                            pjm.SetVector("Color_9af90b6a8db54b21aeee5f58226d9961", color);
                            outline.SetVector("Color_b45d3ce73a49432cb9e14e1fda70b4bd", color);

                            break;
                        case 1:
                            pjm.SetVector("Color_a08d51509e524380a91a5dc923146f33", color);
                            outline.SetVector("Color_3e9db1a14e5b42f48784a2cc34a784aa", color);
                            break;
                        case 2:
                            eyes.SetVector("_eyecolor", color);
                            break;
                  
                        default:
                            
                            break;
                    }
                    colorbox.color = color;
                   // OnColorprimary?.Invoke(color);
                    


                }
        }

    }
    }

    public void colortochange(int a  )
    {
        Debug.Log("a");
       // colorbox = b.gameObject.GetComponent<Image>();
        colornumer = a;
    }
    public void changecolorimage(GameObject a)
    {
        colorbox = a.GetComponent<Image>();
     

    }
}
