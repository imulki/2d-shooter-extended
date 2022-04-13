using UnityEngine;

public class OrbObject : MonoBehaviour {
    // Orb Info 
    public string orbName;
    public string orbExplanation;
    public float orbStartTime;
    public float orbLifetime = 20f;

    // public PlayerMovement playerMovement;
    protected GameObject playerObject;

    protected enum State{ 
        Standby,
        Collected,
        Expired
    }

    protected State state;


    protected virtual void Start() {
        state = State.Standby;
        orbStartTime = Time.time;
    }

    protected virtual void Update(){
        if(Time.time - orbStartTime > orbLifetime){
            // Debug.Log("Orb Update");
            Destroy(gameObject);
        }
    }

    // Collision detector
    protected void OnTriggerEnter (Collider other) {
        CollectOrb(other);
    }

    // Check collected orb;
    protected virtual void CollectOrb(Collider gameObjectCollectingOrb){
        
        if( gameObjectCollectingOrb.tag != "Player" ){ 
            return; 
        }


        // if( state == State.Expired ) { 
        //     return; 
        // }
        
        state = State.Collected;
        playerObject = gameObjectCollectingOrb.gameObject; 
        // Debug.Log(playerObject.tag);
        activateOrb();
        
    }

    protected virtual void activateOrb(){
        // Debug.Log(orbName);
        // DestroySelf();
        state = State.Expired;
        Destroy(gameObject);
    }


    // protected virtual void DestroySelf(){
    //     Destroy(gameObject, 10f);
    // }



    
};