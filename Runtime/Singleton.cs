using UnityEngine;

namespace AarquieSolutions.Base.Singleton
{
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        private static bool applicationIsQutting;
        
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

                if (!applicationIsQutting)
                {
                    GameObject container = new GameObject($"[{typeof(T)}]");
                    instance = container.AddComponent<T>();
                }

                return instance;
            }
        }

        public virtual void Awake()
        {
            Application.quitting += ApplicationIsQutting;
            DontDestroyOnLoad(gameObject);
        }

        private void OnDestroy()
        {
            Application.quitting -= ApplicationIsQutting;
        }

        private void ApplicationIsQutting()
        {
            applicationIsQutting = true;
        }
    }
}
