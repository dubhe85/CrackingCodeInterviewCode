namespace LoopDetectionList
{
    public class LinkedList
    {
        private Node head;

        public LinkedList()
        { }

        public Node Head
        {
            get 
            {
                return head;
            }
        }

        public void Add(string data)
        {
            Node toAdd = new Node();
            toAdd.data = data;

            if (head == null)
            {
                head = toAdd;
                return;
            }

            Node current = head;
            while (current.next != null)
            {
                current = current.next;
            }
            
            current.next = toAdd;
        }

        public void Add(Node nextNode ,string data)
        {
            Node toAdd = new Node();
            toAdd.data = data;
            toAdd.next = nextNode;

            if (head == null)
            {
                head = toAdd;
                return;
            }

            Node current = head;
            while (current.next != null)
            {
                current = current.next;
            }

            current.next = toAdd;
        }

        public void printAllNodes()
        {
            Node current = head;
            while (current != null)
            {
                Console.WriteLine(current.data + "- ");
                current = current.next;
            }
        }
    }

    public class Node
    {
        public Node next;
        public string data;
    }

    class LoopDetection
    {
        
        public void LoopDetectionMethod()
        {
            // create list
            LinkedList linkedList = new LinkedList();

            linkedList.Add("A");
            linkedList.Add("B");
            linkedList.Add("C");
            linkedList.Add("D");
            linkedList.Add("E");

            Node firstNodeWithC = FindFirstValue(linkedList, "C");
            linkedList.Add(firstNodeWithC, "C");

            // linkedList.printAllNodes();

            Console.WriteLine("Trying to find beginning of  loop.");
            Node beginnigOfLoopNode = FindBeginning(linkedList.Head);
        }

        public Node FindFirstValue(LinkedList linkedList,  string value)
        {
            Node node = null;

            Node currentNode = linkedList.Head;

            do
            {
                if (currentNode.data == value)
                {
                    node = currentNode;
                    break;
                }

                currentNode = currentNode.next;
            }
            while (currentNode.next != null);


            return node;
        
        }

        public Node FindBeginning(Node head)
        {
            Node slow = head;
            Node fast = head;

            /* Find meeting point. This will be LOOP_SIZE - k steps into the linked list. */
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)
                {
                    // Collision
                    break;
                }
            }

            /* Error check - no meeting point, and therefore no loop */
            if (fast == null || fast.next == null)
            {
                return null;
            }

            /* Move slow to head. Keep fast at Meeting Point. Each are k steps from the Loop Start.
             * If they move at the same pace, they must meet at Loop Start.             
             */
            slow = head;
            while (slow != fast)
            {
                slow = slow.next;
                fast = fast.next;
            }

            /* Both now point to the start of the loop. */
            return fast;
        }
        
    }
}
