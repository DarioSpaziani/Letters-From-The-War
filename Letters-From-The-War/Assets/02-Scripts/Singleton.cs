using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T instance;

    public virtual void Awake()
    {
        if (!instance)
        {
            instance = this as T;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}