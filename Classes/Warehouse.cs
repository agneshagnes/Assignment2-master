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
    /// Represents an warehouse, inherits the abstract class Estate
    /// <author> Agnes Hägnestrand and Andreas Holm</author>
    /// </summary>
    class Warehouse : Estate
    {

       private string cubicMeterCapacity;
        private TypeCom typeCom;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cubicMeterCapacity"></param>
        /// <param name="lf"></param>
        /// <param name="image"></param>
        /// <param name="address"></param>
        /// <param name="cat"></param>
        /// <param name="typeAll"></param>
        public Warehouse(string id, string cubicMeterCapacity, LegalForms lf, Bitmap image, Address address, Category cat, TypeAll typeAll)
        {
            this.Address = address;
            this.Id = id;
            this.TypeAll = typeAll;
            this.typeCom = TypeCom.Warehouse;

            // The unique attribute for this class
            this.cubicMeterCapacity = cubicMeterCapacity;

            UniqueAttribute = cubicMeterCapacity;
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
            return TypeCom.Warehouse;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getCubicMeterCapacity()
        {
            return cubicMeterCapacity;
        }

        /// <summary>
        /// ToString method to help make a string of a Warehouse object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string result = $"{Id}  --------  {LegalForm}  --------  {Category}  --------  {typeCom}  --------  {Address.Country}  --------  {Address.City}  --------  {Address.Street}  --------  {Address.ZIPCode}  -------- Squaremeters: {cubicMeterCapacity}";
            return result;
        }
    }
}
