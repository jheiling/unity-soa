using UnityEngine;
using UnityEngine.Events;



namespace SOA
{
    [AddComponentMenu("SOA/Events/EventListener")]
    public class EventListener : MonoBehaviour
    {
        public EventAsset Event;
        public UnityEvent Response;

        void OnEnable()
        {
            if (Event && Response != null) Event.AddListener(Response.Invoke);
        }

        void OnDisable()
        {
            if (Event && Response != null) Event.RemoveListener(Response.Invoke);
        }
    }



    public abstract class EventListener<T, SE, UE> : MonoBehaviour where SE : EventAsset<T> where UE : UnityEvent<T>
    {
        public SE Event;
        public UE Response;

        void OnEnable()
        {
            if (Event && Response != null) Event.AddListener(Response.Invoke);
        }

        void OnDisable()
        {
            if (Event && Response != null) Event.RemoveListener(Response.Invoke);
        }
    }
}