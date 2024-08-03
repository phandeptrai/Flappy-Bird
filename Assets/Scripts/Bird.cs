using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Bird : MonoBehaviour
{
    public float jumpForce = 5f;  // Giá trị jumpForce
    private Rigidbody2D rb;
    private Animator animator;
    private AudioSource audioSource;
    public AudioClip jumpSound;  // Thêm biến cho tệp âm thanh
    public AudioClip gameOverSound;
    public AudioClip anDiemSound;
    public AudioClip anMungSound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        // Tải điểm cao nhất từ PlayerPrefs
        audioSource = GetComponent<AudioSource>();  // Lấy tham chiếu tới AudioSource
        GameManager.instance.gameAwake();
        

        // Debug log to confirm AudioSource and AudioClip are set
        if (audioSource == null)
        {
            Debug.LogError("AudioSource is not assigned or not found on the GameObject.");
        }

        if (jumpSound == null)
        {
            Debug.LogError("Jump sound AudioClip is not assigned in the Inspector.");
        }
    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (!GameManager.instance.game)
            {
                GameManager.instance.startGame();
            }
            rb.gravityScale = 3f; // Chỉ đặt giá trị này nếu cần thiết
            rb.velocity = Vector2.zero; // Đặt vận tốc về 0 trước khi nhảy
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // Thêm lực để chim nhảy lên
              
            if (audioSource != null && jumpSound != null)
            {
                audioSource.PlayOneShot(jumpSound);
                Debug.Log("Playing jump sound.");
            }
            Debug.Log("Current Velocity: " + rb.velocity); // Kiểm tra vận tốc sau khi nhảy
        }
    }
    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * jumpForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GameOver"))
        {
            GameManager.instance.gameOver();
            audioSource.PlayOneShot(gameOverSound);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("anDiem"))
        {
            audioSource.PlayOneShot(anDiemSound);
        }
    }
}
    