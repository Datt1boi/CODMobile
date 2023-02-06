using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
public class ColorChanger : MonoBehaviour
{
    public Color startColor;
    private Vector3 startColorv3;
    public Color nextColor;
    private Vector3 nextColorv3;
    public Color midColor;
    private Vector3 midColorv3;
    // Start is called before the first frame update
    void Start()
    {
        nextColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        nextColorv3.x = nextColor.r;
        nextColorv3.y = nextColor.g;
        nextColorv3.z = nextColor.b;
        startColorv3.x = startColor.r;
        startColorv3.y = startColor.g;
        startColorv3.z = startColor.b;
        midColorv3 = startColorv3;
    }

    // Update is called once per frame
    void Update()
    {
        midColorv3 = Vector3.MoveTowards(midColorv3, nextColorv3, 0.001f);
        midColor.r = midColorv3.x;
        midColor.g = midColorv3.y;
        midColor.b = midColorv3.z;
        midColor.a = 1;
        GetComponent<UnityEngine.U2D.SpriteShapeRenderer>().color = midColor;
        if(midColor == nextColor)
        {
            CalculateNewColor();
        }
    }
    void CalculateNewColor()
    {
        startColor = nextColor;
        nextColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        nextColorv3.x = nextColor.r;
        nextColorv3.y = nextColor.g;
        nextColorv3.z = nextColor.b;
        startColorv3.x = startColor.r;
        startColorv3.y = startColor.g;
        startColorv3.z = startColor.b;
    }
}
