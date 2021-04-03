using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library:IEnumerable<Book>
    {
        private List<Book> books;
        public Library(params Book[] books)
        {
            var sorted = books.ToList();
            sorted.Sort(new BookComparator());
            this.Books = sorted;
        }

        public List<Book> Books { get; set; }

        public IEnumerator<Book> GetEnumerator()
        {
            return Books.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        private class LibraryIterator : IEnumerator<Book>
        {
            private int currentIndex = -1;
            private readonly List<Book> books;

            public LibraryIterator(List<Book> books)
            {
                this.Reset();
                this.books = new List<Book>(books);
            }
            public Book Current
            {
                get
                {
                    return this.books[this.currentIndex];
                }
            }

            object IEnumerator.Current => this.Current;

            public void Dispose()
            {

            }

            public bool MoveNext()
            {
                this.currentIndex++;

                if (this.currentIndex >= this.books.Count)
                {
                    return false;
                }
                return true;
            }

            public void Reset()
            {
                this.currentIndex = -1;
            }
        }
    }
}
