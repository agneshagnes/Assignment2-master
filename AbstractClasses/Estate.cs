using Assignment.Enum;
using Assignment.Interface;
using Assignment_1.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1.AbstractClasses
{


    /// <summary>
    /// Abstract class to represent an Estate, is inherited by...
    /// Authors Agnes Hägnestrand and Andreas Holm
    /// </summary>
    abstract class  Estate : IEstate
    {
        private string id;
        private Address address;
        private LegalForms legForm;
        private Category cat;
        private Bitmap image;
        private TypeAll typeAll;
        private string uniqueAttribute;


        /// <summary>
        /// Abstract method to get the type of the objects that inherit the estate object.
        /// </summary>
        /// <returns></returns>
        public abstract Object getType();


        /// <summary>
        /// Get and set for the Id property
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }


        /// <summary>
        /// Get and set for the LegalForms Enum property
        /// </summary>
        public LegalForms LegalForm
        {
            get { return legForm; }
            set
            {legForm = value;}
        }


        /// <summary>
        /// Get and set property for the Address
        /// </summary>
        public Address Address
        {
            get { return address; }
            set { address = value; }
        }


        /// <summary>
        /// Get and set for the Category Enum property
        /// </summary>
        public Category Category
        {
            get { return cat; }
            set { cat = value; }
        }



        /// <summary>
        /// Get and set for the TypeAll enum property
        /// </summary>
        public TypeAll TypeAll
        {
            get { return typeAll; }
            set { typeAll = value; }
        }

        public Bitmap Image { get => image; set => image = value; }


        /// <summary>
        /// Get and set property
        /// </summary>
        public string UniqueAttribute
        {
            get { return uniqueAttribute;  }
            set {uniqueAttribute = value; }
        }

        /// <summary>
        /// Abstract ToString method to be overritten in the extending classes
        /// </summary>
        /// <returns></returns>
        public override abstract string ToString();
    }
}