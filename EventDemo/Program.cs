using System;

/// Events: Are the encapsulated delegates.They follow observer pattern.
/// Observer Pattern:(Like youtube channel)Publisher declares event(his channel).subscribers get registered with the event(when subscribers suscribe for that channel)
/// Publisher:The class who declares and raises/invokes event(like in view: click+=OnClick()).
/// Subscriber:The class who handles event,with EventHandler method(e.g.OnClick(Object data,EventArgs e))
/// EventHandler: It's a method with same signature as that will handle event it is registered with.

namespace EventDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Publisher with declared event MyPostVideoEvent
            MyPublisher myPublisher = new MyPublisher();

            //before raising event register all subscribers

            //subscriber1 says call my event handler MessageMe method when publisher will raise MyPostVideoEvent
            MySubscriber subscriber1 = new MySubscriber("Mahesh");
            myPublisher.MyPostVideoEvent += subscriber1.messageMe;

            //way2:
            //subscriber2 registers with publishers event
            MySubscriber subscriber2 = new MySubscriber("Sanvedana");
            subscriber1.RegisterMeWithPublishersEvent(myPublisher);


            //Tell publisher to start event,
            myPublisher.StartRaisingEvent();

        }
    }



    /// <summary>
    /// Publisher Class:It will define event, and raise it.
    /// </summary>
    public class MyPublisher
    {

        //delegate with void return type and no parameters
        public delegate void Mydelegate();

        //declare event of Mydelegate type,use event keyword
        public event Mydelegate MyPostVideoEvent;

        //Start a process to give a call to raise the event
        public void StartRaisingEvent()
        {
            Console.WriteLine("I am from Publisher class,I am raising my event now");
            OnMyPostVideoEvent();
        }

        /*
        to raise an event, protected and virtual method should be defined with the 
        name On<EventName>. Protected and virtual enable derived classes to override 
        the logic for raising the event. 
        */
        protected virtual void OnMyPostVideoEvent()
        {
            //check if event is registered by any subscribers
            if (MyPostVideoEvent != null)
            {
                //Raise with Invoke with no parameters as delegate have no parameters
                MyPostVideoEvent.Invoke();
            }

            //c#8 new feature: MyPostVideoEvent?.Invoke;
        }
    }


    /// <summary>
    /// subscriber class: It will register with publishers events
    /// </summary>
    public class MySubscriber
    {
        private string subName;
        public MySubscriber(string subscriberName)
        {
            subName = subscriberName;
        }

        //registeres subscriber with the puplisher that passed
        public void RegisterMeWithPublishersEvent(MyPublisher myPublisher)
        {
            myPublisher.MyPostVideoEvent += this.messageMe;
        }
        //EventHandler for publishers event: method with Same signature as delegate
        public void messageMe()
        {
            Console.WriteLine($"Hello {subName},Publisher have raised event");
        }

    }

}
