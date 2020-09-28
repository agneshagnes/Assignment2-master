using Assignment.Enum;
using Assignment_1.AbstractClasses;
using Assignment_1.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1.Classes
{

    /// <summary>
    /// Represents an apartment, inherits the abstract class Estate
    /// <author> Agnes Hägnestrand and Andreas Holm</author>
    /// </summary>
    class Apartment : Estate
    {

        
        private TypeRes typeRes;
        private string floorNum;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        /// <param name="id"></param>
        /// <param name="floorNumber"></param>
        /// <param name="squareMeters"></param>
        /// <param name="lf"></param>
        /// <param name="image"></param>
        /// <param name="street"></param>
        /// <param name="city"></param>
        /// <param name="c"></param>
        /// <param name="ZipCode"></param>
        public Apartment(string id, string floorNumber, LegalForms lf, Bitmap image, Address address, Category cat, TypeAll typeAll)
        {
            floorNum = floorNumber;
            this.Id = id;
            this.Address = address;
            this.TypeAll = typeAll;
            this.typeRes = TypeRes.Apartment;

            // The unique attribute for this class
            this.UniqueAttribute = floorNumber;
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
            return TypeRes.Apartment;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getFloorNum()
        {
            return floorNum;
        }

        /// <summary>
        /// ToString method to help make a string that represents this an Apartment object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string result = $"{Id}  --------  {LegalForm}  --------  {Category}  --------  {typeRes}  --------  {Address.Country}  --------  {Address.City}  --------  {Address.Street}  --------  {Address.ZIPCode}  -------- FloorNum: {floorNum}";
            return result;
        }
    }
}
