using System.Collections.Generic;

namespace Project.Utilities {
    public static class CircularLinkedList {
        public static LinkedListNode<T> NextOrFirst<T>(this LinkedListNode<T> current) => current.Next ?? current.List.First;

        public static LinkedListNode<T> PreviousOrLast<T>(this LinkedListNode<T> current) => current.Previous ?? current.List.Last;
    }
}