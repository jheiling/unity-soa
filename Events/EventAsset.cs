using UnityEngine;



namespace SOA
{
    [CreateAssetMenu(fileName = "New Event", menuName = "SOA/Events/EventAsset", order = 0)]
    public class EventAsset : ScriptableObject
    {
        public delegate void Listener();

#if UNITY_EDITOR
        [Multiline]
        public string Description = "";

        public bool Log;
#endif

        event Listener _event;

        public void AddListener(Listener listener)
        {
            _event += listener;
        }

        public void RemoveListener(Listener listener)
        {
            _event -= listener;
        }

        public void Invoke()
        {
#if UNITY_EDITOR
            if (Log) Debug.Log("Event \"" + Description + "\" invoked  with " + _event.GetInvocationList().Length + " listeners.");
#endif
            if (_event != null) _event.Invoke();
        }
    }



    public abstract class EventAsset<T> : ScriptableObject
    {
        public delegate void Listener(T value);

#if UNITY_EDITOR
        [Multiline]
        public string Description = "";

        public bool Log;
        public T TestValue;
#endif

        event Listener _event;

        public void AddListener(Listener listener)
        {
            _event += listener;
        }

        public void RemoveListener(Listener listener)
        {
            _event -= listener;
        }

        public void Invoke(T value)
        {
#if UNITY_EDITOR
            if (Log) Debug.Log("Event \"" + Description + "\" invoked with \"" + value.ToString() + "\" with " + _event.GetInvocationList().Length + " listeners.");
#endif
            if (_event != null) _event.Invoke(value);
        }
    }
}