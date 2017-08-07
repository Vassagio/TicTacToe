using System.Collections.Generic;
using Xunit;

namespace Project.Utilities.Tests {
    public class CircularLinkedListTest {
        private const string FIRST = "first";
        private const string SECOND = "second";
        private const string THIRD = "third";

        [Fact]
        public void NextOrFirst_EmptyList_ReturnsNull()
        {
            var linkedList = new LinkedList<string>();
            
            var nextOrFirst = linkedList.Find(FIRST).NextOrFirst();

            Assert.Null(nextOrFirst);            
        }

        [Fact]
        public void NextOrFirst_WhenNotLastItem_MoveNext() {
            var linkedList = BuildLinkedList();

            var nextOrFirst = linkedList.Find(FIRST).NextOrFirst();

            Assert.Equal(SECOND, nextOrFirst.Value);
        }

        [Fact]
        public void NextOrFirst_WhenLastItem_MoveFirst() {
            var linkedList = BuildLinkedList();

            var nextOrFirst = linkedList.Find(THIRD).NextOrFirst();

            Assert.Equal(FIRST, nextOrFirst.Value);
        }

        [Fact]
        public void PreviousOrLast_EmptyList_ReturnsNull()
        {
            var linkedList = new LinkedList<string>();

            var nextOrFirst = linkedList.Find(FIRST).PreviousOrLast();

            Assert.Null(nextOrFirst);
        }

        [Fact]
        public void PreviousOrLast_WhenNotFirstItem_MovePrevious() {
            var linkedList = BuildLinkedList();

            var nextOrFirst = linkedList.Find(THIRD).PreviousOrLast();

            Assert.Equal(SECOND, nextOrFirst.Value);
        }

        [Fact]
        public void PreviousOrLast_WhenFirstItem_MoveLast() {
            var linkedList = BuildLinkedList();

            var nextOrFirst = linkedList.Find(FIRST).PreviousOrLast();

            Assert.Equal(THIRD, nextOrFirst.Value);
        }

        private static LinkedList<string> BuildLinkedList() {
            var linkedList = new LinkedList<string>();
            linkedList.AddLast(FIRST);
            linkedList.AddLast(SECOND);
            linkedList.AddLast(THIRD);
            return linkedList;
        }
    }
}