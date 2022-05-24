using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMovementTest : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D myRigid;

    public bool isWalking;

    private Vector3 destination;

    public float walkTime;
    private float walkCounter;
    public float waitTime;
    private float waitCounter;

    private int walkDirection;
    
    // Start is called before the first frame update
    void Start()
    {
        myRigid= GetComponent<Rigidbody2D>();
        // waitCounter = waitTime;
        // walkCounter = walkTime;
         

    }

    // Update is called once per frame
    void Update()
    {
        
        if(transform.position.x < 0){
            Stop();
            myRigid.velocity = Vector3.zero;
        }else{
            ChooseDirection();
        }
    }

    public void ChooseDirection(){
       transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * moveSpeed;
    }

    // IEnumerator ChooseDir(){
        
    //     transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * moveSpeed;
    //     yield return new WaitForSeconds(1);
    //     destination = transform.position;
    //     yield return new WaitForSeconds(1);
       
    // }
    private void Stop(){
        destination = transform.position;
    }
}
