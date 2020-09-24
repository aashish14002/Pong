using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
    public float speed = 30;

    private string turn = "RacketRight";

    void Start() {
        // Initial Velocity
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }
    
    float hitFactor(Vector2 ballPos, Vector2 racketPos,
                    float racketHeight) {
        // ascii art:
        // ||  1 <- at the top of the racket
        // ||
        // ||  0 <- at the middle of the racket
        // ||
        // || -1 <- at the bottom of the racket
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    
    void QuitGame(){ Application.Quit(); }

    void OnCollisionEnter2D(Collision2D col) {
        // Note: 'col' holds the collision information. If the
        // Ball collided with a racket, then:
        //   col.gameObject is the racket
        //   col.transform.position is the racket's position
        //   col.collider is the racket's collider
        if(col.gameObject.name == "enemy0" |col.gameObject.name == "enemy1" |col.gameObject.name == "enemy2" |col.gameObject.name == "enemy3" |col.gameObject.name == "enemy4"  ) {
            if(turn == "RacketLeft") {
                 ScoreScriptLeft.scoreValueLeft += 1;
            } else {
                ScoreScriptRight.scoreValueRight += 1; 
            }
            Destroy(col.gameObject);

            SoundManagerScript.PlaySound("hit");
            if(GameObject.Find("enemy0")==null && GameObject.Find("enemy1")==null && GameObject.Find("enemy2")==null && GameObject.Find("enemy3")==null && GameObject.Find("enemy4")==null ){
                Application.Quit(); 
            }
        }
        
        if(col.gameObject.name == "WallLeft") {
            
            SoundManagerScript.PlaySound("hit");
        } else if (col.gameObject.name == "WallRight") {
           
            SoundManagerScript.PlaySound("hit");
        }
        // Hit the left Racket?
        if (col.gameObject.name == "RacketLeft") {
            turn = "RacketLeft";
            SoundManagerScript.PlaySound("hit");
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(1, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        // Hit the right Racket?
        if (col.gameObject.name == "RacketRight") {
            turn = "RacketRight";
            SoundManagerScript.PlaySound("hit");
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(-1, y).normalized;
            
            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
    }
}
