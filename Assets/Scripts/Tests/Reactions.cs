using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reactions : MonoBehaviour
{
    public Text text;
    
    public void Right()
    {
        text.text = "right";
    }
    
    public void Left()
    {
        text.text = "left";
    }
    
    public void Up()
    {
        text.text = "up";
    }
    
    public void Down()
    {
        text.text = "down";
    }
}
