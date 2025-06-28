using Unity.VisualScripting;
using UnityEngine;


// this script is only for spawning astreoid, time, direction and type. 
public class AstreoidSpawner : MonoBehaviour
{

    [SerializeField] private GameObject[] astreoidPrefabs;
    [SerializeField] private float secondsBetweenAstreaoids=1.5f;
    [SerializeField] private Vector2 forceRange;

    private float timer;
    private Camera mainCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;  
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            SpawnAstreoid();
            timer = secondsBetweenAstreaoids;
        }
    }


    public void SpawnAstreoid()
    {
        int side = Random.Range(0, 4);

        Vector2 spawnPoint = Vector2.zero;
        Vector2 direction = Vector2.zero;


        switch(side)
        {

        case 0:
                //left to right
                spawnPoint.x=0;
                spawnPoint.y= Random.value;
                direction = new Vector2(1f, Random.Range(-1f, 1f));
                 break;

        case 1:
                //right to left
                spawnPoint.x = 1;
                spawnPoint.y = Random.value;
                direction = new Vector2(-1f, Random.Range(-1f, 1f));
                break;

        case 2:
                //bottom to top
                spawnPoint.x = Random.value;
                spawnPoint.y = 0;
                direction = new Vector2( Random.Range(-1f, 1f),1f);

                break;

        case 3:
                //top to bottom
                spawnPoint.x = Random.value;
                spawnPoint.y = 1;
                direction = new Vector2(Random.Range(-1f, 1f), -1f);

                break;






        }


      Vector3 worldSpawnPoint = mainCamera.ViewportToWorldPoint(spawnPoint);
        worldSpawnPoint.z = 0;
        GameObject selectedAstreoid= astreoidPrefabs[Random.Range(0,astreoidPrefabs.Length)];

     GameObject astreoidInstance=  Instantiate(selectedAstreoid, worldSpawnPoint,Quaternion.Euler(0f,0f,Random.Range(0f,360f)));

        Rigidbody rb = astreoidInstance.GetComponent<Rigidbody>();
        rb.linearVelocity= direction.normalized* Random.Range(forceRange.x, forceRange.y);
    }
}
