using UnityEngine;



namespace SOA
{
    [CreateAssetMenu(fileName = "New Event", menuName = "SOA/Events/SOEvent", order = 0)]
    public class SOEvent : ScriptableObject
    {
        public delegate void Handler();

#if UNITY_EDITOR
        [Multiline]
        public string Description = "";

        public bool Log;
#endif

        event Handler _event;

        public void Register(Handler handler)
        {
            _event += handler;
        }

        public void Unregister(Handler handler)
        {
            _event -= handler;
        }

        public void Invoke()
        {
#if UNITY_EDITOR
            if (Log) Debug.Log("Event \"" + Description + "\" invoked (" + _event.GetInvocationList().Length + " listeners).");
#endif
            if (_event != null) _event.Invoke();
        }
    }



    public abstract class SOEvent<T> : ScriptableObject
    {
        public delegate void Handler(T value);

#if UNITY_EDITOR
        [Multiline]
        public string Description = "";

        public bool Log;
        public T TestValue;
#endif

        event Handler _event;

        public void Register(Handler handler)
        {
            _event += handler;
        }

        public void Unregister(Handler handler)
        {
            _event -= handler;
        }

        public void Invoke(T value)
        {
#if UNITY_EDITOR
            if (Log) Debug.Log("Event \"" + Description + "\" invoked with \"" + value.ToString() + "\" (" + _event.GetInvocationList().Length + " listeners).");
#endif
            if (_event != null) _event.Invoke(value);
        }
    }
}