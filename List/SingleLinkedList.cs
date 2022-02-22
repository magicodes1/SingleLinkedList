namespace TheList.List
{
    public class SingleLinkedList
    {
        public Node First;
        public Node Last;

        public int Count;


        public SingleLinkedList()
        {
            First = null!;
            Last = null!;
            Count = 0;
        }


        public Node getFirst() => this.First;
        public Node getLast() => this.Last;


        public int Length() => this.Count;


        public void addLast(int value)
        {
            if (First == null)
            {
                First = Last = new Node(value);
            }
            else
            {
                Node node = new Node(value);
                Last.Next = node;
                Last = node;
            }
            Count++;
        }

        public void addFirst(int value)
        {
            if (First == null)
            {
                First = Last = new Node(value);

            }
            else
            {
                Node node = new Node(value);
                node.Next = First;
                First = node;
            }
            Count++;
        }

        public void addAfter(int value, Node specificNode)
        {
            if (specificNode == null) return;

            if(!contain(specificNode.data)) return;

            Node node = new Node(value);
            if (specificNode == Last)
            {
                specificNode.Next = node;
                Last = node;
            }
            else
            {
                node.Next = specificNode.Next;
                specificNode.Next = node;
            }
            Count++;
        }

        public void addBefore(int value, Node specificNode)
        {
            if (specificNode == null) return;

            if(!contain(specificNode.data)) return;

            Node node = new Node(value);
            if (specificNode == First)
            {
                node.Next = First;
                First = node;

            }
            else
            {
                for (Node currentNode = First; currentNode != null; currentNode = currentNode.Next)
                {
                    if (currentNode.Next.data == specificNode.data)
                    {
                        node.Next = currentNode.Next;
                        currentNode.Next = node;
                        break;
                    }
                }
            }
            Count++;
        }

        private Node binarySort(Node start, Node end, int value)
        {
            Node middle = getMiddleNode(start, end);

            if (middle == null) return null!;

            Node right = middle.Next;

            if (middle.data == value) return middle;


            if (value > middle.data) return binarySort(right, end, value);
            return binarySort(start, middle, value);
        }

        private bool checkSorted(Node node)
        {
            for (Node current = node; current != null; current = current.Next!)
            {
                if (current.Next!=null && current.data > current.Next.data)
                {
                    return false;
                }
            }
            return true;
        }


        public Node find(int value)
        {
            bool check = checkSorted(First);

            if (!check) sort();

            Node node = binarySort(First, Last, value);
            return node;
        }

        public bool contain(int value)
        {
            Node node = find(value);

            return node != null;
        }

        public void remove(int value)
        {
            if (value == First.data)
            {
                removeFirst();
                return;
            }
            if (value == Last.data)
            {
                removeLast();
                return;
            }
            for (Node currentNode = First; currentNode != null; currentNode = currentNode.Next)
            {
                if (currentNode.Next.data == value)
                {
                    var node = currentNode.Next;
                    currentNode.Next = node.Next;
                    break;
                }
            }
            Count--;
        }

        public void remove(Node specificNode)
        {
            if (specificNode == First)
            {
                removeFirst();
                return;
            }

            if (specificNode == Last)
            {
                removeLast();
                return;
            }

            for (Node currentNode = First; currentNode != null; currentNode = currentNode.Next)
            {
                if (currentNode.Next.data == specificNode.data)
                {
                    var node = currentNode.Next;
                    currentNode.Next = node.Next;
                    break;
                }
            }
            Count--;
        }

        public void removeFirst()
        {
            if (First == null)
            {
                return;
            }
            First = First.Next;
            Count--;
        }

        public void removeLast()
        {
            if (Last == null) return;
            for (Node currentNode = First; currentNode != null; currentNode = currentNode.Next)
            {
                if (currentNode.Next.data == Last.data)
                {
                    currentNode.Next = null!;
                    Last = currentNode;
                }
            }
            Count--;
        }


        private Node reverseLinkedList(Node first)
        {
            Node current = first;
            Node previous = null!;
            Node next = null!;

            while (current != null)
            {
                next = current.Next;
                current.Next = previous;

                previous = current;
                current = next;
            }
            return previous;
        }

        public void reverseLinkedList()
        {
            Node node = reverseLinkedList(First);
            setFirstAndLastAgain(node);
        }
        public void print()
        {
            for (Node node = First; node != null; node = node.Next)
            {
                System.Console.Write($"{node.data} \t");
            }
            System.Console.WriteLine();
        }

        public void print(SingleLinkedList linkedList)
        {
            for (Node node = linkedList.First; node != null; node = node.Next)
            {
                System.Console.Write($"{node.data} \t");
            }
            System.Console.WriteLine();
        }

        public void print(Node theNode)
        {
            for (Node node = theNode; node != null; node = node.Next)
            {
                System.Console.Write($"{node.data} \t");
            }
            System.Console.WriteLine();
        }

        private Node mergeSort(Node node)
        {
            if (node == null || node.Next == null)
            {
                return node!;
            }

            Node middle = getMiddleNode(node);
            Node right = middle.Next;
            middle.Next = null!;

            Node leftSide = mergeSort(node);
            Node rightSide = mergeSort(right);

            Node result = merge(leftSide, rightSide);
            return result;
        }

        private Node merge(Node leftSide, Node rightSide)
        {
            Node result = null!;

            if (leftSide == null) return rightSide;
            if (rightSide == null) return leftSide;


            if (leftSide.data < rightSide.data)
            {
                result = leftSide;
                result.Next = merge(leftSide.Next, rightSide);
            }
            else
            {
                result = rightSide;
                result.Next = merge(leftSide, rightSide.Next);
            }
            return result;
        }

        private void sort()
        {
            Node node = mergeSort(First);
            setFirstAndLastAgain(node);
        }

        private void setFirstAndLastAgain(Node first)
        {
            First = first;
            Node middle = getMiddleNode(First);

            for (Node current = middle; current != null; current = current.Next!)
            {
                if (current.Next == null)
                {
                    Last = current;
                    break;
                }
            }
        }

        private Node getMiddleNode(Node start, Node end = null!)
        {
            Node low = start;
            Node hight = start;

            while (low != null && (hight != end && hight.Next != end && hight.Next.Next != end))
            {
                low = low.Next;
                hight = hight.Next.Next;
            }

            return low!;
        }

    }
}