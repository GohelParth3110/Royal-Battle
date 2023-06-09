using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour,ItakeKnockBack
{
    [SerializeField]private float flt_KnockBackForce;
    [SerializeField] private float flt_SpeedOfPlayer;
    [SerializeField] private float flt_JumpForce;
    [SerializeField] private float flt_SpeedRate;
    [SerializeField] private Animator animator;
    private float flt_VerticalInput;
    private float flt_HorizontalInput;
    private bool isJump;
    private int jumpCount;
    private string tag_Ground = "Ground";
    private float targetAngle;
    private float currentAngle;
  

    // Camponant
    private Rigidbody playerRb;
   
  

    private void Start() {
        playerRb = GetComponent<Rigidbody>();
    }
    private void Update() {

        if (transform.position.y<-10) {
            GameManager.instance.isPlayerLive = false;
            UIManager.instance.screen_UIGamePlayScreen.gameObject.SetActive(false);
            UIManager.instance.screen_UIGameOverScreen.gameObject.SetActive(true);
            Destroy(gameObject);
        }
        GetInput();
        PlayerMotion();
        PlayerJump();
    }
    private void GetInput() {

        flt_HorizontalInput = Input.GetAxis("Horizontal");
        flt_VerticalInput = Input.GetAxis("Vertical");

        if (Input.GetMouseButtonDown(0)) {
            isJump = true;
        }
        else {
            isJump = false;
        }

    }
    private void PlayerJump() {

        if ( isJump && jumpCount<2) {
            playerRb.AddForce(Vector3.up * flt_JumpForce, ForceMode.Impulse);
            jumpCount++;
        }
   
    }

    private void PlayerMotion() {

        
       
            if (flt_HorizontalInput == 0 && flt_VerticalInput == 0) {
                animator.SetBool("IsRuning", false);
                return;
            }

            animator.SetBool("IsRuning", true);
            targetAngle = Mathf.Atan2(flt_VerticalInput, -flt_HorizontalInput) * Mathf.Rad2Deg;
            currentAngle = Mathf.LerpAngle(currentAngle, targetAngle, flt_SpeedRate * Time.deltaTime);

            transform.eulerAngles = new Vector3(0, currentAngle, 0);
            transform.position += transform.right * flt_SpeedOfPlayer * Time.deltaTime;
        

       
    }

    private void OnCollisionEnter(Collision collision) {

        if (collision.gameObject.CompareTag(tag_Ground)) {
            jumpCount = 0;
        }

    }

    public void KnockbackVFX(Vector3 dirction) {

        playerRb.AddForce(dirction * flt_KnockBackForce, ForceMode.Impulse);
        StartCoroutine(SetHitBySomething());
    }

   
    private IEnumerator SetHitBySomething() {
        yield return new WaitForSeconds(0.2f);
       
        playerRb.velocity = Vector3.zero;
        playerRb.angularVelocity = Vector3.zero;
    }
}







