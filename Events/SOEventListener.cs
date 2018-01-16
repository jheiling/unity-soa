using UnityEngine;
using UnityEngine.Events;



namespace SOA
{
    [AddComponentMenu("SOA/Events/EventListener")]
    public class SOEventListener : MonoBehaviour
    {
        public SOEvent Event;
        public UnityEvent Response;

        void OnEnable()
        {
            if (Event) Event.Register(Response.Invoke);
        }

        void OnDisable()
        {
            if (Event) Event.Unregister(Response.Invoke);
        }
    }



    public abstract class SOEventListener<T, SE, UE> : MonoBehaviour where SE : SOEvent<T> where UE : UnityEvent<T>
    {
        public SE Event;
        public UE Response;

        void OnEnable()
        {
            if (Event) Event.Register(Response.Invoke);
        }

        void OnDisable()
        {
            if (Event) Event.Unregister(Response.Invoke);
        }
    }
}