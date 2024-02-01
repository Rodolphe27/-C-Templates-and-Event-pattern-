
namespace Liste
{
public interface Iterator<T>
{
		bool HasNext();
		T Next();
}
public class Linkedlist<T>
{
    // Innere Klasse für das Listenelement
    private class Node
    {
        public T Data { get; set; }
        public Node Next { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }


    // Innere Klasse für den Iterator
    private class ListIterator: Iterator<T>
    {
        private Node current;

        public ListIterator(Node start)
        {
            current = start;
        }

        // Überprüft, ob es ein nächstes Element gibt
        public bool HasNext()
        {
            return current != null;
        }

        // Liefert das nächste Element und bewegt den Iterator vorwärts
        public T Next()
        {

            T data = current.Data;
            current = current.Next;
            return data;
        }
    }

    // Kopf der Liste
    private Node head=null, tail=null;

    // Fügt ein Element am Anfang der Liste hinzu
    public void AddFirst(T data)
    {  
        Node newNode = new Node(data);
		if (head == null)
		{
        head = tail=newNode;
		}
		tail.Next= newNode;
        tail = newNode;
		
    }

    // Entfernt das i-te Element aus der Liste
    public void Remove(int index)
    {
        if (index < 0)
        {
          return ;  
        }

        if (index == 0)
        {
            // Sonderfall: Entferne das erste Element
            if (head != null)
            {
                head = head.Next;
            }
        }
        if (index>0)
        {
            // Suche das Vorgängerelement des zu entfernenden Elements
            Node prev=null;
            Node curr=head;
            int i=0;
            while(i<index && curr.Next!=null){
                prev= curr;
                curr=curr.Next;
                i++;

            }
            prev.Next=curr.Next;

            if(curr.Next==null){
                tail=prev;
            }

            
        }
    }


    // Erstellt einen Iterator für die Liste
    public Iterator<T> GetIterator()
    {
        return new ListIterator(head);
    }
}
//     class Program

// {
//     static void Main()
//     {
//         // Beispiel für die Verwendung der LinkedList
//         Linkedlist<int> linkedist = new Linkedlist<int>();
//         linkedist.AddFirst(3);
//         linkedist.AddFirst(2);
//         linkedist.AddFirst(1);

//         // Iterator verwenden, um die Liste zu durchlaufen und auszugeben
//         Iterator<int> iterator = linkedist.GetIterator();
//         while (iterator.HasNext())
//         {
//             Console.WriteLine(iterator.Next());
//         }

//         // Element an Index 1 entfernen
//         linkedist.Remove(1);

//         // Iterator erneut verwenden, um die aktualisierte Liste auszugeben
//         iterator = linkedist.GetIterator();
//         while (iterator.HasNext())
//         {
//             Console.WriteLine(iterator.Next());
//         }
//     }
// }



}