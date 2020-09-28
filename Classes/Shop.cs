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
    /// Represents a shop, inherits the abstract class Estate
    /// <author> Agnes Hägnestrand and Andreas Holm</author>
    /// </summary>
    class Shop : Estate
    {

       private string typeOfShop;
        private TypeCom typeCom;

        public Shop(string id, string typeOfShop, LegalForms lf, Bitmap image, Address address, Category cat, TypeAll typeAll)
        {
            this.Address = address;
            this.Id = id;
            this.TypeAll = typeAll;
            this.typeCom = TypeCom.Shop;

            // The unique attribute for this class
            this.typeOfShop = typeOfShop;

            UniqueAttribute = typeOfShop;
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
            return TypeCom.Shop;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTypeOfShop()
        {
            return typeOfShop;
        }


        /// <summary>
        /// ToString method to help make a string of a Shop object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string result = $"{Id}  --------  {LegalForm}  --------  {Category}  --------  {typeCom}  --------  {Address.Country}  --------  {Address.City}  --------  {Address.Street}  --------  {Address.ZIPCode}  -------- TypeOfShop: {typeOfShop}";
            return result;
        }
    }
}
