/*********************************************************************************************************

 * Project: Name Queue Application
 * 
 * File: Node Class
 * 
 * Langauge: VS C#
 * 
 *
 *
 * Description: This file will implement a simple node that contains a name string value and a 
 *              link to the next node in the link list.
 *              
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
 * 11/09/2020               - Properties for name and next were created                                             
 * 11/09/2020               - Constructor created for nodes name and next                     
 * 11/09/2020               - Method added to display the node                       
 * 
 * 
*********************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT325NameQueue_GEW {
    class Node {

        //property
        public String Name { get; set; }     // This is the name entered by the user
        public Node Next { get; set; }      // pointer to the next node

        // constructor
        /// <summary>
        /// This constructor creates a new Node containing the number passed in.
        /// </summary>
        /// <param name="name"></param>

        public Node(String name) {
            Name = name;
            Next = null;

        }

        //method

        /// <summary>
        /// This method will display the node in a generic fashion.
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return String.Format("Number = {0}, Next = {1}", this.Name, this.Next);
        }
    }
}
