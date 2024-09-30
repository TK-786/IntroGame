using System.Collections ;
using System.Collections.Generic ;
using UnityEngine;
using UnityEngine.InputSystem ;
using UnityEngine.UI ;
using TMPro ;

public class PlayerController : MonoBehaviour {
    public Vector2 moveValue ;
    public float speed ;
    private int count ;
    private int numPickups = 4;
    public TextMeshProUGUI scoreText ;
    public TextMeshProUGUI winText ;
    public TextMeshProUGUI PlayerVelocity ;
    public TextMeshProUGUI PlayerPosition ;
    public Vector2 pos ;
    public Vector2 newPos ;
    public float velocity ;

    void Start() {
        count = 0;
        winText.text = "" ;
        SetCountText() ;
        pos = transform.position ;
    }


    void OnMove ( InputValue value ) {
        moveValue = value.Get<Vector2>() ;
    }

    // void Update () {
    //     newPos = transform.position ;
    //     velocity = (newPos - pos).magnitude/Time.deltaTime ;
    //     PlayerPosition.text = "Position: " + newPos.ToString() ;
    //     PlayerVelocity.text = "velocity :" + velocity.ToString() ;
    //     pos = newPos ;
    // }

    void FixedUpdate () {
        Vector3 movement = new Vector3 ( moveValue.x , 0.0f , moveValue.y ) ;

        GetComponent<Rigidbody>().AddForce( movement * speed * Time.fixedDeltaTime ) ;
        newPos = transform.position ;
        velocity = (newPos - pos).magnitude/Time.deltaTime ;
        PlayerPosition.text = "Position: " + newPos.ToString() ;
        PlayerVelocity.text = "velocity :" + velocity.ToString() ;
        pos = newPos ;
    }

    void OnTriggerEnter (Collider other) {
        if(other.gameObject.tag == "PickUp") {
            other.gameObject.SetActive(false);
            count++ ;
            SetCountText() ;
        }
    }

    private void SetCountText() {
        scoreText.text = "score: " + count.ToString();
        if (count >= numPickups){
            winText.text = "You Win!";
        }
    }

}

