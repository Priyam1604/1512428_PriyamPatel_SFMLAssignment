using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.System;


    public class Node<T> where T : Shape
    {
        public Node<T> next;
        public T data;

        public Node(T data)
        {
            this.data = data;
        }

    public override string ToString()
    {
        return data.ToString();
    }
    public void Delete()
        {
            this.next = null;
            this.data = null;
        }
    }
    
    public class LinkedList_Code<T> where T : Shape
    {
        public Node<T> head;
        public int count;

        public LinkedList_Code()
        {
            count = 0;
        }

        public void Enqueue(T data)
        {
            Node<T> new_Node = new Node<T>(data);
            new_Node.next = this.head;
            this.head = new_Node;
            this.count++;                    
            Console.WriteLine(this.count);

            
        }

        public T Dequeue()
        {
            if (this.head == null) return null;

            Node<T> traversl = this.head;
            Node<T> trav_trail = this.head;
            while (traversl.next != null)
            {
                trav_trail = traversl;
                traversl = traversl.next;
            }

            trav_trail.next = null;
            this.count--;
            if (this.count == 0)
                this.head = null;
            Console.WriteLine(this.count);
            GC.Collect();
            return traversl.data;
        }

        public void Empty()
        {
            while (this.count > 0)
                this.Dequeue();
        }
    }

