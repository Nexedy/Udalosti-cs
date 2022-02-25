using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Události
{
    class MetronomClass
    {
        private readonly int period;
        private Timer timer;

        //Action = public delegate void název
        private Action listener;

        public MetronomClass(int period)
        {
            this.period = period;
        }

        public void SetOnTickListener(Action listener)
        {
            this.listener = listener;
        }

        public void Start()
        {
            timer = new Timer((x) => {if  (listener != null) listener(); }, null, 0, period);
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
            if (listener != null)
            {
                listener();
            }
            
        }

        
    }
}
