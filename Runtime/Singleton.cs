using UnityEngine;

namespace AarquieSoltuions.Base.Singleton
{
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        private static T instance;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = GameObject.FindObjectOfType<T>();
                }

                if (instance != null)
                {
                    return instance;
                }
                
                GameObject container = new GameObject($"[{typeof(T)}]");
                instance = container.AddComponent<T>();

                return instance;
            }
        }

        public virtual void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
