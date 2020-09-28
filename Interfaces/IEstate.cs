using Assignment_1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Interface
{


    /// <summary>
    /// An interface that is implemented by the estate class
    /// <author> Agnes Hägnestrand and Andreas Holm</author>
    /// </summary>
    interface IEstate
    {
        /// <summary>
        /// Id proprety with get and set 
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// Address proprety with get and set
        /// </summary>
        Address Address { get; set; }
    }
}