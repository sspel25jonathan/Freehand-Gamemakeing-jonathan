using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float Speed;

    public GameObject thing;

    private  NweFieldRay _ray;
    void Start()
    {
        _ray = thing.GetComponent<NweFieldRay>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(Vector3.left * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Vector3.right * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(Vector3.back * Speed * Time.deltaTime);
        }

        Tackle();
    }

    private void Tackle()
    {
        if (_ray.hit.collider.CompareTag("Player") && Vector3.Distance(this.transform.position, _ray.target.transform.position) < 4) {
            Debug.Log("hitting player and it is CLOSE!");
            }

    }
}
