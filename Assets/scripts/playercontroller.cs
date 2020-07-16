using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    private Rigidbody rb;

    public Text countText;

    public float speed = 0.2f;

    private int count;

    public Text wintext;

    private float distToGround;

    public float jumpforce = 10f;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();

        wintext.text = "";

        distToGround = GetComponent<Collider>().bounds.extents.y;
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(-moveHorizontal, 0f, -moveVertical);

        rb.AddForce(movement * speed);
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        }

    }

    bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + .6f);
    }



    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.CompareTag("pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }

    }

    void SetCountText()
    {
        countText.text = "count: " + count.ToString();
        if (count >= 20)
        {
            wintext.text = "You Win!!";
        }
    }
}
