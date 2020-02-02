using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldTransparency : MonoBehaviour
{
    private SpriteRenderer sprite;
    private float alphaLevel = 1f;
    private Shield shieldref;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        shieldref = FindObjectOfType<Shield>();
    }

    // Update is called once per frame
    void Update()
    {
        
         alphaLevel = shieldref.health / 100; 
        
        sprite.color = new Color(1, 1, 1, alphaLevel);
    }
}
