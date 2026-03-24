using UnityEngine;

public class TurretSystem : MonoBehaviour
{
    public GameObject bulletPrefab; // Kéo Prefab đạn vào đây
    public Transform firePoint;     // Vị trí nòng súng

    void Update()
    {
        // Lab 3: Xoay theo chuột
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        Vector3 direction = mousePos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Xoay mượt
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10f * Time.deltaTime);

        // Bắn đạn
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (bulletPrefab != null)
        {
            // Instantiate: Tạo object từ Prefab (Lab 1)
            GameObject b = Instantiate(bulletPrefab, transform.position, transform.rotation);

            // Bắn bay đi
            Rigidbody2D rb = b.GetComponent<Rigidbody2D>();
            rb.velocity = transform.right * 10f; // Bay theo hướng phải của súng

            Destroy(b, 2f); // Tự hủy sau 2 giây (Lab 1)
        }
    }
}