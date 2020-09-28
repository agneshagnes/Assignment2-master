using Assignment.Enum;
using Assignment_1.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_2._0
{


    /// <summary>
    /// 
    /// </summary>
    public partial class tabCreateChange : Form
    {

        // The image the user will choose for an estate
        private Bitmap image = null;
        // Handler for the estates, contains a ArrayList for the estates and a HashSet with Ids for quick lookup
        private EstateHandler estateHandler;


        /// <summary>
        /// Constructor to the components
        /// </summary>
        public tabCreateChange()
        {
            InitializeComponent();

            btnSaveChanges.Enabled = false;
            estateHandler = new EstateHandler(listBox1);
            comboBoxCountry.DataSource = Countries.GetValues(typeof(Countries));
            comboBoxLegalForm.DataSource = LegalForms.GetValues(typeof(LegalForms));
            comboBox3.DataSource = Category.GetValues(typeof(Category));
            comboBoxLegalForm.DataSource = LegalForms.GetValues(typeof(LegalForms));
            comboBox5.DataSource = TypeAll.GetValues(typeof(TypeAll));
            lblDynamicTxt1.Text = "---------";
            btnChangeEstate.BackColor = Color.FromArgb(140, 135, 222);
            btnCreateEstate.BackColor = Color.FromArgb(140, 135, 222);
            btnChooseImage.BackColor = Color.FromArgb(140, 135, 222);
            btnSaveChanges.BackColor = Color.FromArgb(168, 165, 209);
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }



        /// <summary>
        /// If the the id is in the ids HashSet this method updates the text fields, image and comboboxes with
        /// the values from the estate with that id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            string changeEstatetext = textBoxChangeEstate.Text;
            estateHandler.UpdateEstatesFields(comboBoxLegalForm, comboBoxCountry, comboBox3, comboBox4, textBoxChangeEstate, textBoxCity, textBoxZipCode, textBoxStreet, textBox6, changeEstatetext, textId, pictureBoxImage);
            
            if(estateHandler.containsId(changeEstatetext))
            {
                comboBox4_SelectedIndexChanged(sender, e);
                
                // Enabling and disabling buttons to hinder the user to press buttons that should not be pressed
                textId.ReadOnly = true;
                btnCreateEstate.Enabled = false;
                btnChangeEstate.Enabled = false;
                btnSaveChanges.Enabled = true;
                btnDeleteAll.Enabled = false;
                btnGenerateEstates.Enabled = false;
                btnSearch.Enabled = false;
                btnShowAll.Enabled = false;
                btnDelete.Enabled = false;

                btnSaveChanges.BackColor = Color.FromArgb(140, 135, 222);
                btnCreateEstate.BackColor = Color.FromArgb(168, 165, 209);
                btnChangeEstate.BackColor = Color.FromArgb(168, 165, 209);
            }
        }

        /*
         - Få in id från textfält
         - Ta reda på estate med id finns i listan
         - om det finns, gå in i det estate och updatera samtliga fält med dess värden
         - Great succes?
         
         */

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// Method to chooose the image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChooseImage_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                image = new Bitmap(openFileDialog.FileName);
                pictureBoxImage.Image = image;
            }
        }


        private void comboBoxCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }


        /// <summary>
        /// Creates an estate with the given data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateEstate_Click(object sender, EventArgs e)
        {

            string id = textId.Text;
            LegalForms legalForm = (LegalForms) comboBoxLegalForm.SelectedItem;
            Countries country = (Countries)comboBoxCountry.SelectedItem;
            string city = textBoxCity.Text;
            string zipCode = textBoxZipCode.Text;
            string street = textBoxStreet.Text;
            Category category = (Category)comboBox3.SelectedItem;
            var type = comboBox4.SelectedItem;
            string text = textBox6.Text;
            TypeAll typeAll = (TypeAll)comboBox4.SelectedItem;

            bool isModifyingEstate = false;
            estateHandler.createEstate(id, legalForm, country, city, zipCode, street, category, type, text, image, typeAll, isModifyingEstate);
        }

        private void comboBoxLegalForm_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// Helper method to set the type-combobox with the correct Enum values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox3.SelectedItem.Equals(Category.Residential))
            {
                comboBox4.DataSource = TypeRes.GetValues(typeof(TypeRes));
            }
            else
            {
                comboBox4.DataSource = TypeCom.GetValues(typeof(TypeCom));
            }
        }


        /// <summary>
        /// Helper method to set the label for the unique attribute with the correct string 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox4.SelectedItem)
            {
                case TypeRes.Villa:
                    lblDynamicTxt1.Text = "Lawn size (m2):";
                break;

                case TypeRes.Apartment:
                    lblDynamicTxt1.Text = "Floor number:";
                break;

                case TypeRes.Townhouse:
                    lblDynamicTxt1.Text = "Height(meters):";
                break;

                case TypeRes.House:
                    lblDynamicTxt1.Text = "Color:";
                break;

                case TypeCom.Shop:
                    lblDynamicTxt1.Text = "Type of Shop:";
                break;

                case TypeCom.Warehouse:
                    lblDynamicTxt1.Text = "Capacity (m3):";
                break;

                default:
                    MessageBox.Show("Something went wrong, this type is not in the enum list");
                    break;
            }
        }

        private void lblSearchEstates_Click(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// When the delete button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string text = textBox8.Text;
            estateHandler.DeleteEstate(text);
        }


        /// <summary>
        /// When the search button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            TypeAll typeAll = (TypeAll)comboBox5.SelectedItem;
            string city = textBox9.Text;
            estateHandler.SearchEstate(typeAll, city);
        }


        /// <summary>
        /// Shows all the estates in the estates ArrayList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            estateHandler.showAllEstates();
        }


        /// <summary>
        /// Deletes all the estates in the estates ArrayList.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            estateHandler.deleteAllEstates();
        }


        /// <summary>
        /// Generates nine estates to make it easier for the user to test the search function.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerateEstates_Click(object sender, EventArgs e)
        {
            estateHandler.genereateEstates();
        }


        /// <summary>
        /// If the user clicks the save changes button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            string id = textId.Text;
            LegalForms legalForm = (LegalForms)comboBoxLegalForm.SelectedItem;
            Countries country = (Countries)comboBoxCountry.SelectedItem;
            string city = textBoxCity.Text;
            string zipCode = textBoxZipCode.Text;
            string street = textBoxStreet.Text;
            Category category = (Category)comboBox3.SelectedItem;
            var type = comboBox4.SelectedItem;
            string text = textBox6.Text;
            TypeAll typeAll = (TypeAll)comboBox4.SelectedItem;

            bool isModifyingEstate = true;
            estateHandler.createEstate(id, legalForm, country, city, zipCode, street, category, type, text, image, typeAll, isModifyingEstate);

            btnSaveChanges.Enabled = false;
            btnChangeEstate.Enabled = true;
            btnCreateEstate.Enabled = true;
            textId.ReadOnly = false;
            btnDeleteAll.Enabled = true;
            btnGenerateEstates.Enabled = true;
            btnSearch.Enabled = true;
            btnShowAll.Enabled = true;
            btnDelete.Enabled = true;

            btnSaveChanges.BackColor = Color.FromArgb(168, 165, 209);
            btnChangeEstate.BackColor = Color.FromArgb(140, 135, 222);
            btnCreateEstate.BackColor = Color.FromArgb(140, 135, 222);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = textId.Text;
            LegalForms legalForm = (LegalForms)comboBoxLegalForm.SelectedItem;
            Countries country = (Countries)comboBoxCountry.SelectedItem;
            string city = textBoxCity.Text;
            string zipCode = textBoxZipCode.Text;
            string street = textBoxStreet.Text;
            Category category = (Category)comboBox3.SelectedItem;
            var type = comboBox4.SelectedItem;
            string text = textBox6.Text;
            TypeAll typeAll = (TypeAll)comboBox4.SelectedItem;
            estateHandler.SaveFile(id, legalForm, country, city, zipCode, street, category, type, text, typeAll);
        }

        private async void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // char msg = "Id:" + id + "Legalform:" + legalForm + "Country:" + country + "City:" + city + "zipcode:" + zipCode + "Street:" + street + " Category:" + category + "Ttype:" + type + "Text:" + text + "Type:" + typeAll;
            string tmpStr = "";
            foreach(var item in listBox1.SelectedItems)
            {
                tmpStr += listBox1.GetItemText(item) + "\n";
            }
            using (SaveFileDialog ofd = new SaveFileDialog() { Filter= "Text files (*.txt)|*.txt|All files (*.*)|*.*", ValidateNames = true})
            {
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    //dfndlfkn
                    try
                    {
                        using (StreamWriter sr = new StreamWriter(ofd.FileName))
                        {
                            await sr.WriteLineAsync(tmpStr.Text);
                            MessageBox.Show("Successfully saved", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                    catch(Exception eo)
                    {
                        Console.WriteLine("The file could not be read:");
                        Console.WriteLine(eo.Message);
                    }
                }
            }
        }
    }
}