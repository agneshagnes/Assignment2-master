using Assignment.Enum;
using Assignment_1.AbstractClasses;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_1.Classes
{

    /// <summary>
    /// Class to handle all the logic for the program, contains an ArrayList of estates, a HashSet of ids and methods to manipulate these datastructures.
    /// <author> Agnes Hägnestrand and Andreas Holm</author>
    /// </summary>
    class EstateHandler
    {

        #region attibutes
        // To handle all the estates
        private ArrayList estates = new ArrayList();

        // A set to make sure all the ids are unique
        private HashSet<string> ids = new HashSet<string>();

        // The RichTextBox component in the GUI
        private ListBox listBox1;
        #endregion



        /// <summary>
        /// Constructor to set up the component RichTextBox
        /// </summary>
        /// <param name="richTxtBx"></param>
        public EstateHandler(ListBox listBox1)
        {
            this.listBox1 = listBox1;
        }

        

        /// <summary>
        /// Validates that all the information is filled in correctly and then creates an estate object
        /// and puts it into the estates list.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="legalForm"></param>
        /// <param name="country"></param>
        /// <param name="city"></param>
        /// <param name="zipCode"></param>
        /// <param name="street"></param>
        /// <param name="category"></param>
        /// <param name="type"></param>
        /// <param name="text"></param>
        /// <param name="image"></param>
        public void createEstate(string id, LegalForms legalForm, Countries country, string city, string zipCode, string street, Category category, object type, string text, Bitmap image, TypeAll typeAll, bool isModifyingEstate)
        {
            if(isModifyingEstate)
            {
                Estate oldEstate = GetEstate(id);
                estates.Remove(oldEstate);
                ids.Remove(id);
            }

            // || !hasChosenImage(image) ?? Maybe remove??

            if (!isIdValid(id) || !uniqueId(id)  || !allFieldsFilled(city, zipCode, street, text))
            {
                return;
            }

            Address address = new Address(street, zipCode, city, country);

            switch (type)
            {
                
                case TypeCom.Shop:
                    Shop shop = new Shop(id, text, legalForm, image, address, category, typeAll);
                    estates.Add(shop);
                    ids.Add(id);
                    break;
                case TypeCom.Warehouse:
                    Estate warehouse = new Warehouse(id, text, legalForm, image, address, category, typeAll);
                    estates.Add(warehouse);
                    ids.Add(id);
                    break;
                case TypeRes.Apartment:
                    Estate apartment = new Apartment(id, text, legalForm, image, address, category, typeAll);
                    estates.Add(apartment);
                    ids.Add(id);
                    break;
                case TypeRes.House:
                    Estate house = new House(id, text, legalForm, image, address, category, typeAll);
                    estates.Add(house);
                    ids.Add(id);
                    break;
                case TypeRes.Townhouse:
                    Estate townhouse = new Townhouse(id, text, legalForm, image, address, category, typeAll);
                    estates.Add(townhouse);
                    ids.Add(id);
                    break;
                case TypeRes.Villa:
                    Estate villa = new Villa(id, text, legalForm, image, address, category, typeAll);
                    estates.Add(villa);
                    ids.Add(id);
                    break;
                default:
                    break;
            }

            updateTxtWindow(); 
        }

        
        /// <summary>
        /// Helper method to fill the estates with 10 estate object to make it easier for the user to test the search
        /// Removes the previously estates in the estates ArrayList
        /// </summary>
        public void genereateEstates()
        {

        //C: \Users\h_o_l\source\repos\Assignment_2.0\Resources\estate.jpg
         //Bitmap image = new Bitmap("/Resources/estate.jpg");
           
            Address address1 = new Address("Street1", "24010", "Lund", Countries.Sverige);
            Address address2 = new Address("Street2", "22224", "Malmö", Countries.Sverige);
            Address address3 = new Address("Street3", "08122", "Ystad", Countries.Sverige);

            Estate shop1= new Shop("0001", "Food", LegalForms.Rental, null, address1, Category.Commercial, TypeAll.Shop);
            Estate shop2 = new Shop("0002", "Paint", LegalForms.Rental, null, address2, Category.Commercial, TypeAll.Shop);
            Estate shop3 = new Shop("0003", "Pizza", LegalForms.Ownership, null, address3, Category.Commercial, TypeAll.Shop);

            Estate warehouse1 = new Warehouse("0004", "1000", LegalForms.Ownership, null, address1, Category.Commercial, TypeAll.Warehouse);
            Estate warehouse2 = new Warehouse("0005", "2000", LegalForms.Rental, null, address1, Category.Commercial, TypeAll.Warehouse);
            Estate warehouse3 = new Warehouse("0006", "3000", LegalForms.Ownership, null, address2, Category.Commercial, TypeAll.Warehouse);

            Estate villa1 = new Villa("0007", "100", LegalForms.Rental, null, address2, Category.Residential, TypeAll.Villa);
            Estate villa2 = new Villa("0008", "200", LegalForms.Ownership, null, address3, Category.Residential, TypeAll.Villa);
            Estate villa3 = new Villa("0009", "300", LegalForms.Rental, null, address3, Category.Residential, TypeAll.Villa);

            deleteAllEstates();

            estates.Add(shop1);
            estates.Add(shop2);
            estates.Add(shop3);
            estates.Add(warehouse1);
            estates.Add(warehouse2);
            estates.Add(warehouse3);
            estates.Add(villa1);
            estates.Add(villa2);
            estates.Add(villa3);

            ids.Add(shop1.Id);
            ids.Add(shop2.Id);
            ids.Add(shop3.Id);
            ids.Add(warehouse1.Id);
            ids.Add(warehouse2.Id);
            ids.Add(warehouse3.Id);
            ids.Add(villa1.Id);
            ids.Add(villa2.Id);
            ids.Add(villa3.Id);

            updateTxtWindow();
        }

        

        /// <summary>
        /// Shows all the estates in the estates list
        /// </summary>
        public void showAllEstates()
        {
            updateTxtWindow();
        }


        /// <summary>
        /// Deletes all the estates from the estates list
        /// </summary>
        public void deleteAllEstates()
        {
            estates.Clear();
            ids.Clear();
            updateTxtWindow();
        }


        /// <summary>
        /// Checks if the user has filled in all the fields
        /// </summary>
        /// <param name="city"></param>
        /// <param name="zipCode"></param>
        /// <param name="street"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        private bool allFieldsFilled(string city, string zipCode, string street, string text)
        {
            if(city.Equals("") || zipCode.Equals("") ||street.Equals("") || text.Equals(""))
            {
                MessageBox.Show("Please fill in all the fields");
                return false;
            }

            return true;
        }

       

        /// <summary>
        /// Checks if the user has chosen an image
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        private bool hasChosenImage(Bitmap image)
        {
            if(image == null)
            {
                MessageBox.Show("Please choose a picture");
                return false;
            }

            return true;
        }


        /// <summary>
        /// Checks if the given id is unique
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool uniqueId(string id)
        {
            if(ids.Contains(id))
            {
                MessageBox.Show("The Id is already in our register, please choose an unique Id, to se all the Ids browse to the Search/Delete tab");
            }

            return !ids.Contains(id);
        }



        /// <summary>
        /// Checks if the given id is in the ids HashSet
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool containsId(string id)
        {
            return ids.Contains(id);
        }



        /// <summary>
        /// Validate that the Id follows the preapproved format, four numbers
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool isIdValid(string id)
        {
            int correctIdLenght = 4;
            if(id.Length != correctIdLenght)
            {
                MessageBox.Show("The Id you chose is not a valid Id, it should consist of four numbers, eg 1234");
                return false;
            }

            if (!id.All(char.IsDigit)){
                MessageBox.Show("The id must consist of all numbers!");
                return false;
            }

            return true;
        }



        /// <summary>
        /// Add an estate to the list
        /// </summary>
        /// <param name="estate"></param>
        public void AddEstate(Estate estate)
        {
            ids.Add(estate.Id);
            estates.Add(estate);
        }



        /// <summary>
        /// Deletes the Estate object with the given id, if the Estate is not present, 
        /// return null and print out a message to the user.
        /// </summary>
        /// <param name="id"></param>
        public void DeleteEstate(string id)
        {

            // Check to se if the given id is present in the ids set
            if (!ids.Contains(id))
            {
                MessageBox.Show($"There is no Estate object in the hashSet that has the id {id}");
                return;
            }

            // Removes the estate with the given id
            foreach (Estate e in estates)
            {
                if (e.Id == id)
                {
                    estates.Remove(e);
                    ids.Remove(id);
                    updateTxtWindow();
                    MessageBox.Show($"Estate with the id {id} was successfully deleted");
                    return;
                }
            }
        }



        /// <summary>
        /// Updates the list of estates is the RichTextBox window in the Search/Delete tab
        /// </summary>
        private void updateTxtWindow()
        {
            listBox1.Items.Clear();
            string estatesList = "";

            foreach(Estate e in estates)
            {
                //estatesList += e.ToString() + "\n";
                listBox1.Items.Add(e.ToString() + "\n");
            }

            listBox1.Items.Add(estatesList);
        }
        public void SaveFile(string id, LegalForms legalForm, Countries country, string city, string zipCode, string street, Category category, object type, string text, TypeAll typeAll)
        {
            String msg = "Id:" + id + "Legalform:" + legalForm + "Country:" + country + "City:" + city + "zipcode:" + zipCode + "Street:" + street + " Category:" + category + "Ttype:" + type + "Text:" + text + "Type:" + typeAll;
            String txt = "\file.txt";

         //   using (StringReader reader = new StringReader(msg.ToString())
           // {
               // string readText = await reader.ReadToEndAsync
         //   }
          //  FileStream fileStream = new FileStream(txt, FileMode.Create, FileAccess.Write);
           // StreamWriter streamWriter = new StreamWriter(fileStream);
           // streamWriter.BaseStream.Seek(0, SeekOrigin.End);
           // streamWriter.Write(msg);
           // streamWriter.Flush();
           // streamWriter.Close();
        }



        /// <summary>
        /// Helper method to get the Estate with the given id, if the Estate is not present, 
        /// return null and print out a message to the user.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Estate GetEstate(string id)
        {

            // Check to se if the given id is present in the ids set
            if (!ids.Contains(id))
            {
                MessageBox.Show($"There is no Estate object in the hashSet that has the id {id}");
                return null;
            }

            foreach (Estate e in estates)
            {
                if (e.Id == id)
                {
                    return e;
                }
            }

            return null;
        }



        /// <summary>
        /// Sets the string in RichTextBox component to all the Estates that has the searched type and city
        /// </summary>
        /// <param name="type"></param>
        /// <param name="city"></param>
        /// <returns></returns>
        
        public void SearchEstate(TypeAll type, string city)
        {
            string estatesList = "";
            foreach (Estate e in estates)
            {
                if (e.TypeAll.Equals(type) && e.Address.City.Equals(city))
                {
                    estatesList += e.ToString() + "\n";

                }
            }

            listBox1.Items.Add(estatesList);
        }



        /// <summary>
        /// Updates the text fields when the user presses CHANGE ESTATE from the given id
        /// </summary>
        /// <param name="comboBoxLegalForm"></param>
        /// <param name="comboBoxCountry"></param>
        /// <param name="comboBoxCategory"></param>
        /// <param name="comboBoxType"></param>
        /// <param name="textchange"></param>
        /// <param name="textcity"></param>
        /// <param name="textzip"></param>
        /// <param name="textStreet"></param>
        /// <param name="textUnique"></param>
        /// <param name="changeText"></param>
        /// <param name="textId"></param>
        /// <param name="pictureBoxImage"></param>
        public void UpdateEstatesFields(ComboBox comboBoxLegalForm, ComboBox comboBoxCountry, ComboBox comboBoxCategory, ComboBox comboBoxType, TextBox textchange, TextBox textcity, TextBox textzip, TextBox textStreet, TextBox textUnique, string changeText, TextBox textId, PictureBox pictureBoxImage)
        {

            if(!ids.Contains(changeText))
            {
                MessageBox.Show($"There is no Estate object in the hashSet that has the id {changeText}");
                return;

            } else
            {
                foreach (Estate e in estates)
                {
                    if (e.Id == changeText)
                    {

                        textId.Text = changeText;
                        comboBoxLegalForm.SelectedItem = e.LegalForm;
                        comboBoxCountry.SelectedItem = e.Address.Country;
                        textcity.Text = e.Address.City.ToString();
                        textzip.Text = e.Address.ZIPCode.ToString();
                        textStreet.Text = e.Address.Street.ToString();

                        comboBoxCategory.SelectedItem = e.Category;
                        comboBoxType.SelectedItem = e.getType();


                        textUnique.Text = e.UniqueAttribute;

                        if(e.Image != null)
                        {
                            pictureBoxImage.Image = e.Image;
                        }

                        return;
                    }
                }
            }
        }
    }
}
