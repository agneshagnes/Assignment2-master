using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Assignment.Enum;
using Assignment_1.AbstractClasses;
using Assignment_1.Classes;

namespace Assignment_1.Classes
{

    /// <summary>
    /// A class to represent a House
    /// Authors Agnes Hägnestrand and Andreas Holm
    /// </summary>
    class House : Estate
    {
        
        private TypeRes typeRes;
        private string color;

        public House(string id, string color, LegalForms lf, Bitmap image, Address address, Category cat, TypeAll typeAll)
        {
            this.color = color;
            this.Address = address;
            this.Id = id;
            this.TypeAll = typeAll;
            this.typeRes = TypeRes.House;

            // The unique attribute for this class
            this.UniqueAttribute = color;
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
            return TypeRes.House;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getColor()
        {
            return color;
        }

        /*

        /// <summary>
        /// ToString method to help make a string of a House object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string result = $"ID: {Id} LegalForm: {LegalForm} Category: {Category} Country: {Address.Country} City {Address.City} Street: {Address.Street} ZipCode: {Address.ZIPCode} Color: {color}";
            return resul

        */

        public override string ToString()
        {
            string result =  $"{Id}  --------  {LegalForm}  --------  {Category}  --------  {typeRes}  --------  {Address.Country}  --------  {Address.City}  --------  {Address.Street}  --------  {Address.ZIPCode}  -------- Color: {color}";
            return result;
        }
    
    }
}
