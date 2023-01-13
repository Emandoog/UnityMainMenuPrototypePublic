using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeTansition : MonoBehaviour
{
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
   public void FadeInEnd()
    {
        ScenesManager.Instance.TransistionOut();
    
    
   }
    public void FadeOutEnd() 
    {
        gameObject.SetActive(false);


    }
}
