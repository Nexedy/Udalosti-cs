using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Události
{
    class MultiMetronom
    {
        private readonly int period;
        private Timer timer;

        //Action = public delegate void název
        private readonly List<Action> listeners = new List<Action>();

        public MultiMetronom(int period)
        {
            this.period = period;
        }

        public void AddOnTickListener(Action listener)
        {
            listeners.Add(listener);
        }

        public void Start()
        {
            timer = new Timer((x) => {foreach  (Action a in listeners) a(); }, null, 0, period);
        }

        public void Stop()
        {
            if (timer == null)
            {
                return;
            }
            timer.Dispose();
        }

        private void TimerAkce(object x)
        {
            /*if (listener != null)
            {
                listener();
            }
            */
        }

        
    }
}
