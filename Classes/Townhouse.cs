using Assignment.Enum;
using Assignment_1.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1.Classes
{

    /// <summary>
    /// Represents a townhouse, inherits the abstract class Estate
    /// <author> Agnes Hägnestrand and Andreas Holm</author>
    /// </summary>
    class Townhouse : Estate
    {

       private string height;
        private TypeRes typeRes;

        public Townhouse(string id, string height, LegalForms lf, Bitmap image, Address address, Category cat, TypeAll typeAll)
        {
            this.Address = address;
            this.Id = id;
            this.TypeAll = typeAll;
            this.typeRes = TypeRes.Townhouse;

            // The unique attribute for this class
            this.height = height;

            UniqueAttribute = height;
            this.LegalForm = lf;
            this.Image = image;
            this.Category = cat;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override Object getType()
        {
            return TypeRes.Townhouse;
        }


        public string getHeight()
        {
            return height;
        }

        /// <summary>
        /// ToString method to help make a string of a Townhouse object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string result = $"{Id}  --------  {LegalForm}  --------  {Category}  --------  {typeRes}  --------  {Address.Country}  --------  {Address.City}  --------  {Address.Street}  --------  {Address.ZIPCode}  -------- Height: {height}";
            return result;
        }
    }
}
