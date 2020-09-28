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
    /// Represents a villa, inherits the abstract class Estate
    /// <author> Agnes Hägnestrand and Andreas Holm</author>
    /// </summary>
    class Villa : Estate
    {

       private string lawnSize;
       private TypeRes typeRes;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        /// <param name="id"></param>
        /// <param name="lawnSize"></param>
        /// <param name="squareMeters"></param>
        /// <param name="lf"></param>
        /// <param name="image"></param>
        /// <param name="street"></param>
        /// <param name="city"></param>
        /// <param name="c"></param>
        /// <param name="ZipCode"></param>
        public Villa(string id, string lawnSize, LegalForms lf, Bitmap image, Address address, Category cat, TypeAll typeAll)
        {
            this.Address = address;
            this.Id = id;
            this.TypeAll = typeAll;
            this.typeRes = TypeRes.Villa;

            // The unique attribute for this class
            this.lawnSize = lawnSize;
            UniqueAttribute = lawnSize;
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
            return TypeRes.Villa;
        }

        public string getLawnSize()
        {
            return lawnSize;
        }

        /// <summary>
        /// ToString method to help make a string that represents this an Villa object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string result = $"{Id}  --------  {LegalForm}  --------  {Category}  --------  {typeRes}  --------  {Address.Country}  --------  {Address.City}  --------  {Address.Street}  --------  {Address.ZIPCode}  -------- LawnSize: {lawnSize}";
            return result;
        }
    }
}
