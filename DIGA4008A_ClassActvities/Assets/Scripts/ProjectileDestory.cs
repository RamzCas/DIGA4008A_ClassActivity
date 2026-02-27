using UnityEngine;

public class ProjectileDestory : MonoBehaviour
{
    public float Timer;
    public bool active;

    private void Awake()
    {
        active = true;
    }
    void Update()
    {
        if (active) 
        {
            Timer += Time.deltaTime;
        }

        if(Timer > 1.5) 
        {
            Destroy(this.gameObject);
        }
    }
}
