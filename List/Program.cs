
using TheList.List;




void main()
{
    SingleLinkedList linkedList = new SingleLinkedList();


    linkedList.addFirst(4);
    linkedList.addFirst(5);
    linkedList.addFirst(7);
    linkedList.addFirst(9);
    linkedList.addFirst(10);
    linkedList.addFirst(14);
    linkedList.addFirst(15);
    linkedList.addFirst(20);

    linkedList.print();

    System.Console.WriteLine("\n");

    var node = linkedList.find(9);

    System.Console.WriteLine(node != null ? node.data : "null");

    // linkedList.addBefore(6,node!);

    //System.Console.WriteLine(linkedList.contain(1));

    //linkedList.remove(node!);

    linkedList.print();

    //linkedList.reverseLinkedList();

    //linkedList.print();

    // var node = linkedList.reverseLinkedList();

    // linkedList.print(node);

    System.Console.WriteLine("\n\nLength of the linked list is " + linkedList.Count+", First is "+linkedList.First.data+", Last is "+linkedList.Last.data);
}
main();