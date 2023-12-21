using Patterns.Graph;
using Patterns.Hash;
using Patterns.LinkedList;
using Patterns.Quene;
using Patterns.Stack;
using Patterns.Tree;

internal class Program
{
    private static void Main(string[] args)
    {
        TestTree();
        //TestGraph();
        //TestHash();
        //TestStack();
        //TestQuene();
        //TestLinkedList();
    }

    private static void TestGraph()
    {
        MyGraph testGraph = new MyGraph();
        testGraph.AddNode(1); testGraph.AddNode(3); testGraph.AddNode(5);
        testGraph.AddNode(10); testGraph.AddNode(13); testGraph.AddNode(15);
        testGraph.AddNode(2); testGraph.AddNode(7); testGraph.AddNode(1);

        testGraph.DeleteNode(3); testGraph.AddNode(3); testGraph.DeleteNode(99);

        testGraph.ConnectNodes(1,3); testGraph.ConnectNodes(1, 5);
        testGraph.ConnectNodes(2, 7); testGraph.ConnectNodes(5, 7);
        testGraph.ConnectNodes(13, 15); testGraph.ConnectNodes(13, 10);
        testGraph.ConnectNodes(122, 3); testGraph.ConnectNodes(3, 3);

        testGraph.SearchShortWay(3,10);

        //testGraph.DeleteConnection(1,3); testGraph.ConnectNodes(1, 3);
        //testGraph.DeleteConnection(122,3); testGraph.DeleteConnection(2, 3);

        //testGraph.GetNode(1);testGraph.GetNode(99);
        //testGraph.PrintConnectedNodes(2);
        //testGraph.PrintConnectedNodes(10);
        //testGraph.PrintConnectedNodes(999);

        //testGraph.ClearGraph();
        //testGraph.DeleteNode(3);
        //testGraph.PrintConnectedNodes(2);
        //testGraph.GetNode(1);
        //testGraph.DeleteConnection(122, 3);
        //testGraph.ConnectNodes(13, 15);
    }

    private static void TestTree()
    {
        BinarySearchTree testTree = new();
        testTree.AddingNewNode(5);
        testTree.AddingNewNode(6);
        testTree.AddingNewNode(7);
        testTree.AddingNewNode(7);
        testTree.AddingNewNode(1);
        testTree.AddingNewNode(2);
        testTree.AddingNewNode(3);
        testTree.PrintNodes();

        //testTree.FindNode(5);
        //testTree.FindNode(11);

        testTree.RemoveNode(1);
        testTree.PrintNodes();
        testTree.RemoveNode(5);
        testTree.RemoveNode(17);
        testTree.PrintNodes();
    }

    private static void TestHash()
    {
        MyHashTable testHash = new MyHashTable();

        testHash.AddHash(12);
        testHash.AddHash(1.3);
        testHash.AddHash("dfhdf");
        testHash.AddHash('d');

        testHash.PrintHashes();

        testHash.RemoveHash(3);
        testHash.RemoveHash(12);
        testHash.AddHash(234);

        testHash.AddHash(12);
        testHash.PrintHashes();

        testHash.AddHash('d');
        testHash.PrintHashes();

        var hash = testHash.GetValue(1);
        if (hash != null && hash is int)
        {
            Console.WriteLine($"{hash} is int");
        }
        var hash_ = testHash.GetValue(0);
        if (hash_ != null && hash_ is int)
        {
            Console.WriteLine($"{hash_} is int");
        }

        testHash.Clear();
        testHash.PrintHashes();
    }

    private static void TestStack()
    {
        MyStack testStack = new();

        Console.WriteLine(testStack.FindNodePosition(1));

        testStack.AddNewNode(7);
        testStack.AddNewNode(8);
        testStack.AddNewNode(1);
        testStack.AddNewNode(2);
        testStack.AddNewNode(1);
        testStack.AddNewNode(17);

        Console.WriteLine(testStack.FindNodePosition(17));

        testStack.PrintAllNodes();
        testStack.AddNewNode(1);
        testStack.PrintAllNodes();

        testStack.Peek();
        var testNode = testStack.Pop();
        Console.WriteLine($"testNode = {testNode.MyValue}, multiplyX7 = {testNode.MyValue * 7}");
        testStack.Peek();
        testStack.PrintAllNodes();

        testStack.Count();

        testStack.Clear();
        testStack.PrintAllNodes();
        testStack.Count();

        Console.WriteLine(testStack.FindNodePosition(17));
    }

    private static void TestQuene()
    {
        MyQuene testQuene = new();
        testQuene.AddNewNode(7);
        testQuene.AddNewNode(8);
        testQuene.AddNewNode(1);
        testQuene.AddNewNode(2);
        testQuene.AddNewNode(1);
        testQuene.AddNewNode(17);

        testQuene.PrintAllNodes();
        testQuene.Peek();
        var testNode = testQuene.Pop();
        Console.WriteLine($"testNode = {testNode.MyValue}, square = {testNode.MyValue^2}");
        testQuene.Peek();
        testQuene.PrintAllNodes();

        testQuene.Count();

        testQuene.Clear();
        testQuene.PrintAllNodes();
        testQuene.Count();
    }

    private static void TestLinkedList() 
    {
        MyLinkedList testList = new();
        testList.AddNewNode(7);
        testList.AddNewNode(8);
        testList.AddNewNode(1);
        testList.AddNewNode(2);
        testList.AddNewNode(1);

        testList.RemoveListNode(0);
        testList.RemoveListNode(1);

        testList.AddNewNode(17);

        testList.FindNode(0);

        testList.FindNode(2);

        testList.PrintAllNodes();
        testList.SortList();
        testList.PrintAllNodes();
        Console.WriteLine(testList.Count());

    }
}