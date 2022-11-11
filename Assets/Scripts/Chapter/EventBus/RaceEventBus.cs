using UnityEngine.Events;
using System.Collections.Generic;

namespace Chapter.EventBus
{
    public class RaceEventBus
    {
        private static readonly IDictionary<RaceEventType, UnityEvent> Events = new Dictionary<RaceEventType, UnityEvent>();

        public static void Subscribe(RaceEventType eventType, UnityAction listener)
        {
            UnityEvent thisEvent;

            if (Events.TryGetValue(eventType, out thisEvent))
            {
                thisEvent.AddListener(listener);
            }
            else
            {
                thisEvent = new UnityEvent();
                thisEvent.AddListener(listener);
                Events.Add(eventType, thisEvent);
            }
        }
    }
}