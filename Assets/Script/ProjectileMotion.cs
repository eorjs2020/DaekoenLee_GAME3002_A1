using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMotion : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody bulletPrefabs;
    public GameObject cursor;
    public Transform shootPoint;
    public Transform TurretHead;
    public LayerMask layer;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        LaunchProjectile();
    }

    void LaunchProjectile()
    {
        Ray camRay = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(camRay, out hit, 100f, layer))
        {
            cursor.SetActive(true);
            cursor.transform.position = hit.point + Vector3.up * 0.1f;

            Vector3 Vo = CalculateVelocity(hit.point, shootPoint.position, 1f);

            TurretHead.transform.rotation = Quaternion.LookRotation(cursor.transform.position);
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Rigidbody obj = Instantiate(bulletPrefabs, shootPoint.position, Quaternion.identity);
                obj.velocity = Vo;
            }
        }
        else
        {
            cursor.SetActive(false);
        }
    }

    Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time)
    {
        Vector3 distance = target - origin;
        Vector3 distanceXZ = distance;
        distanceXZ.y = 0f;
        //create a float the represent our distance
        float dY = distance.y;
        float dXZ = distanceXZ.magnitude;
        // x = Vx * t -> Vx = x/t
        // y = Vy0 * t - 1/2 * g * t^2 -> y + 1/2 *g *t^2 = Vy0 * t -> Vy0 = y/t + 1/2 * g * t;
        float vXZ = dXZ / time;
        float vY = dY / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;
        // Normalize distanse
        Vector3 result = distanceXZ.normalized;
        // add Horizontal Velocity
        result *= vXZ;
        // add Vertical Velocity
        result.y = vY;

        return result;
    }
}
