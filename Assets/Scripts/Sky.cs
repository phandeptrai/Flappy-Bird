using UnityEngine;

public class SkyCollider : MonoBehaviour
{
    // Đặt thuộc tính Collider của bầu trời thành "Is Trigger"
    void OnTriggerEnter2D(Collider2D other)
    {
        // Kiểm tra xem đối tượng va chạm có phải là chim không
        if (other.CompareTag("Player"))
        {
            // Lấy đối tượng chim
            Rigidbody2D birdRigidbody = other.GetComponent<Rigidbody2D>();
            if (birdRigidbody != null)
            {
                // Giới hạn vận tốc của chim về 0 khi va chạm
                birdRigidbody.velocity = Vector2.zero;

                // Giới hạn vị trí của chim tại vị trí của collider
                Vector2 limitedPosition = transform.position;
                limitedPosition.y = other.transform.position.y;
                other.transform.position = limitedPosition;
            }
        }
    }
}
