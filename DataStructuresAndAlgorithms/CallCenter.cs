using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    public class CallCenter
    {
        private int _counter = 0;
        public ConcurrentQueue<IncomingCall> Calls { get; private set; }
        public CallCenter()
        {
            Calls = new ConcurrentQueue<IncomingCall>();
        }

        public int Call(int clientid)
        {
            IncomingCall call = new IncomingCall()
            {
                Id = ++_counter,
                ClientId = clientid,
                CallTime = DateTime.Now

            };

            Calls.Enqueue(call);
            return Calls.Count;
        }

        public IncomingCall AnswerCall(string consultant)
        {
            if(Calls.Count >0 && Calls.TryDequeue(out IncomingCall call))
            {
                call.Consultant = consultant;
                call.StartTime = DateTime.Now;
                return call;
            }
            return null;
        }

        public void End(IncomingCall call)
        {
            call.EndTime = DateTime.Now;
        }
        public bool AreAwaitingCalls()
        {
            return Calls.Count > 0;
        }
    }


    public class IncomingCall
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime CallTime { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Consultant { get; set; }
    }
}
