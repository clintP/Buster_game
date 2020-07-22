using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class DebugText : MonoBehaviour
{
    public Text debugText;  // public if you want to drag your text object in there manually    

    // Start is called before the first frame update
    void Start()
    {
        debugText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseVector = Input.mousePosition;
        debugText.text = "X: " + mouseVector.x.ToString() + "\nY: " + mouseVector.y.ToString();  // make it a string to output to the Text object
    }
}
