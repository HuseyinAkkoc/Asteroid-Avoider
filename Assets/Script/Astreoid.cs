using UnityEngine;


// this script only for the asreoid destroy after collision and when they are out of screen. 
public class Astreoid : MonoBehaviour
{
    
    //PlayerHealth playerhealth;
    private void OnTriggerEnter(Collider other)
    {
      PlayerHealth playerhealth = other.GetComponent<PlayerHealth>();

        if(playerhealth == null ) { return; }

        playerhealth.Crash();
        Destroy(gameObject);

    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }




}
