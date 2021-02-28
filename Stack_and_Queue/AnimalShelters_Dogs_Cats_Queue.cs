using System.Collections.Generic;


namespace Stacks_Create_Three_Stacks.Stack_And_Queue
{
    public abstract class Animal
    {
        private int order;
        protected string name;

        public Animal(string n)
        {
            name = n;
        }

        public void setOrder(int ord)
        {
            order = ord;
        }

        public int getOrder()
        {
            return order;
        }

        /*Compare order of animals to return the older item */
        public bool isOldersThan(Animal a)
        {
            return this.order < a.getOrder();
        }
    }

    public class Dog : Animal
    {
        public Dog(string n) : base(n)
        { 
            
        }
    }

    public class Cat : Animal
    {
        public Cat(string n) : base(n)
        {

        }
    }

    class AnimalQueue
    {
        LinkedList<Dog> dogs = new LinkedList<Dog>();
        LinkedList<Cat> cats = new LinkedList<Cat>();
        private int order = 0; // acts as a timestamp

        public void enqueue(Animal a)
        {
            /* Order is used as a sort of timestamp, so that we can compare the
               insertion order of a dog to a cat. */
            a.setOrder(order);
            order++;

            if (a is Dog)
            {
                dogs.AddLast((Dog)a);
            }

            if (a is Cat)
            {
                cats.AddLast((Cat)a);
            }
        }

        public Animal dequeueAny()
        {
            /* Look at tops of dogs and cats queues, and pop the queue with the oldest value. */
            if (dogs.Count == 0)
            {
                return dequeueCats();
            }
            else if (cats.Count == 0)
            {
                return dequeueDogs();
            }

            Dog dog = dogs.Last.Value;
            Cat cat = cats.Last.Value;

            if (dog.isOldersThan(cat))
            {
                return dequeueDogs();
            }
            else
            {
                return dequeueCats();
            }

        }

        public Dog dequeueDogs()
        {
            if (dogs.Count == 0)
            {
                return null;
            }

            LinkedListNode<Dog> firstDogNode = dogs.First;
            dogs.RemoveFirst();
            return firstDogNode.Value;
        }

        public Cat dequeueCats()
        {
            if (cats.Count == 0)
            {
                return null;
            }

            LinkedListNode<Cat> firstCatNode = cats.First;
            cats.RemoveFirst();
            return firstCatNode.Value;
        }

    }
}
