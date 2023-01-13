using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BackgroundBat : MonoBehaviour
{
    private Rigidbody2D RB2D;
    private float direction = 1;
    private float panicMultiply = 2;
   // private int layer = 70;
    //private bool flip = false;
    private SpriteRenderer SpriteRend;
    private Animator batAnimator;
    private AudioSource batSounds;
    [SerializeField] private OptionsSettingsSO settingsSO;

    private void Start()
    {
        batSounds = gameObject.GetComponent<AudioSource>();
        batAnimator = gameObject.GetComponent<Animator>();
        batSounds.volume = settingsSO.soundVolume;
    }

    public void Panic()
    {
        batAnimator.speed = panicMultiply;
        RB2D.velocity = new Vector2(RB2D.velocity.x * panicMultiply, 0);
      
        batSounds.PlayOneShot(batSounds.clip);
        Debug.Log("BatClicked");
    
    }
    public void SetUpBat(int index,bool flip = false)
    {
        RB2D = gameObject.GetComponent<Rigidbody2D>();
        SpriteRend = gameObject.GetComponent<SpriteRenderer>();


        
        if (flip)
        {

            SpriteRend.flipX = flip;
            direction = direction * -1;

        }

        switch (index)
        {

            case 0:
                transform.localScale = new Vector3(1, 1, 1);
                SpriteRend.sortingOrder = 21;
                RB2D.velocity = new Vector2(-1 * direction, 0);
                Destroy(gameObject, 22);
                break;
            case 1:
                transform.localScale = new Vector3(1.5f, 1.5f, 1);
                SpriteRend.sortingOrder = 31;
                RB2D.velocity = new Vector2(-2 * direction, 0);
                Destroy(gameObject, 14);
                break;
           
            case 2:
                transform.localScale = new Vector3(2f, 2f, 1);
                SpriteRend.sortingOrder = 41;
                RB2D.velocity = new Vector2(-3 * direction, 0);
                Destroy(gameObject, 10);
                break;
            case 3:
                transform.localScale = new Vector3(2.3f, 2.3f, 1);
                SpriteRend.sortingOrder = 61;
                RB2D.velocity = new Vector2(-4 * direction, 0);
                Destroy(gameObject, 7);
                break;
            case 4:
                transform.localScale = new Vector3(3, 3, 1);
                SpriteRend.sortingOrder = 71;
                RB2D.velocity = new Vector2(-10 * direction, 0);
                Destroy(gameObject, 6);
                break;


        }
      


    }
    
}
