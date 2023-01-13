using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class BackgroundBatSpawner : MonoBehaviour
{

    [SerializeField] GameObject batToSpawn;
    [SerializeField] GameObject  pos1, pos2;
    private Transform spawnPoint;
    [SerializeField] float range = 4;
  

    [SerializeField] MainMenuInputs mainMenuInputs;
    private InputAction input;
    private void Awake()
    {
        mainMenuInputs = new MainMenuInputs();
    }
    private void OnEnable()
    {
        input = mainMenuInputs.MainMenuKeyboard.EnemyClick;
        input.Enable();

        mainMenuInputs.MainMenuKeyboard.EnemyClick.performed += Panic;
    }
    private void OnDisable()
    {
        mainMenuInputs.MainMenuKeyboard.EnemyClick.Disable();
        input.Disable();
    }




    private void Panic(InputAction.CallbackContext obj)
    {

       
       // Vector2 worldPoint2 = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
        if (hit.collider != null)
        {
            if (hit.transform.CompareTag("BackgroundBat"))
            {

                hit.transform.GetComponent<BackgroundBat>().Panic();

            }
           
        }
       

    }

    void Start()
    {
       
        StartCoroutine(SpawnTime());
       
    }

   
    IEnumerator SpawnTime()
    {
        SpawnBatAtRandomLocation();
        yield return new WaitForSeconds(Random.Range(6f, 8f));
        
        StartCoroutine(SpawnTime());



    }
    public void SpawnBatAtRandomLocation() 
    {
        
        float temp;
        //var Clone;
        bool flip = (Random.value > 0.5f);
        if (flip)
        {
            spawnPoint = pos2.transform;
            var temp1 = pos2.transform.position;
            temp = pos2.transform.position.y + (range * Random.Range(0f, 1f));

            spawnPoint.transform.position = new Vector3(pos2.transform.position.x, temp, pos2.transform.position.z);
            var Clone1 = Instantiate(batToSpawn, spawnPoint.transform.position, Quaternion.identity);
            Clone1.GetComponent<BackgroundBat>().SetUpBat(Random.Range(0, 4), true);
            pos2.transform.position = temp1;

        }
        else 
        {
            spawnPoint = pos1.transform;
            var temp1 = pos1.transform.position;
            temp = pos1.transform.position.y + (range * Random.Range(0f, 1f));

            spawnPoint.transform.position = new Vector3(pos1.transform.position.x, temp, pos1.transform.position.z);
            var Clone2 = Instantiate(batToSpawn, spawnPoint.transform.position, Quaternion.identity);
            Clone2.GetComponent<BackgroundBat>().SetUpBat(Random.Range(0,4));
            pos1.transform.position = temp1;
        }
      
      

    }
}
