using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class thiefMove : MonoBehaviour
{
    private CharacterController characterController;
    private float rotSpeed = 0.8f;
    private float speed = 2;
    public float sensitivityX = 5f;
    public float sensitivityY = 5f;

    private bool ismove;
    public Animator animator;

    public Text text;
    int number;


    public GameObject win;
    public Button button;
    void Start()
    {
        characterController = this.GetComponent<CharacterController>();
        button.onClick.AddListener(() => SceneManager.LoadScene("start"));
    }


    void FixedUpdate()
    {
        //鼠标右键实现视角转动，类似第一人称视角  
        if (Input.GetMouseButton(0))
        {
            float rotationX = Input.GetAxis("Mouse X") * 2;
            transform.Rotate(0, rotationX, 0);
        }
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            ismove = true;
            animator.SetBool("ldle", false);
            animator.SetBool("walk", true);
            characterController.Move(this.transform.forward * speed * Time.deltaTime);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            if (ismove)
            {
                ismove = false;
                animator.SetBool("ldle", true);
                animator.SetBool("walk", false);
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            ismove = true;
            animator.SetBool("ldle", false);
            animator.SetBool("walk", true);
            characterController.Move(this.transform.right * speed * Time.deltaTime);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            ismove = false;
            animator.SetBool("ldle", true);
            animator.SetBool("walk", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            ismove = true;
            animator.SetBool("ldle", false);
            animator.SetBool("walk", true);
            characterController.Move(-this.transform.right * speed * Time.deltaTime);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            ismove = false;
            animator.SetBool("ldle", true);
            animator.SetBool("walk", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            ismove = true;
            animator.SetBool("ldle", false);
            animator.SetBool("walk", true);
            characterController.Move(-this.transform.forward * speed * Time.deltaTime);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            ismove = false;
            animator.SetBool("ldle", true);
            animator.SetBool("walk", false);
        }
    }
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Treasure")
        {
            Destroy(collider.gameObject);
            number++;
            text.text = string.Format("Treasure：" + number);
            if (number >= 6)
            {
                win.SetActive(true);
            }
        }
    }
}
