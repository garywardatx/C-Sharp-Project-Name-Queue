/*********************************************************************************************************

 * Project: Name Queue Application
 * 
 * File: Queue Class
 * 
 * Langauge: VS C#
 * 
 *
 *
 * Description: This file will implement a queue using a link list.
 *
 *
 * College: Husson University
 * 
 * Course:  IT 325
 * 
 * Author: Gary Edward Ward
 * 
 * 
 * 
 * Change Log:
 * 
 * Date                         Description of Change
 * 
 * ---------------           ----------------------------------------------------------------------------
 * 
 * 11/09/2020               - Initial writing
 * 11/09/2020               - Property for count and nodes front/back were added.                                                 
 * 11/10/2020               - Constructor for count and nodes front/back were added.                        
 * 11/10/2020               - Methods for Enqueue and IsEmpty added. Int data types substituted with String.
 * 11/10/2020               - Method added for IEnumerator, Dequeue, and Peek
 * 
 * 
*********************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT325NameQueue_GEW {
    class CQueue : IEnumerable<String> {

        //property
        public int Count { get; set; }      // number of items
                                            // in the queue
        private Node Front { get; set; }    // pointer to the first 
                                            // item in the queue

        private Node Back { get; set; }    // pointer to the last 
                                           // item in the queue

        // constructor
        /// <summary>
        /// Creates an empty queue.
        /// </summary>
        public CQueue() {
            Count = 0;
            Front = null;
            Back = null;

        }

        // method

        /// <summary>
        /// This method returns the first item from the fromnt of the queue
        /// </summary>
        /// <returns></returns>
        public String Dequeue() {
            String data;

            if (IsEmpty()) {
                // empty queue throws an error
                throw new InvalidOperationException("The queue is empty");
            }

            // return the first item in the queue

            data = Front.Name;
            Front = Front.Next;

            // decrement the count
            Count--;

            // return the data
            return data;

        }

        /// <summary>
        /// Adds a new item to the back of the queue
        /// </summary>
        /// <param name="data">The item to be added</param>
        public void Enqueue(String data) {
            // create a node with the new data
            Node item = new Node(data);

            if (IsEmpty()) {
                // special case, empty queue
                Front = item;
                Back = Front;

            }
            else {
                // add the new item to the back of the queue
                Back.Next = item;
                Back = Back.Next;
                item.Next = null;

            }

            // increment count
            Count++;
        }

        /// <summary>
        /// This method returns true if the queue is empty
        /// false if the queue is not empty
        /// </summary>
        /// <returns>returns true if queue is empty, false otherwise</returns>
        public bool IsEmpty() {
            return Count == 0;
        }

        /// <summary>
        /// This method returns the first item from the fromnt of the queue
        /// WITHOUT deleting it
        /// </summary>
        /// <returns></returns>
        public String Peek() {

            if (IsEmpty()) {
                // empty queue throws an error
                throw new InvalidOperationException("The queue is empty");
            }

            // return the first item in the queue, without removing it
            return Front.Name;

        }

        /// <summary>
        /// This method allows for the traversal of the items in the queue
        /// from front to back by the calling method.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<String> GetEnumerator() {
            // start from the front of the queue
            Node current = Front;

            // wlak down the queue (link list)
            // send one item back at a time

            while (current != null) {
                yield return current.Name;
                current = current.Next;

            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return this.GetEnumerator();
        }
    }
}
